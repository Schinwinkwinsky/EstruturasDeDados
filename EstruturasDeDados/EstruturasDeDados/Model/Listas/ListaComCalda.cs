using System;

namespace EstruturasDeDados.Model.Listas
{
    public abstract class ListaComCalda
    {
        public No Cabeca { get; set; }
        public No Calda { get; set; }
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
        public virtual void RemoverNoDaPosicao(uint posicao)
        {
            int cont = 1;
            No aux = Cabeca;

            if (Vazia())
            {
                throw new IndexOutOfRangeException("Lista vazia!");
            }
            else if (Cabeca == Calda)
            {
                if (posicao == 1)
                {
                    Cabeca = null;
                    Calda = null;

                    Tamanho--;
                }
                else
                {
                    throw new IndexOutOfRangeException("Posição inválida! Lista não contém a posição especificada.");
                }
            }
            else
            {
                if (posicao == 0)
                {
                    throw new IndexOutOfRangeException("Posição inválida! Lista não contém a posição especificada.");
                }
                else if (posicao == 1)
                {
                    Cabeca = Cabeca.ProximoNo;
                    Cabeca.AnteriorNo = null;
                    aux = null;

                    Tamanho--;
                }
                else
                {
                    while (cont != posicao && aux != Calda)
                    {
                        aux = aux.ProximoNo;
                        cont++;
                    }

                    if (cont == posicao && aux == Calda)
                    {
                        Calda = Calda.AnteriorNo;
                        Calda.ProximoNo = null;
                        aux = null;

                        Tamanho--;
                    }
                    else
                    {
                        if (cont == posicao)
                        {
                            No auxAnt = aux.AnteriorNo;
                            No auxProx = aux.ProximoNo;

                            auxAnt.ProximoNo = auxProx;
                            auxProx.AnteriorNo = auxAnt;

                            aux = null;

                            Tamanho--;
                        }
                        else
                        {
                            throw new IndexOutOfRangeException("Posição inválida! Lista não contém a posição especificada.");
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Remove o primeiro Nó da Lista que contém um determinado valor.
        /// </summary>
        /// <param name="valor">Valor contido no Nó a ser removido da Lista</param>
        public virtual void RemoverNoPorValor(int valor)
        {
            No aux = Cabeca;

            if (Vazia())
            {
                throw new ArgumentException("Lista vazia!");
            }
            else if (Cabeca == Calda)
            {
                if (Cabeca.Valor == valor)
                {
                    Cabeca = null;
                    Calda = null;

                    Tamanho--;
                }
                else
                {
                    throw new ArgumentException("Valor não encontrado na Lista!");
                }
            }
            else
            {
                if (Cabeca.Valor == valor)
                {
                    Cabeca = Cabeca.ProximoNo;
                    Cabeca.AnteriorNo = null;
                    aux = null;

                    Tamanho--;
                }
                else
                {
                    while (aux.Valor != valor && aux != Calda)
                    {
                        aux = aux.ProximoNo;
                    }

                    if (aux.Valor == valor && aux == Calda)
                    {
                        Calda = Calda.AnteriorNo;
                        Calda.ProximoNo = null;
                        aux = null;

                        Tamanho--;
                    }
                    else
                    {
                        if (aux.Valor == valor)
                        {
                            No auxAnt = aux.AnteriorNo;
                            No auxProx = aux.ProximoNo;

                            auxAnt.ProximoNo = auxProx;
                            auxProx.AnteriorNo = auxAnt;

                            aux = null;

                            Tamanho--;
                        }
                        else
                        {
                            throw new ArgumentException("Valor não encontrado na Lista!");
                        }
                    }
                }
            }
        }

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
