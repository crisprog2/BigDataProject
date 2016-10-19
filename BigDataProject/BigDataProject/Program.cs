using Newtonsoft.Json;
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
        /*
         * En esta seccion se crea todas la variables globales que se van a utilizar a travéz del programa.
         * Se crean varias listas las cuales guardarán los datos de manera dinámica.
         * Adicionalmente se crean varios arreglos los cuales nos serviran para realizar la suma de los datos ordenados alfabéticamente
         * Se crea una variable global la cual nos sacará la suma de todas las palabras en el libro
         */
        public static Letra letraABC;
        public static List<Letra> listaLetra;
        public static GlosarioCapitulo glosarioCap;
        public static List<GlosarioCapitulo> listaGlosarioCap = new List<GlosarioCapitulo>();
        public static List<int> numeropronombres = new List<int>();
        public static List<int> numeroadjetivos = new List<int>();
        public static List<int> numeroarticulos = new List<int>();
        public static List<int> numeropreposiciones = new List<int>();
        public static int[] pronombresxalfabeto = new int[27];
        public static int[] preposicionexsalfabeto = new int[27];
        public static int[] articulosxalfabeto = new int[27];
        public static int[] adjetivosxalfabeto = new int[27];
        public static char[] abecedario = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'ñ', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
        public static int numeropalabras = 0;
        

        /*
         * Con esta función inicializaremos los arreglos que nos sumarán la cantidad de datos que hay en el libro ordenados alfabéticamente
         */
        public static void iniciarVectores()
        {
            for (int i = 0; i < 27; i++)
            {
                pronombresxalfabeto[i] = 0;
                preposicionexsalfabeto[i] = 0;
                articulosxalfabeto[i] = 0;
                adjetivosxalfabeto[i] = 0;
            }
        }



        /*
         * Con esta función realizaremos la extracción de datos e iremos construyendo el glosario solicitado.
         * Recibe como parámetro el número del capítulo a revisar.
         */
        public static void datos(int numcap)
        {
            //inicializaremos la lista en la cual guardaremos de manera alfabética la cantidad de pronombres, preposiciones, adjetivos y artículos
            listaLetra = new List<Letra>();
            //Por cada capítulo revisado reinicia los contadores de los Arreglos para así sacar un dato real
            iniciarVectores();
            //Variable para realizar la limpieza del texto en el libro
            string cadena;
            //Variables para realizar la sumatoria de cada uno de los datos a extraer por capítulo
            int numpronombres = 0, numadjetivos = 0, numarticulos=0, numpreposiciones=0;
            //Variable para decirle al programa que vamos a realizar una separación de palabras por espacio de cada línea de los capítulos
            Char delimitador = ' ';
            //Variable que guarda en un array todas las lineas del capítulo cargado al programa en UTF8
            string[] capitulo = System.IO.File.ReadAllLines(@"D:\IMPORTANTE_NO_BORRAR\DOCUMENTOS\BIG DATA\DON QUIJOTE\CAPITULO " + numcap+".txt", Encoding.UTF8);
            //Variable que guarda en un array todas las lineas del archivo de pronombres cargado al programa en UTF8
            string[] pronombres = System.IO.File.ReadAllLines(@"D:\IMPORTANTE_NO_BORRAR\DOCUMENTOS\BIG DATA\pronombres.txt", Encoding.UTF8);
            //Variable que guarda en un array todas las lineas del archivo de adjetivos cargado al programa en UTF8
            string[] adjetivos = System.IO.File.ReadAllLines(@"D:\IMPORTANTE_NO_BORRAR\DOCUMENTOS\BIG DATA\adjetivos.txt", Encoding.UTF8);
            //Variable que guarda en un array todas las lineas del archivo de preposiciones cargado al programa en UTF8
            string[] preposiciones=System.IO.File.ReadAllLines(@"D:\IMPORTANTE_NO_BORRAR\DOCUMENTOS\BIG DATA\preposiciones.txt", Encoding.UTF8);
            //Variable que guarda en un array todas las lineas del capítulo del archivo de artículos al programa en UTF8
            string[] articulos = System.IO.File.ReadAllLines(@"D:\IMPORTANTE_NO_BORRAR\DOCUMENTOS\BIG DATA\articulos.txt", Encoding.UTF8);
            //En este for lee cada linea del capítulo
            foreach (string line in capitulo)
            {
                /*
                 * En esta sección se aplican las expresiones regulares para limpiar el contenido de cada linea eliminando algunos caracteres especiales
                 * y convirtiendo cada mayúscula en minúscula
                 */
                cadena = Regex.Replace(line, @"[,-.:()«»¿?;!¡]", "");
                cadena = cadena.ToLower();


                //En este array se guardan las palabras separadas de cada linea del capítulo
                string[] palabras = cadena.Split(delimitador);



                /*
                 * En esta sección se realiza una evaluación de cada palabra para saber cuál es un pronombre, preposición, adjetivo y artículo.
                 * Teniendo esta información realiza un conteo para saber la cantidad de cada datos en cada linea (pronombre, preposición, adjetivo y artículo).
                 * Adicionalmente verifica la primera letra de cada palabra y realiza una suma para sacar la cantidad de pronombres, preposiciones, adjetivos y artículos de una 
                 * manera discriminada y ordenada alfabéticamente utilizando el array del abecedario.
                 */
                foreach (var palabra in palabras)
                {
                    numeropalabras++;
                    foreach (string pronombre in pronombres)
                    {
                        if (palabra.Equals(pronombre))
                        {
                            numpronombres++;
                            switch (palabra[0])
                            {
                                case 'a':
                                    pronombresxalfabeto[0] = pronombresxalfabeto[0] + 1;
                                    break;
                                case 'b':
                                    pronombresxalfabeto[1] = pronombresxalfabeto[1] + 1;
                                    break;
                                case 'c':
                                    pronombresxalfabeto[2] = pronombresxalfabeto[2] + 1;
                                    break;
                                case 'd':
                                    pronombresxalfabeto[3] = pronombresxalfabeto[3] + 1;
                                    break;
                                case 'e':
                                    pronombresxalfabeto[4] = pronombresxalfabeto[4] + 1;
                                    break;
                                case 'f':
                                    pronombresxalfabeto[5] = pronombresxalfabeto[5] + 1;
                                    break;
                                case 'g':
                                    pronombresxalfabeto[6] = pronombresxalfabeto[6] + 1;
                                    break;
                                case 'h':
                                    pronombresxalfabeto[7] = pronombresxalfabeto[7] + 1;
                                    break;
                                case 'i':
                                    pronombresxalfabeto[8] = pronombresxalfabeto[8] + 1;
                                    break;
                                case 'j':
                                    pronombresxalfabeto[9] = pronombresxalfabeto[9] + 1;
                                    break;
                                case 'k':
                                    pronombresxalfabeto[10] = pronombresxalfabeto[10] + 1;
                                    break;
                                case 'l':
                                    pronombresxalfabeto[11] = pronombresxalfabeto[11] + 1;
                                    break;
                                case 'm':
                                    pronombresxalfabeto[12] = pronombresxalfabeto[12] + 1;
                                    break;
                                case 'n':
                                    pronombresxalfabeto[13] = pronombresxalfabeto[13] + 1;
                                    break;
                                case 'ñ':
                                    pronombresxalfabeto[14] = pronombresxalfabeto[14] + 1;
                                    break;
                                case 'o':
                                    pronombresxalfabeto[15] = pronombresxalfabeto[15] + 1;
                                    break;
                                case 'p':
                                    pronombresxalfabeto[16] = pronombresxalfabeto[16] + 1;
                                    break;
                                case 'q':
                                    pronombresxalfabeto[17] = pronombresxalfabeto[17] + 1;
                                    break;
                                case 'r':
                                    pronombresxalfabeto[18] = pronombresxalfabeto[18] + 1;
                                    break;
                                case 's':
                                    pronombresxalfabeto[19] = pronombresxalfabeto[19] + 1;
                                    break;
                                case 't':
                                    pronombresxalfabeto[20] = pronombresxalfabeto[20] + 1;
                                    break;
                                case 'u':
                                    pronombresxalfabeto[21] = pronombresxalfabeto[21] + 1;
                                    break;
                                case 'v':
                                    pronombresxalfabeto[22] = pronombresxalfabeto[22] + 1;
                                    break;
                                case 'w':
                                    pronombresxalfabeto[23] = pronombresxalfabeto[23] + 1;
                                    break;
                                case 'x':
                                    pronombresxalfabeto[24] = pronombresxalfabeto[24] + 1;
                                    break;
                                case 'y':
                                    pronombresxalfabeto[25] = pronombresxalfabeto[25] + 1;
                                    break;
                                case 'z':
                                    pronombresxalfabeto[26] = pronombresxalfabeto[26] + 1;
                                    break;
                            }
                        }
                    }
                    foreach (string adjetivo in adjetivos)
                    {
                        if (palabra.Equals(adjetivo))
                        {
                            numadjetivos++;
                            switch (palabra[0])
                            {
                                case 'a':
                                    adjetivosxalfabeto[0] = adjetivosxalfabeto[0] + 1;
                                    break;
                                case 'b':
                                    adjetivosxalfabeto[1] = adjetivosxalfabeto[1] + 1;
                                    break;
                                case 'c':
                                    adjetivosxalfabeto[2] = adjetivosxalfabeto[2] + 1;
                                    break;
                                case 'd':
                                    adjetivosxalfabeto[3] = adjetivosxalfabeto[3] + 1;
                                    break;
                                case 'e':
                                    adjetivosxalfabeto[4] = adjetivosxalfabeto[4] + 1;
                                    break;
                                case 'f':
                                    adjetivosxalfabeto[5] = adjetivosxalfabeto[5] + 1;
                                    break;
                                case 'g':
                                    adjetivosxalfabeto[6] = adjetivosxalfabeto[6] + 1;
                                    break;
                                case 'h':
                                    adjetivosxalfabeto[7] = adjetivosxalfabeto[7] + 1;
                                    break;
                                case 'i':
                                    adjetivosxalfabeto[8] = adjetivosxalfabeto[8] + 1;
                                    break;
                                case 'j':
                                    adjetivosxalfabeto[9] = adjetivosxalfabeto[9] + 1;
                                    break;
                                case 'k':
                                    adjetivosxalfabeto[10] = adjetivosxalfabeto[10] + 1;
                                    break;
                                case 'l':
                                    adjetivosxalfabeto[11] = adjetivosxalfabeto[11] + 1;
                                    break;
                                case 'm':
                                    adjetivosxalfabeto[12] = adjetivosxalfabeto[12] + 1;
                                    break;
                                case 'n':
                                    adjetivosxalfabeto[13] = adjetivosxalfabeto[13] + 1;
                                    break;
                                case 'ñ':
                                    adjetivosxalfabeto[14] = adjetivosxalfabeto[14] + 1;
                                    break;
                                case 'o':
                                    adjetivosxalfabeto[15] = adjetivosxalfabeto[15] + 1;
                                    break;
                                case 'p':
                                    adjetivosxalfabeto[16] = adjetivosxalfabeto[16] + 1;
                                    break;
                                case 'q':
                                    adjetivosxalfabeto[17] = adjetivosxalfabeto[17] + 1;
                                    break;
                                case 'r':
                                    adjetivosxalfabeto[18] = adjetivosxalfabeto[18] + 1;
                                    break;
                                case 's':
                                    adjetivosxalfabeto[19] = adjetivosxalfabeto[19] + 1;
                                    break;
                                case 't':
                                    adjetivosxalfabeto[20] = adjetivosxalfabeto[20] + 1;
                                    break;
                                case 'u':
                                    adjetivosxalfabeto[21] = adjetivosxalfabeto[21] + 1;
                                    break;
                                case 'v':
                                    adjetivosxalfabeto[22] = adjetivosxalfabeto[22] + 1;
                                    break;
                                case 'w':
                                    adjetivosxalfabeto[23] = adjetivosxalfabeto[23] + 1;
                                    break;
                                case 'x':
                                    adjetivosxalfabeto[24] = adjetivosxalfabeto[24] + 1;
                                    break;
                                case 'y':
                                    adjetivosxalfabeto[25] = adjetivosxalfabeto[25] + 1;
                                    break;
                                case 'z':
                                    adjetivosxalfabeto[26] = adjetivosxalfabeto[26] + 1;
                                    break;
                            }
                        }
                    }
                    foreach (string articulo in articulos)
                    {
                        if (palabra.Equals(articulo))
                        {
                            numarticulos++;
                            switch (palabra[0])
                            {
                                case 'a':
                                    articulosxalfabeto[0] = articulosxalfabeto[0] + 1;
                                    break;
                                case 'b':
                                    articulosxalfabeto[1] = articulosxalfabeto[1] + 1;
                                    break;
                                case 'c':
                                    articulosxalfabeto[2] = articulosxalfabeto[2] + 1;
                                    break;
                                case 'd':
                                    articulosxalfabeto[3] = articulosxalfabeto[3] + 1;
                                    break;
                                case 'e':
                                    articulosxalfabeto[4] = articulosxalfabeto[4] + 1;
                                    break;
                                case 'f':
                                    articulosxalfabeto[5] = articulosxalfabeto[5] + 1;
                                    break;
                                case 'g':
                                    articulosxalfabeto[6] = articulosxalfabeto[6] + 1;
                                    break;
                                case 'h':
                                    articulosxalfabeto[7] = articulosxalfabeto[7] + 1;
                                    break;
                                case 'i':
                                    articulosxalfabeto[8] = articulosxalfabeto[8] + 1;
                                    break;
                                case 'j':
                                    articulosxalfabeto[9] = articulosxalfabeto[9] + 1;
                                    break;
                                case 'k':
                                    articulosxalfabeto[10] = articulosxalfabeto[10] + 1;
                                    break;
                                case 'l':
                                    articulosxalfabeto[11] = articulosxalfabeto[11] + 1;
                                    break;
                                case 'm':
                                    articulosxalfabeto[12] = articulosxalfabeto[12] + 1;
                                    break;
                                case 'n':
                                    articulosxalfabeto[13] = articulosxalfabeto[13] + 1;
                                    break;
                                case 'ñ':
                                    articulosxalfabeto[14] = articulosxalfabeto[14] + 1;
                                    break;
                                case 'o':
                                    articulosxalfabeto[15] = articulosxalfabeto[15] + 1;
                                    break;
                                case 'p':
                                    articulosxalfabeto[16] = articulosxalfabeto[16] + 1;
                                    break;
                                case 'q':
                                    articulosxalfabeto[17] = articulosxalfabeto[17] + 1;
                                    break;
                                case 'r':
                                    articulosxalfabeto[18] = articulosxalfabeto[18] + 1;
                                    break;
                                case 's':
                                    articulosxalfabeto[19] = articulosxalfabeto[19] + 1;
                                    break;
                                case 't':
                                    articulosxalfabeto[20] = articulosxalfabeto[20] + 1;
                                    break;
                                case 'u':
                                    articulosxalfabeto[21] = articulosxalfabeto[21] + 1;
                                    break;
                                case 'v':
                                    articulosxalfabeto[22] = articulosxalfabeto[22] + 1;
                                    break;
                                case 'w':
                                    articulosxalfabeto[23] = articulosxalfabeto[23] + 1;
                                    break;
                                case 'x':
                                    articulosxalfabeto[24] = articulosxalfabeto[24] + 1;
                                    break;
                                case 'y':
                                    articulosxalfabeto[25] = articulosxalfabeto[25] + 1;
                                    break;
                                case 'z':
                                    articulosxalfabeto[26] = articulosxalfabeto[26] + 1;
                                    break;
                            }
                        }
                    }
                    foreach (string preposicion in preposiciones)
                    {
                        if (palabra.Equals(preposicion))
                        {
                            numpreposiciones++;
                            switch (palabra[0])
                            {
                                case 'a':
                                    preposicionexsalfabeto[0] = preposicionexsalfabeto[0] + 1;
                                    break;
                                case 'b':
                                    preposicionexsalfabeto[1] = preposicionexsalfabeto[1] + 1;
                                    break;
                                case 'c':
                                    preposicionexsalfabeto[2] = preposicionexsalfabeto[2] + 1;
                                    break;
                                case 'd':
                                    preposicionexsalfabeto[3] = preposicionexsalfabeto[3] + 1;
                                    break;
                                case 'e':
                                    preposicionexsalfabeto[4] = preposicionexsalfabeto[4] + 1;
                                    break;
                                case 'f':
                                    preposicionexsalfabeto[5] = preposicionexsalfabeto[5] + 1;
                                    break;
                                case 'g':
                                    preposicionexsalfabeto[6] = preposicionexsalfabeto[6] + 1;
                                    break;
                                case 'h':
                                    preposicionexsalfabeto[7] = preposicionexsalfabeto[7] + 1;
                                    break;
                                case 'i':
                                    preposicionexsalfabeto[8] = preposicionexsalfabeto[8] + 1;
                                    break;
                                case 'j':
                                    preposicionexsalfabeto[9] = preposicionexsalfabeto[9] + 1;
                                    break;
                                case 'k':
                                    preposicionexsalfabeto[10] = preposicionexsalfabeto[10] + 1;
                                    break;
                                case 'l':
                                    preposicionexsalfabeto[11] = preposicionexsalfabeto[11] + 1;
                                    break;
                                case 'm':
                                    preposicionexsalfabeto[12] = preposicionexsalfabeto[12] + 1;
                                    break;
                                case 'n':
                                    preposicionexsalfabeto[13] = preposicionexsalfabeto[13] + 1;
                                    break;
                                case 'ñ':
                                    preposicionexsalfabeto[14] = preposicionexsalfabeto[14] + 1;
                                    break;
                                case 'o':
                                    preposicionexsalfabeto[15] = preposicionexsalfabeto[15] + 1;
                                    break;
                                case 'p':
                                    preposicionexsalfabeto[16] = preposicionexsalfabeto[16] + 1;
                                    break;
                                case 'q':
                                    preposicionexsalfabeto[17] = preposicionexsalfabeto[17] + 1;
                                    break;
                                case 'r':
                                    preposicionexsalfabeto[18] = preposicionexsalfabeto[18] + 1;
                                    break;
                                case 's':
                                    preposicionexsalfabeto[19] = preposicionexsalfabeto[19] + 1;
                                    break;
                                case 't':
                                    preposicionexsalfabeto[20] = preposicionexsalfabeto[20] + 1;
                                    break;
                                case 'u':
                                    preposicionexsalfabeto[21] = preposicionexsalfabeto[21] + 1;
                                    break;
                                case 'v':
                                    preposicionexsalfabeto[22] = preposicionexsalfabeto[22] + 1;
                                    break;
                                case 'w':
                                    preposicionexsalfabeto[23] = preposicionexsalfabeto[23] + 1;
                                    break;
                                case 'x':
                                    preposicionexsalfabeto[24] = preposicionexsalfabeto[24] + 1;
                                    break;
                                case 'y':
                                    preposicionexsalfabeto[25] = preposicionexsalfabeto[25] + 1;
                                    break;
                                case 'z':
                                    preposicionexsalfabeto[26] = preposicionexsalfabeto[26] + 1;
                                    break;
                            }
                        }
                    }
                }
            }



            /*
             * En esta sección guardamos en cada lista el numero de adjetivos, articulos, preposiciones, pronombres totales del capítulo
             */
            numeroadjetivos.Add(numadjetivos);
            numeropronombres.Add(numpronombres);
            numeroarticulos.Add(numarticulos);
            numeropreposiciones.Add(numpreposiciones);



            /*
             * En esta sección empezamos a crear el JSON del glosario de acuerdo a la información extraida por cada Capítulo
             */
            for(int i=0; i < 27; i++)
            {
                //Por cada letra del abecedario creamos un nuevo Objeto para almacenar los datos encontrados de cada palabra cuya letra inical corresponda a una del abecedario (Corresponde al tercer nivel del JSON)
                letraABC = new Letra { letra=abecedario[i], preposiciones=preposicionexsalfabeto[i], adjetivos=adjetivosxalfabeto[i], articulos=articulosxalfabeto[i], pronombres=pronombresxalfabeto[i] };
                listaLetra.Add(letraABC);
            }
            //Adicionamos la lista de las palabras ordenadas por su letra inicial alfabéticamente y la información total de cada capitulo (Corresponde al segundo nivel del JSON)
            listaGlosarioCap.Add(glosarioCap = new GlosarioCapitulo
            {
                capitulo = "Capitulo " + numcap,
                Totalpreposiciones = numeropreposiciones[numcap - 1],
                Totalpronombres = numeropronombres[numcap - 1],
                Totalarticulos = numeroarticulos[numcap - 1],
                Totaladjetivos = numeroadjetivos[numcap - 1],
                Letra = listaLetra

            });

        }
        static void Main(string[] args)
        {
            //Variables para el control del número del capítulo, y la suma total de todo el libreo de los pronombres, adjetivos, articulos, preposiciones
            int numcapitulo, totalpronombre=0, totaladjetivo=0, totalarticulo=0, totalpreposicion=0;


            /*
             * Sección en la cual definimos las listas dinámicas para crear el segundo nivel de cada JSON discriminado por pronombres, adjetivos, artículos y preposiciones.
             * Adicional mente se crean las variables de la clase Capítulo para la creación del JSON discriminado.
             */
            List<Capitulo> pronombreCapitulo = new List<Capitulo>();
            List<Capitulo> adjetivoCapitulo = new List<Capitulo>();
            List<Capitulo> articuloCapitulo = new List<Capitulo>();
            List<Capitulo> preposicionCapitulo = new List<Capitulo>();
            List<Letra> letraAbecedario = new List<Letra>();
            Capitulo pronombre, adjetivos, articulo, preposicion;


            //En este for mandamos el número del capítulo a evaluar como parámetro a la funcion datos.
            for(int i = 1; i <= 35; i++)
            {
                datos(i);
            }


            //En este for empezamos a crear el segundo nivel de los JSON discriminados.
            for(int i = 0; i < 35; i++)
            {
                numcapitulo = i + 1;
                /*
                 * Se crean nuevos objetos por cada capítulo evaluado durante el proceso de extracción de datos.
                 * Se crea el segundo nivel del JSON discriminado por pronombres, adjetivos, artículos y preposiciones
                 */
                pronombre = new Capitulo { capitulo = "Capitulo "+ numcapitulo, numerodatos = numeropronombres[i] };
                adjetivos = new Capitulo { capitulo = "Capitulo " + numcapitulo, numerodatos = numeroadjetivos[i] };
                articulo = new Capitulo { capitulo = "Capitulo " + numcapitulo, numerodatos = numeroarticulos[i] };
                preposicion = new Capitulo { capitulo = "Capitulo " + numcapitulo, numerodatos = numeropreposiciones[i] };
                pronombreCapitulo.Add(pronombre);
                adjetivoCapitulo.Add(adjetivos);
                articuloCapitulo.Add(articulo);
                preposicionCapitulo.Add(preposicion);

            }




            /*
             * En esta sección realizamos la suma total de los pronombres, adjetivos, artículos y preposiciones que se encuentran en el libro
             */
            foreach(int suma in numeropronombres)
            {
                totalpronombre = totalpronombre + suma;
            }
            foreach(int suma in numeroadjetivos)
            {
                totaladjetivo = totaladjetivo + suma;
            }
            foreach(int suma in numeroarticulos)
            {
                totalarticulo = totalarticulo + suma;
            }
            foreach(int suma in numeropreposiciones)
            {
                totalpreposicion = totalpreposicion + suma;
            }


            /*
             * En esta sección se crea el primer nivel de cada uno de los JSON discriminados por pronombres, adjetivos, artículos y preposiciones y del GLOSARIO en general.
             */
            var jsonpronombres = new Pronombres
            {
                totalpronombres = totalpronombre,
                Pronombre = pronombreCapitulo
            };
            var jsonadjetivos = new Adjetivos
            {
                totaladjetivos = totaladjetivo,
                Adjetivo=adjetivoCapitulo
            };
            var jsonarticulos = new Articulos
            {
                totalarticulos = totalarticulo,
                Articulo = articuloCapitulo
            };
            var jsonpreposiciones = new Preposiciones
            {
                totalpreposiciones = totalpreposicion,
                Preposicion = preposicionCapitulo
            };
            var jsonglosario = new Glosario
            {
                nombre = "Libro Don Quijote",
                numeroPalabras = numeropalabras,
                Capitulo = listaGlosarioCap
            };


            /*
             * En esta sección se realiza la conversión a JSON de cada uno de los objetos creados para la generación de los JSON.
             * Se utiliza una librería llamada Newtonsoft la cual es propia de c# para la generación de los json
             */
            string json = JsonConvert.SerializeObject(jsonpronombres);
            string json2 = JsonConvert.SerializeObject(jsonadjetivos);
            string json3 = JsonConvert.SerializeObject(jsonarticulos);
            string json4 = JsonConvert.SerializeObject(jsonpreposiciones);
            string json5 = JsonConvert.SerializeObject(jsonglosario);


            /*
             * Finalmente se guardan los JSON en la ruta especificada para su importación en MONGODB y para su análisis.
             */
            System.IO.File.WriteAllText(@"D:\IMPORTANTE_NO_BORRAR\DOCUMENTOS\jsonpronombres.json", json);
            System.IO.File.WriteAllText(@"D:\IMPORTANTE_NO_BORRAR\DOCUMENTOS\jsonadjetivos.json", json2);
            System.IO.File.WriteAllText(@"D:\IMPORTANTE_NO_BORRAR\DOCUMENTOS\jsonarticulos.json", json3);
            System.IO.File.WriteAllText(@"D:\IMPORTANTE_NO_BORRAR\DOCUMENTOS\jsonpreposiciones.json", json4);
            System.IO.File.WriteAllText(@"D:\IMPORTANTE_NO_BORRAR\DOCUMENTOS\jsonglosario.json", json5);
            Console.WriteLine("Fin del programa");

            Console.ReadLine();
        }
    }
}
