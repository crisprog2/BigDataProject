using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigDataProject
{
    class Program
    {
        static void Main(string[] args)
        {
            int numpronombres = 0;
            string prueba = "adonde adónde cuánto muchas yo";
            Char delimitador = ' ';
            //string[] capitulo = System.IO.File.ReadAllLines(@"D:\IMPORTANTE_NO_BORRAR\DOCUMENTOS\BIG DATA\LIBRO DON QUIJOTE\capitulo 1.txt", Encoding.UTF8);
            string[] pronombres = System.IO.File.ReadAllLines(@"D:\IMPORTANTE_NO_BORRAR\DOCUMENTOS\BIG DATA\pronombres.txt", Encoding.UTF8);
            /*foreach (string line in capitulo)
            {
                string[] palabras = line.Split(delimitador);
                foreach(var palabra in palabras)
                {
                    foreach(string pronombre in pronombres)
                    {
                        if (palabra.Equals(pronombre))
                        {
                            numpronombres++;
                        }
                    }
                }
            }*/
            string[] palabras = prueba.Split(delimitador);

            foreach(var palabra in palabras)
            {
                foreach(string pronombre in pronombres)
                {
                    if (palabra.Equals(pronombre))
                    {
                        numpronombres++;
                    }
                }
            }

            Console.WriteLine(numpronombres);
            Console.ReadLine();
        }
    }
}
