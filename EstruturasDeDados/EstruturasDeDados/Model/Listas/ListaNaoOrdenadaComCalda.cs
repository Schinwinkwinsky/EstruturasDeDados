using System;

namespace EstruturasDeDados.Model.Listas
{
    class ListaNaoOrdenadaComCalda : ListaComCalda
    {
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
    }
}
