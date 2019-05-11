using System;
using System.IO;
using System.Text.RegularExpressions;



namespace panningforgold{
   

class panningforgold{
  
     static int rhtml=0;
     static int rapp=0;
     static int rip=0;
     static int remail=0;
     static int rsql=0;
     static int rbd=0;
     static int rhidden=0;
   
    static void Main(string[] args){
         	 

            string[] files = Directory.GetFiles(@".\", "*.html");

       

            foreach (string file in files)
            {
                
               string line=  File.ReadAllText(file);
                 Console.WriteLine(file);
                   
                Console.WriteLine("Comentarios HTML: "+ comentariosHTML(line)); 
                rhtml=rhtml+comentariosHTML(line);
                Console.WriteLine("Comentarios de la App: "+comentariosApp(line));
                rapp=rapp+comentariosApp(line);
                Console.WriteLine("Direcciones IP: "+ direccionIP(line));
                rip=rip+direccionIP(line);
                Console.WriteLine("Direcciones de correo electrónico: "+  direccionEmail(line));
                remail=remail+direccionEmail(line);
                Console.WriteLine("Consultas SQL: "+ consultasSQL(line));
                rsql=rsql+consultasSQL(line);
                Console.WriteLine("Cadenas de conexión a la base de datos : "+ conexBD(line));
                rbd=rbd+conexBD(line);
                Console.WriteLine("Campos ocultos de entrada: "+ camposOcultos(line));
                rhidden=rhidden+camposOcultos(line);
            }
            Resumen();
        
            
          
              
    }

    public static int  comentariosHTML(string line){
        string comment = "/<!--.+-->|<!--.|.-->/";
        int html= 0;
            
        MatchCollection matches = Regex.Matches(line, comment);
        
            //Console.WriteLine("Comentarios HTML: " + matches.Count);
        html= matches.Count;
        return html;
        
    }

    public static int comentariosApp(string line){
        //string comments = "/\\*([^*]|[\r\n]|(\\*+([^*/]|[\r\n])))*\\*+/";
        //string multiline = "/\\*([^*]|[\r\n]|(\\*+([^*/]|[\r\n])))*\\*/";
       // string  multi = "/\\*([^*]|[\r\n]|(\\*([^/]|[\r\n])))*\\*/"; 
       
       string all = "(/\\*([^*]|[\r\n]|(\\*+([^*/]|[\r\n])))*\\*+/)|(//.*)";
        int app = 0;
       
        //MatchCollection c = Regex.Matches(line, comments); 
       // MatchCollection a = Regex.Matches(line, multiline); 
        //MatchCollection b = Regex.Matches(line, multi); 
        MatchCollection matches = Regex.Matches(line, all); 
        //Console.WriteLine("Comentarios de la app: " + matches.Count); 
        app = matches.Count;
        return app;
    }

        public static int direccionIP(string line){
        string IP = "((((25[0-5])|(2[0-4]\\d)|([01]?\\d?\\d)))\\.){3}((((25[0-5])|(2[0-4]\\d)|([01]?\\d?\\d))))";
        int ip = 0;

        MatchCollection matches = Regex.Matches(line, IP);  
             
        //Console.WriteLine("Direcciones IP: " + matches.Count); 
        ip = matches.Count;
        return ip;  
    }
    
    public static int direccionEmail(string line){
        string email = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
        int mail = 0;

        MatchCollection matches = Regex.Matches(line, email);  
             
       // Console.WriteLine("Direcciones de correo electrónico: " + matches.Count); 
        mail= matches.Count;

        return mail;

    }

     public static int consultasSQL(string line){
        string sql = "SELECT";//jej
        int csql =0;
        MatchCollection matches = Regex.Matches(line, sql);  
             
       // Console.WriteLine("Consultas SQL: " + matches.Count); 
        csql = matches.Count;
        return csql;
    }

      public static int conexBD(string line){
        string conexBD = "Database=([^;]*);";
        int bd = 0;
       //tokenizada (?<Key>[0-9A-z\\s]+)=(?<Val>[0-9A-z\\s,]+?[0-9A-z\\s]+)
       
        MatchCollection matches = Regex.Matches(line, conexBD);  
             
        //Console.WriteLine("Cadenas de conexión a la Base de Datos: " + matches.Count); 
        bd = matches.Count;
        return bd;
    }

        public static int camposOcultos(string line){
        string hidden = "<input[^>]*type=\"(hidden)\"[^>]*>";
        int ocultos = 0;
       
        MatchCollection matches = Regex.Matches(line, hidden);  
             
        //Console.WriteLine("Campos ocultos de entrada: " + matches.Count); 
        ocultos= matches.Count;
        return ocultos;
    }

    public static void Resumen(){

            Console.WriteLine("Resumen");
            Console.WriteLine("Comentarios HTML: "+ rhtml);
            Console.WriteLine("Comentarios de la App: "+ rapp);
            Console.WriteLine("Direcciones IP: "+ rip);
            Console.WriteLine("Direcciones de correo electrónicp: "+ remail);
            Console.WriteLine("Consultas SQL: "+ rsql);
            Console.WriteLine("Cadenas de conexión a la base de datos: "+ rbd);
            Console.WriteLine("Campos ocultos de entrada: "+ rhidden);

    }
   

}
}

