namespace TP04_Ahorcado;
 public class juego{
     public string palabra {get; private set;} 
     public string palabraVacia {get; private set;}
     public List<char> letrasUsadas {get; private set;}
     public int errores {get;set;}
    //falta hacer un while que mientas el contador de errores (este cuenta la cantidad de veces que el metodo comprobarletra dio false) no llegue a 6, el bool gano sea true. Si pasa de 6 es false, el usuario pierde el juego 

     public void inicializarJuego()
    {
        palabra = "CASA";
        palabraVacia = "____";
        letrasUsadas = new List<char>();
        errores = 0;
    }
    
      public void comprobarLetra(char letra)
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
        if(aux == false){

            errores++;
            letrasUsadas.Add(letra);
        }
       palabraVacia = new string(arrayPalabraVacia);
     }
      public bool comprobarPalabra(string Palabra)
    {
        bool aux = false;

        if(palabra == Palabra)
        {
            aux = true;    
        }
        return aux;
    }
}