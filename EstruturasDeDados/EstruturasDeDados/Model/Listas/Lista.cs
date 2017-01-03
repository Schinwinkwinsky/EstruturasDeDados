namespace EstruturasDeDados.Model.Listas
{
    public abstract class Lista
    {
        public No Cabeca { get; set; }
        public int Tamanho { get; set; }

        /// <summary>
        /// Insere um novo Nó na Lista
        /// </summary>
        /// <param name="no">Novo Nó a ser inserido na Lista</param>
        public virtual void InserirNo(No no) { }

        /// <summary>
        /// Insere um novo Nó na Lista numa determinada posição.
        /// </summary>
        /// <param name="no">Novo Nó a ser inserido na Lista.</param>
        /// <param name="posicao">Posição na qual será inserido o novo Nó.</param>
        public virtual void InserirNo(No no, uint posicao) { }

        /// <summary>
        /// Remove um Nó da Lista em uma determinada posição.
        /// </summary>
        /// <param name="posicao">Posição do Nó a ser removido da Lista.</param>
        public abstract void RemoverNoDaPosicao(uint posicao);

        /// <summary>
        /// Remove o primeiro Nó da Lista que contém um determinado valor.
        /// </summary>
        /// <param name="valor">Valor contido no Nó a ser removido da Lista</param>
        public abstract void RemoverNoPorValor(int valor);

        /// <summary>
        /// Determina se a Lista está vazia.
        /// </summary>
        /// <returns>verdade: se a Lista estiver vazia.
        /// falso: se a Lista não estiver vazia.</returns>
        public virtual bool Vazia()
        {
            return (Cabeca == null) ? true : false;
        }
    }
}
