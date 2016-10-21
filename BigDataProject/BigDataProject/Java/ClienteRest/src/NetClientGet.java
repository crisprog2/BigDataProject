import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.File;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.URL;
import java.nio.charset.Charset;
import java.util.StringTokenizer;

/**
 * Clase que lee todos los capitulos del libro Don Quijote de la Mancha y cuenta los verbos
 * por cada uno de los capitulos, generando como salida una estructura JSON
 * 
 * @author Juan Carlos Fuyo González
 */
public class NetClientGet {
    
    /**
     * Contador de verbos por capitulo, se suma 1 cada vez que se encuentra
     * un verbo y se deja en 0 cuando inicial un nuevo capitulo
     */
    private int numVerbosCap;
    /**
     * Cuenta el total de verbos en todos los capitulos del libro
     */
    private int totalVerbos;
    /**
     * Contador de las 60 palabras admitidas por minuto por la API
     * vuelve a 0 cuando llega a 60
     */
    private int numPalabras;
    /**
     * Array de 35 posiciones con el total de verbos por cada capitulo
     */
    private int[] verbosCap;
    /**
     * Tiempo acumulado en 60 peticiones a la API, este se resta de un minuto
     * y el resultado es el tiempo que queda en espera la aplicación
     */
    private long acumulado;
    
    /**
     * Constructor de la clase que inicializa los atributos globales
     */
    public NetClientGet(){
            this.numVerbosCap = 0;
            this.verbosCap = new int[35];
            this.totalVerbos = 0;
            this.numPalabras = 0;
            this.acumulado = 0;
    }
    
    /**
     * Metodo Main de la aplicación
     * @param args
     * @throws IOException
     */
    public static void main(String[] args) throws IOException{
            NetClientGet obj = new NetClientGet();
            obj.init();//llamada al metodo init que inicia la lectura de los ficheros
    }
    
    /**
     * Metodo que se encarga de iniciar la lectura de los capitulos
     */
    public void init(){
            for(int i=1; i<=35;i++){
                    this.numVerbosCap = 0;//se define en 0 cada vez que inicia un capitulo
                    String file = "C:/Users/User/Documents/JUANCARLOS/quijote/CAPITULO "+i+".txt";
                    try {
                            this.leerCapitulo(file);//llamada al metodo leer capitulo
                            this.verbosCap[i-1] = this.numVerbosCap;
                            this.totalVerbos = this.totalVerbos+this.verbosCap[i-1];
                            this.constructCapTxt(i);//llamada al metodo que construye el json de cada capitulo
                    } catch (IOException e) {
                            e.printStackTrace();
                    }
            }
            this.construirTxt();// llamada al metodo que construye el json final de todos los capitulos
    }
    
    /**
     * Metodo que construye el json final con todos los capitulos
     */
    public void construirTxt(){
            String ruta = "C:/Users/User/Documents/JUANCARLOS/quijote/salida.txt";
    File archivo = new File(ruta);
    BufferedWriter bw;
    try{
            if(archivo.exists()) {
            bw = new BufferedWriter(new FileWriter(archivo));
            System.out.println("El fichero de texto ya estaba creado.");
        } else {
            bw = new BufferedWriter(new FileWriter(archivo));
            System.out.println("Acabo de crear el fichero de texto.");
        }
            bw.write("{\"totalvervos\":"+this.totalVerbos+",\"Verbos\":[");
            for(int i=2; i<=35;i++){
                    if(i==35){
                            bw.write("{\"capitulo\":\"Capitulo "+i+"\",\"numeroverbos\":"+this.verbosCap[i-1]+"}");
                    }else{
                            bw.write("{\"capitulo\":\"Capitulo "+i+"\",\"numeroverbos\":"+this.verbosCap[i-1]+"},");
                    }
            }
            bw.write("]}");
        bw.close();
    }catch(IOException e){
            //Error
    }
    }
    
    /**
     * Metodo que construye el json por cada capitulo
     * @param numCapitulo numero del capitulo actual
     */
    public void constructCapTxt(int numCapitulo){ 
        String ruta = "C:/Users/User/Documents/JUANCARLOS/quijote/capitulo"+numCapitulo+".txt";
        File archivo = new File(ruta);
        BufferedWriter bw;
        try{
            if(archivo.exists()) {
                bw = new BufferedWriter(new FileWriter(archivo));
                System.out.println("El Capitulo ya estaba creado. Capitulo: "+numCapitulo);
            } else {
                bw = new BufferedWriter(new FileWriter(archivo));
                System.out.println("Acabo de crear el fichero de capitulo: "+numCapitulo);
            }
            if(numCapitulo==35){
                bw.write("{\"capitulo\":\"Capitulo "+numCapitulo+"\",\"numeroverbos\":"+this.verbosCap[numCapitulo-1]+"}");
            }else{
                bw.write("{\"capitulo\":\"Capitulo "+numCapitulo+"\",\"numeroverbos\":"+this.verbosCap[numCapitulo-1]+"},");
            }
            bw.close();
        }catch(IOException e){
            //Error
        }
    }
    
