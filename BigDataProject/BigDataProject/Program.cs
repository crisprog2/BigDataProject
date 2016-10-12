using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BigDataProject
{
    class Program
    {
        static void Main(string[] args)
        {
            string cadena;
            int numpronombres = 0, numadjetivos=0;
            Char delimitador = ' ';
            string[] capitulo = System.IO.File.ReadAllLines(@"D:\IMPORTANTE_NO_BORRAR\DOCUMENTOS\BIG DATA\LIBRO DON QUIJOTE\capitulo 1.txt", Encoding.UTF8);
            string[] pronombres = System.IO.File.ReadAllLines(@"D:\IMPORTANTE_NO_BORRAR\DOCUMENTOS\BIG DATA\pronombres.txt", Encoding.UTF8);
            string[] adjetivos = System.IO.File.ReadAllLines(@"D:\IMPORTANTE_NO_BORRAR\DOCUMENTOS\BIG DATA\adjetivos.txt", Encoding.UTF8);
            foreach (string line in capitulo)
            {
                cadena=Regex.Replace(line, @"[,-.:()«»¿?;!¡]", "");
                cadena = cadena.ToLower();
                Console.WriteLine(cadena);
                string[] palabras = cadena.Split(delimitador);
                foreach(var palabra in palabras)
                {
                    foreach(string pronombre in pronombres)
                    {
                        if (palabra.Equals(pronombre))
                        {
                            numpronombres++;
                        }
                    }
                    foreach (string adjetivo in adjetivos)
                    {
                        if (palabra.Equals(adjetivo))
                        {
                            numadjetivos++;
                        }
                    }
                }
            }
            Console.WriteLine("**************************************************");
            Console.WriteLine("**************************************************");
            Console.WriteLine("Numero de pronombres en capitulo: "+numpronombres);
            Console.WriteLine("Numero de adjetivos en capitulo: " + numadjetivos);
            Console.ReadLine();
        }
    }
}
