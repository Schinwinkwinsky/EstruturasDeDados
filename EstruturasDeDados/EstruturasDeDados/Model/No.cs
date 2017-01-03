namespace EstruturasDeDados.Model
{
    public class No
    {
        public int Valor { get; set; }
        public No ProximoNo { get; set; }
        public No AnteriorNo { get; set; }

        public No() { }

        public No(int valor)
        {
            Valor = valor;
        }
    }
}
