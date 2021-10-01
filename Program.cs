using System;
using System.Collections.Generic;

namespace ProjetoStreamingCS
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            bool start = true;

            List<Client> clients = new List<Client>();

            while(true){
                if(!start)
                    Console.ReadKey(false);
                start = false;
                Console.Clear();
                menu.ShowMenu();
                
            };
            

            
        }
    }
}
