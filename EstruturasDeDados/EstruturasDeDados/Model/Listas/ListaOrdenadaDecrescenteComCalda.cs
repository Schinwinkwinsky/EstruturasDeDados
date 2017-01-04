using System;

namespace EstruturasDeDados.Model.Listas
{
    class ListaOrdenadaDecrescenteComCalda : ListaComCalda
    {
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
                    if (no.Valor < Cabeca.Valor)
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
                    if (no.Valor > Cabeca.Valor)
                    {
                        no.ProximoNo = Cabeca;
                        Cabeca.AnteriorNo = no;
                        Cabeca = no;
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
                            No aux1 = Calda.AnteriorNo;

                            aux1.ProximoNo = no;
                            no.AnteriorNo = aux1;
                            no.ProximoNo = Calda;
                            Calda.AnteriorNo = no;
                        }
                        else
                        {
                            if (no.Valor > aux.Valor)
                            {
                                No aux1 = aux.AnteriorNo;

                                aux1.ProximoNo = no;
                                no.AnteriorNo = aux1;
                                no.ProximoNo = aux;
                                aux.AnteriorNo = no;
                            }
                            else
                            {
                                Calda.ProximoNo = no;
                                no.AnteriorNo = Calda;
                                Calda = no;
                            }
                        }
                    }                    
                }
            }
        }
    }
}
