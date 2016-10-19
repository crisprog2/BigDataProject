using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigDataProject
{
    class Glosario
    {
        public string nombre { get; set; }
        public int numeroPalabras { get; set; }
        public List<GlosarioCapitulo> Capitulo { get; set; }
    }
}
