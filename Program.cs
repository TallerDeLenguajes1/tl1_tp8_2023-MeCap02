using espacioFunciones;

internal class Programa{
    public static void interfazTareas(){
        int aux2,aux3,aux5;
        Console.WriteLine("===MENU===");
        Console.WriteLine("\n1=Mover\n2=Buscar\n3=Actualizar Sumario\n4=Mostrar");
        string? aux1=Console.ReadLine();
        while(!int.TryParse(aux1,out aux2)){
            Console.WriteLine("\nIngrese un dato valido");
            aux1=Console.ReadLine();
        }
        switch(aux2){
            case 1:
                Console.WriteLine("\nIngrese ID de la tarea completada");
                string? id=Console.ReadLine();
                while(!int.TryParse(id,out aux3)){
                    Console.WriteLine("\nIngrese un dato valido");
                    id=Console.ReadLine();
                }
                moverTareas(tareasPendientes,tareasCompletas,aux3);
                break;
            case 2:
                Console.WriteLine("\nIngrese ID de la tarea que desea buscar");
                string? descrip=Console.ReadLine();
                while(descrip==null){
                    Console.WriteLine("\nIngrese una descripcion valida");
                    descrip=Console.ReadLine();
                }
                buscarTarea(tareasPendientes,descrip);
                break;
            case 3:
                int duracionPendiente=0,duracionCompletada=0;
                foreach (tarea Tarea in tareasPendientes){duracionPendiente+=Tarea.Duracion;}
                foreach (tarea Tarea in tareasCompletas){duracionCompletada+=Tarea.Duracion;}
                using (StreamWriter sumario=new StreamWriter("sumario.txt")){
                    sumario.WriteLine(duracionCompletada+duracionPendiente);
                }
                break;
            case 4:
                Console.WriteLine("\nCual lista desea ver?\n1=Pendientes\n2=Completas");
                string? aux4=Console.ReadLine();
                while(!int.TryParse(aux4,out aux5)){
                    Console.WriteLine("\nIngrese un dato valido");
                    aux4=Console.ReadLine();
                }
                switch(aux5){
                    case 1:
                        Console.WriteLine("\n===Tareas Pendientes===");
                        foreach(tarea Tarea in tareasPendientes){
                            Tarea.mostrarDatos();
                        }
                        break;
                    case 2:
                        Console.WriteLine("\n===Tareas Completas===");
                        foreach(tarea Tarea in tareasCompletas){
                            Tarea.mostrarDatos();
                        }
                        break;
                    default:
                        Console.WriteLine("\nSucedio un problema");
                        break;
                }
                break;
            default:
                Console.WriteLine("\nSucedio un problema");
                break;
        }
    }

    public static void moverTareas(List<tarea>tareasPendientes,List<tarea>tareasCompletas,int aux3){
        tarea? elegirTarea=tareasPendientes.Find(Tarea=>Tarea.IDTarea==aux3);
        if(!(elegirTarea==null) && tareasPendientes.Remove(elegirTarea)){
            elegirTarea.EstadoTareaCompletada=true;
            tareasCompletas.Add(elegirTarea);
            return;
        }
    }

    public static void buscarTarea(List<tarea>tareasPendientes,string descrip){
        foreach(tarea Tarea in tareasPendientes){
            if(Tarea.Descripcion==descrip){
                Console.WriteLine("\n===TAREA ENCONTRADA===");
                Tarea.mostrarDatos();
                return;
            }
        }
    }

    private static void Main(string[] args){
        int tareasMax=(new Random()).Next(5,11);
        string[] descripciones={"A", "B", "C", "D", "E", "F", "G", "H", "I", "J"};
        var tareasPendientes=new List<tarea>();
        var tareasCompletas=new List<tarea>();
        for (int i = 0; i < tareasMax; i++){
            tareasPendientes.Add(new tarea(i+1,descripciones[i],(new Random()).Next(10,101),false));
        }
        do{
            interfazTareas(tareasPendientes,tareasCompletas);
        }while(Console.ReadKey().Key != ConsoleKey.Escape);
    }
}