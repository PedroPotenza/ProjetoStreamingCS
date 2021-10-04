using System;
using System.Collections.Generic;

namespace ProjetoStreamingCS
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();

            menu.Add(new ExitSystem());
            menu.Add(new RegisterClient());
            menu.Add(new RegisterMovie());
            menu.Add(new RegisterPlan());
            menu.Add(new RegisterContract());
            menu.Add(new WatchMovie());
            menu.Add(new CancelContract());
            menu.Add(new GenerateBill());
            menu.Add(new ShowClient());
            menu.Add(new ExcessClients());
            menu.Add(new FrequencyMovie());

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
