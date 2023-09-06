using Order.Processor;
using System.Diagnostics;

namespace Order.Test
{
    public class UnitTest
    {
        [Fact]
        public void Test_UniqueIdConcurrent()
        {
            const int idsCount = 10000000;
            int tasksCount = Environment.ProcessorCount / 2;

            var tasks = new Task<long[]>[tasksCount];

            IUniqueId uniqueId = new ConcurrentUniqueId(new Random().Next(32));

            long ticks = 0L;
            var startTime = DateTime.Now + TimeSpan.FromSeconds(3);

            for (int t = 0; t < tasks.Length; t++)
            {
                tasks[t] = Task.Run(() =>
                {
                    var ids = new long[idsCount];
                    var stopwatch = new Stopwatch();

                    SpinWait.SpinUntil(() => DateTime.Now >= startTime);

                    unsafe
                    {
                        fixed (long* fIds = &ids[0])
                        {
                            var pIds = fIds;

                            stopwatch.Start();

                            for (int count = ids.Length / 16; count > 0; pIds += 16, count--)
                            {
                                *pIds = uniqueId.GetId();
                                *(pIds + 1) = uniqueId.GetId();
                                *(pIds + 2) = uniqueId.GetId();
                                *(pIds + 3) = uniqueId.GetId();
                                *(pIds + 4) = uniqueId.GetId();
                                *(pIds + 5) = uniqueId.GetId();
                                *(pIds + 6) = uniqueId.GetId();
                                *(pIds + 7) = uniqueId.GetId();
                                *(pIds + 8) = uniqueId.GetId();
                                *(pIds + 9) = uniqueId.GetId();
                                *(pIds + 10) = uniqueId.GetId();
                                *(pIds + 11) = uniqueId.GetId();
                                *(pIds + 12) = uniqueId.GetId();
                                *(pIds + 13) = uniqueId.GetId();
                                *(pIds + 14) = uniqueId.GetId();
                                *(pIds + 15) = uniqueId.GetId();
                            }

                            stopwatch.Stop();
                        }
                    }

                    Interlocked.Add(ref ticks, stopwatch.Elapsed.Ticks);
                    Debug.WriteLine(stopwatch.Elapsed);

                    return ids;
                });
            }

            Task.WaitAll(tasks);

            var speed = tasksCount * idsCount / new TimeSpan(ticks / tasksCount).TotalSeconds;

            var allIds = new HashSet<long>(tasksCount * idsCount);

            for (int t = 0; t < tasks.Length; t++)
            {
                var ids = tasks[t].Result;

                for (int i = 0; i < ids.Length; i++)
                {
                    Assert.True(allIds.Add(ids[i]), $"ID duplicado: {ConcurrentUniqueId.ToString(ids[i])}");
                }
            }

            if (Debugger.IsAttached)
                Debug.WriteLine($"{speed:N0} IDs/s");
            else
                Assert.Fail($"{speed:N0} IDs/s");
        }
    }
}
