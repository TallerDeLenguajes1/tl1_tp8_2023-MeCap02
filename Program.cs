using System.io

internal class Programa{
    private static void main(string[] args){
        Console.WriteLine("Ingrese el path en el que se encuentra el archivo: ");
        string? path=Console.ReadLine();
        while(path==null){
            Console.WriteLine("\nIngrese informacion valida: ");
            path=Console.ReadLine();
        }
        if(File.Exists(path)==false){
            File.Create(path);
        }
        using(StreamWriter listaDirectorios=new StreamWriter("index.csv",true)){
            foreach (string item in Directory.GetFiles(path)){
                listaDirectorios.WriteLine((string)file);
            }
        }
    }
}