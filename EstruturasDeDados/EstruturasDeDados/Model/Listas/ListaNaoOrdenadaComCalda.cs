using System;

namespace EstruturasDeDados.Model.Listas
{
    class ListaNaoOrdenadaComCalda : Lista
    {
        /// <summary>
        /// Calda da Lista.
        /// </summary>
        public No Calda { get; set; }

        public override void InserirNo(No no, UInt32 posicao)
        {
            if (Vazia())
            {
                if (posicao == 1)
                {
                    Cabeca = no;
                    Calda = no;

                    Tamanho++;
                }
                else
                {
                    throw new IndexOutOfRangeException("Posição inválida! Lista não contém a posição especificada.");
                }
            }
            else if (Cabeca == Calda)
            {
                if (posicao == 1)
                {
                    Cabeca = no;
                    Cabeca.ProximoNo = Calda;
                    Calda.AnteriorNo = Cabeca;

                    Tamanho++;
                }
                else if (posicao == 2)
                {
                    Calda = no;
                    Cabeca.ProximoNo = Calda;
                    Calda.AnteriorNo = Cabeca;

                    Tamanho++;
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
                    no.ProximoNo = Cabeca;
                    Cabeca.AnteriorNo = no;
                    Cabeca = no;

                    Tamanho++;
                }
                else
                {
                    if (posicao < Tamanho)
                    {
                        No aux = Cabeca;
                        int cont = 1;

                        while (cont != posicao)
                        {
                            aux = aux.ProximoNo;
                            cont++;
                        }

                        if (cont == posicao)
                        {
                            No aux1 = aux.AnteriorNo;

                            aux1.ProximoNo = no;
                            no.AnteriorNo = aux1;
                            no.ProximoNo = aux;
                            aux.AnteriorNo = no;

                            Tamanho++;
                        }
                    }
                    else if (posicao == Tamanho)
                    {
                        No aux1 = Calda.AnteriorNo;

                        aux1.ProximoNo = no;
                        no.AnteriorNo = aux1;
                        no.ProximoNo = Calda;
                        Calda.AnteriorNo = no;

                        Tamanho++;
                    }
                    else
                    {
                        if (posicao == Tamanho + 1)
                        {
                            Calda.ProximoNo = no;
                            no.AnteriorNo = Calda;
                            Calda = no;

                            Tamanho++;
                        }
                        else
                        {
                            throw new IndexOutOfRangeException("Posição inválida! Lista não contém a posição especificada.");
                        }
                    }
                }
            }
        }

        public override void RemoverNoDaPosicao(UInt32 posicao)
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
                if (posicao == 1)
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

        public override void RemoverNoPorValor(Int32 valor)
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
    }
}
