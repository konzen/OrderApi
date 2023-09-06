using System.Diagnostics;

namespace Order.Processor
{
    /// <summary>
    /// Gerador de ID único Thread-Safe de alta performance.
    /// Autor: Adriano Konzen
    /// </summary>
    public sealed class ConcurrentUniqueId : IUniqueId
    {
        private const int nodeBits = 5; // 32 nós
        private const int msBits = 42; // 139 anos
        private const int sequenceBits = 16; // 65536 sequências/ms
        private const int nodeMask = (1 << nodeBits) - 1;
        private const long msMask = (1L << msBits) - 1L;
        private const int sequenceShift = msBits + nodeBits;
        private const long incSequence = 1L << sequenceShift;
        private static readonly long referenceTicks = new DateTime(2020, 01, 01).Ticks;

        private long id;
        private readonly long nodeId;
        private readonly Stopwatch stopwatch;
        private readonly long startMilliseconds;
        private int _lock;

        private volatile bool disposed;

        static ConcurrentUniqueId()
        {
            // signal 1 bit | sequence 16 bits | nodeId 5 bits | milliseconds 42 bits = 64 bits
            Debug.Assert(1 + sequenceBits + nodeBits + msBits == sizeof(long) * 8);

            if (!Environment.Is64BitProcess) throw new InvalidOperationException("Suporte apenas para processos de 64 bits.");
        }

        public ConcurrentUniqueId(int nodeId)
        {
            if (nodeId < 0 || nodeId > nodeMask) throw new ArgumentOutOfRangeException(nameof(nodeId));

            this.nodeId = (long)nodeId << msBits;

            stopwatch = Stopwatch.StartNew();

            startMilliseconds = (DateTime.UtcNow.Ticks - referenceTicks) / TimeSpan.TicksPerMillisecond;

            UpdateIdNextMillisecond();

            Task.Run(UpdateIdPerMillisecond);
        }

        public long GetId()
        {
            long cId;

            while (!disposed)
            {
                if ((cId = id) < 0L)
                {
                    // Taxa máxima de geração excedida
                    UpdateIdNextMillisecond();
                }
                else
                {
                    // Garante unicidade | Incrementa a sequência dentro do mesmo milissegundo
                    if (Interlocked.CompareExchange(ref id, cId + incSequence, cId) == cId) return cId;
                }
            }

            throw new ObjectDisposedException(nameof(ConcurrentUniqueId));
        }

        public static string ToString(long id)
        {
            var time = new DateTime((id & msMask) * TimeSpan.TicksPerMillisecond + referenceTicks, DateTimeKind.Utc);

            return $"{time:yyyy-MM-ddTHH:mm:ss.fffZ}#{id >> sequenceShift}N{(id >> msBits) & nodeMask}";
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        private long Milliseconds => (startMilliseconds + stopwatch.ElapsedMilliseconds) & msMask;

        /// <summary>
        /// Atualiza o ID a cada novo milissegundo
        /// </summary>
        private void UpdateIdPerMillisecond()
        {
            while (!disposed)
            {
                Thread.Sleep(1);
                UpdateIdNextMillisecond();
            }
        }

        /// <summary>
        /// Atualiza o ID para o próximo milissegundo
        /// </summary>
        private void UpdateIdNextMillisecond()
        {
            long ms;

            // Já está atualizando
            if (_lock != 0) return;

            // Garante que apenas uma Thread atualize | Atualiza apenas se os milissegundos forem alterados
            if (Interlocked.Add(ref _lock, 1) == 1 && (id & msMask) < (ms = Milliseconds)) Interlocked.Exchange(ref id, ms | nodeId);

            Interlocked.Add(ref _lock, -1);
        }

        private void Dispose(bool disposing) => disposed = true;
    }
}
