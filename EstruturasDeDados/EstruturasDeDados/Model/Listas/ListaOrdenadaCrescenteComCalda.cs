using System;

namespace EstruturasDeDados.Model.Listas
{
    class ListaOrdenadaCrescenteComCalda : Lista
    {
        private No Calda { get; set; }

        public override void InserirNo(No no)
        {
            //Se lista vazia.
            if (Vazia())
            {
                Cabeca = no;
                Calda = no;
            }
            else
            {
                //Se lista contém apenas um item.
                if (Cabeca == Calda)
                {
                    if (no.Valor > Cabeca.Valor)
                    {
                        Cabeca.ProximoNo = no;
                        no.AnteriorNo = Cabeca;
                        Calda = no;
                    }
                    else
                    {
                        no.ProximoNo = Cabeca;
                        Cabeca.AnteriorNo = no;
                        Cabeca = no;
                    }
                }
                else
                {
                    No aux = Cabeca;

                    while (no.Valor <= aux.Valor && aux != Calda)
                    {
                        aux = aux.ProximoNo;
                    }

                    if (no.Valor > aux.Valor && aux == Calda)
                    {
                        Calda.ProximoNo = no;
                        no.AnteriorNo = Calda;
                        Calda = no;
                    }
                    else
                    {
                        if (no.Valor > aux.Valor)
                        {
                            No aux1 = aux.ProximoNo;

                            aux.ProximoNo = no;
                            no.AnteriorNo = aux;
                            no.ProximoNo = aux1;
                            aux1.AnteriorNo = no;
                        }
                        else
                        {
                            No aux1 = Calda.AnteriorNo;

                            aux1.ProximoNo = no;
                            no.AnteriorNo = aux1;
                            no.ProximoNo = Calda;
                            Calda.AnteriorNo = no;
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
            else
            {
                if (Cabeca == Calda)
                {
                    if (posicao == 1)
                    {
                        Cabeca = null;
                        Calda = null;
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
                        aux = null;
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
                            aux = null;
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
                            }
                            else
                            {
                                throw new IndexOutOfRangeException("Posição inválida! Lista não contém a posição especificada.");
                            }
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
            else
            {
                if (Cabeca == Calda)
                {
                    if (Cabeca.Valor == valor)
                    {
                        Cabeca = null;
                        Calda = null;
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
                        aux = null;
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
                            aux = null;
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
}
