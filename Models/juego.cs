namespace TP04_Ahorcado;
public class juego{
    public string palabra {get; private set;} 
    public int intentos {get; private set;} 
    public string palabraVacia {get; private set;}


    public juego(string palabra, int intentos, string palabraVacia)
    {
        this.palabra = "CASA";
        this.intentos = intentos;
        this.palabraVacia = "____";
    }
    public bool comprobarLetra(char letra)
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