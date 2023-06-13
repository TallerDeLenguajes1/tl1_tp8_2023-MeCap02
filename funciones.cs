namespace espacioFunciones{
    public class tarea{
        private int tareaID;
        private string desc;
        private int durac;
        private bool tareaCompletada;

        public string Descripcion{get=>desc;}
        public int Duracion{get=>durac;}
        public int IDTarea{get=>tareaID}
        public bool EstadoTareaCompletada{get=>tareaCompletada;set=>tareaCompletada=value;}
        
        public tarea(int id,string descripcion,int duracion,bool estado){
            this.tareaID=id;
            this.desc=descripcion;
            this.durac=duracion;
            this.tareaCompletada=estado;
        }
        public void mostrarDatos(){
            Console.WriteLine("\nID: "+this.tareaID);
            Console.WriteLine("\nDescripcion: "+this.desc);
            Console.WriteLine("\nDuracion (en minutos): "+this.durac);
        }
    }
}