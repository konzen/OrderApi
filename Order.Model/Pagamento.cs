namespace Order.Model
{
    public sealed class Pagamento
    {
        public Cartao? Cartao { get; set; }
        public Pix? Pix { get; set; }
        public Cheque? Cheque { get; set; }
        public ConvenioPagamento? Convenio { get; set; }
        public Boleto? Boleto { get; set; }
        public Deposito? DepositoBancario { get; set; }
        public Vale? Vale { get; set; }

        public void EntryToNull()
        {
            if (Cartao.IsEmpty()) Cartao = null;
            if (Pix.IsEmpty()) Pix = null;
            if (Cheque.IsEmpty()) Cheque = null;
            if (Convenio.IsEmpty()) Convenio = null;
            if (Boleto.IsEmpty()) Boleto = null;
            if (DepositoBancario.IsEmpty()) DepositoBancario = null;
            if (Vale.IsEmpty()) Vale = null;
        }
    }
}
