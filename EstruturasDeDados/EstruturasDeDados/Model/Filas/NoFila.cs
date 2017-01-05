using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstruturasDeDados.Model.Filas
{
    public class NoFila : No
    {
        public int Prioridade { get; set; }

        NoFila() { }

        NoFila(int valor, int prioridade) : base(valor)
        {
            Prioridade = prioridade;
        }
    }
}
