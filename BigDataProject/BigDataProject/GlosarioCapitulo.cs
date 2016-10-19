using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigDataProject
{
    class GlosarioCapitulo
    {
        public string capitulo { get; set; }
        public int Totalpreposiciones { get; set; }
        public int Totalpronombres { get; set; }
        public int Totalarticulos { get; set; }
        public int Totaladjetivos { get; set; }
        public List<Letra> Letra { get; set; }
    }
}
