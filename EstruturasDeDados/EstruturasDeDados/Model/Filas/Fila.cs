using System;

namespace EstruturasDeDados.Model.Filas
{
    public class Fila
    {
        public NoFila Cabeca { get; set; }
        public NoFila Calda { get; set; }
        public int Tamanho { get; set; }

        public bool Vazia()
        {
            return (Cabeca == null) ? true : false;
        }

        public void Entrar(NoFila no)
        {
            if (Vazia())
            {
                Cabeca = no;
                Calda = no;
            }
            else
            {
                Calda.ProximoNo = no;
                no.AnteriorNo = Calda;
                Calda = no;
            }

            Tamanho++;
        }

        public void Sair()
        {
            if (Vazia())
            {
                throw new ArgumentException("Lista vazia!");
            }
            else if (Cabeca == Calda)
            {
                Cabeca = null;
                Calda = null;

                Tamanho--;
            }
            else
            {
                Calda = Calda.AnteriorNo as NoFila;
                Calda.ProximoNo = null;

                Tamanho--;
            }            
        }

        public void Desistir(int posicao)
        {
            if (posicao <= 0 || posicao > Tamanho)
            {
                throw new ArgumentException("Posição inválida!");
            }
            else
            {
                if (posicao == 1)
                {
                    if (Cabeca == Calda)
                    {
                        Cabeca = null;
                        Calda = null;
                    }
                    else
                    {
                        Cabeca = Cabeca.ProximoNo as NoFila;
                        Cabeca.AnteriorNo = null;
                    }
                }
                else
                {
                    NoFila aux = Cabeca;
                    int cont = 1;

                    while (cont != posicao)
                    {
                        aux = aux.ProximoNo as NoFila;
                        cont++;
                    }

                    if (aux == Calda)
                    {
                        Calda = Calda.AnteriorNo as NoFila;
                        Calda.ProximoNo = null;
                    }
                    else
                    {
                        NoFila auxAnt = aux.AnteriorNo as NoFila;
                        NoFila auxProx = aux.ProximoNo as NoFila;

                        auxAnt.ProximoNo = auxProx;
                        auxProx.AnteriorNo = auxAnt;

                        aux = null;
                    }
                }
            }
        }
    }
}
