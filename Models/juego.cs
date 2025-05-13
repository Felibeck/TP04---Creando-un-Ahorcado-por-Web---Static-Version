namespace TP04_Ahorcado;
static public class juego{
    static public string palabra {get; private set;} 
    static public string palabraVacia {get; private set;}
    static public List<char> letrasUsadas {get; private set;}
    static public int errores {get;set;}
    //falta hacer un while que mientas el contador de errores (este cuenta la cantidad de veces que el metodo comprobarletra dio false) no llegue a 6, el bool gano sea true. Si pasa de 6 es false, el usuario pierde el juego 

    static public void inicializarJuego()
    {
        palabra = "CASA";
        palabraVacia = "____";
        letrasUsadas = new List<char>();
        errores = 0;
    }
    
     static public bool comprobarLetra(char letra)
     {
        bool aux = false;
        char[] arrayPalabraVacia = palabraVacia.ToCharArray();
        for (int i = 0; i < palabra.Length; i++)
        {
        if (palabra[i] == letra)
        {
            arrayPalabraVacia[i] = letra;
            aux = true;
        }
        }
       palabraVacia = new string(arrayPalabraVacia);
       return aux;
     }
     static public bool comprobarPalabra(string Palabra)
    {
        bool aux = false;

        if(palabra == Palabra)
        {
            aux = true;    
        }
        return aux;
    }
}