using System;
using System.IO;
using System.Text.RegularExpressions;



namespace panningforgold{
class panningforgold{

    static void Main(string[] args){
         	

                string line = File.ReadAllText("C://Users//gomez//Desktop//panningforgold//05.html");
                    comentariosHTML(line);
                    comentariosApp(line);
                    direccionIP(line);
                    direccionEmail(line);
                    consultasSQL(line);
                    conexBD(line);
                    camposOcultos(line);
               
    }

    public static void comentariosHTML(string line){
        string comment = "<!-- (.*) -->";
            
        MatchCollection matches = Regex.Matches(line, comment);
        
            Console.WriteLine("Comentarios: " + matches.Count);
        
    }

    public static void comentariosApp(string line){
        string comments = " (/\\*([^*]|[\r\n]|(\\*+([^*/]|[\r\n])))*\\*+/)|(//.*)";
       
        MatchCollection matches = Regex.Matches(line, comments);  
             
        Console.WriteLine("Comentarios de la app: " + matches.Count); 

    }

        public static void direccionIP(string line){
        string IP = "((((25[0-5])|(2[0-4]\\d)|([01]?\\d?\\d)))\\.){3}((((25[0-5])|(2[0-4]\\d)|([01]?\\d?\\d))))";
       
        MatchCollection matches = Regex.Matches(line, IP);  
             
        Console.WriteLine("Direcciones IP: " + matches.Count); 

    }
    
    public static void direccionEmail(string line){
        string email = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
       
        MatchCollection matches = Regex.Matches(line, email);  
             
        Console.WriteLine("Direcciones de correo electrónico: " + matches.Count); 

    }

     public static void consultasSQL(string line){
        string email = "SELECT";//jej
       
        MatchCollection matches = Regex.Matches(line, email);  
             
        Console.WriteLine("Consultas SQL: " + matches.Count); 
    }

      public static void conexBD(string line){
        string conexBD = "Database=([^;]*);";
       //tokenizada (?<Key>[0-9A-z\\s]+)=(?<Val>[0-9A-z\\s,]+?[0-9A-z\\s]+)
       
        MatchCollection matches = Regex.Matches(line, conexBD);  
             
        Console.WriteLine("Cadenas de conexión a la Base de Datos: " + matches.Count); 
    }

        public static void camposOcultos(string line){
        string hidden = "<input[^>]*type=\"(hidden)\"[^>]*>";
       
       
        MatchCollection matches = Regex.Matches(line, hidden);  
             
        Console.WriteLine("Campos ocultos de entrada: " + matches.Count); 
    }


   

}
}