    /**
     * Metodo que lee cada capitulo separando las palabras, ajusta el tiempo 
     * para realizar 60 solicitudes por minuto, que es la restriccion de la API 
     * @param file
     * @throws IOException
     */
    public void leerCapitulo(String file) throws IOException{
        FileReader f = new FileReader(file);
        BufferedReader linea = new BufferedReader(f);
        long TInicio, TFin, tiempo;
        //ciclo do while que lee cada capitulo linea por linea
        do {
            String palabra;
            //objeto que separa las palabras
            StringTokenizer st = new StringTokenizer (linea.readLine());
            while (st.hasMoreTokens()){
                TInicio = System.currentTimeMillis();//marca de tiempo donde inicia cada palabra
                numPalabras++;
                palabra = this.cleanWord(st);//llamada al metodo que formatea cada palabra
                System.out.println ("Palabra: " + palabra);
                this.leerPalabra(palabra);//metodo que valida cada palabra en la API Apicultur
                TFin = System.currentTimeMillis();//marca de tiempo donde finaliza cada palabra
                tiempo = TFin - TInicio;//tiempo tomado por cada palabra
                acumulado = acumulado + tiempo;//tiempo acumulado por las 60 palabras
                if(numPalabras>=60){//verifica si se han enviado 60 palabras
                    try {
                        if(acumulado<=65000){
                            System.out.println("esperar: "+((65000-acumulado)/1000)+"segundos");
                            Thread.sleep(65000-acumulado);//el programa espera lo que falta para un minuto
                        }else{
                            System.out.println("esperar: "+((acumulado-65000)/1000)+"segundos");
                            Thread.sleep(acumulado-65000);//el programa espera lo que falta para un minuto
                        }
                    } catch (InterruptedException e) {
                        e.printStackTrace();
                    }
                    numPalabras = 0;//se asigna 0 el contador de las 60 palabras
                    acumulado = 0;//se asigna a 0 el tiempo acumulado de las 60 palabras
                }
            }
        }while(linea.readLine()!=null);
        linea.close();
    }
    
    /**
     * Metodo que valida cada palabra en la API Apicultur para saber si es un verbo
     * @param word
     */
    public void leerPalabra(String word){
            try {
                    URL url = new URL("https://store.apicultur.com/api/IdentificaVerbo/1.0.0/"+word);
                    HttpURLConnection conn = (HttpURLConnection) url.openConnection();
                    conn.setRequestMethod("GET");
                    //Clave proporcionada por Apicultur para consumir el servicio
                    conn.setRequestProperty("Authorization", "Bearer A6XX1Q2gXfykSz7ZBjFfNW1QmdAa");
                    conn.setRequestProperty("Accept", "application/json");
                    if (conn.getResponseCode() != 200) {//verifica si es un respuesta no exitosa
                            throw new RuntimeException("Failed : HTTP error code : "
                                            + conn.getResponseCode());
                    }
                    BufferedReader br = new BufferedReader(new InputStreamReader((conn.getInputStream())));
                    String output;//cadena de respuesta de la API en formato JSON
                    while ((output = br.readLine()) != null) {
                            System.out.println(output);
                            this.validWord(output);//llamada al metodo que valida si la respuesta indica
                            //que la palabra es un verbo o no
                    }

                    conn.disconnect();//desconexión de la API

              } catch (NullPointerException e) {

                    e.printStackTrace();

              } catch (IOException e) {

                    e.printStackTrace();

              }
    }
    
    /**
     * Metodo que valida la respuesta de la API para verificar si la palabra es un verbo
     * @param respuesta
     */
    public void validWord(String respuesta){
            if(respuesta.substring(11,12).equals("1")){
                    this.numVerbosCap++;//si es un verbo incrementa en 1 el contador de verbos por capitulo
            }
    }
    
    /**
     * Metodo que formatea cada palabra, eliminando caracteres especiales y arreglando las tildes
     * que son necesarias para algunos verbos, ejemplo: comí, corrió, saltarás
     * @param st
     * @return  String palabra
     */
    public String cleanWord(StringTokenizer st){
        String palabra = st.nextToken();
        Charset.forName("UTF-8").encode(palabra);
        int c= palabra.length(); 
        for (int contador =0; contador<c; contador++){ 
            switch (palabra.charAt(contador)) {
                case '¿':
                    palabra = palabra.replace('¿',' ');
                    break;
                case 'ï':
                    palabra = palabra.replace('ï',' ');
                    break;
                case '»':
                    palabra = palabra.replace('»',' ');
                    break;
                case ',':
                    palabra = palabra.replace(',',' ');
                    break;
                case '.':
                    palabra = palabra.replace('.',' ');
                    break;
                case '(':
                    palabra = palabra.replace('(',' ');
                    break;
                case ')':
                    palabra = palabra.replace(')',' ');
                    break;
                case ':':
                    palabra = palabra.replace(':',' ');
                    break;
                case ';':
                    palabra = palabra.replace(';',' ');
                    break;
                case '-':
                    palabra = palabra.replace('-',' ');
                    break;
                default:
                    break;
            }
        } 
        palabra = palabra.replace(" ","");
        return palabra;
    }
}
