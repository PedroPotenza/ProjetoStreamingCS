using System;
using Items.Menu;

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
            menu.Add(new UpdatePlan());
            menu.Add(new RegisterContract());
            menu.Add(new WatchMovie());
            menu.Add(new CancelContract());
            menu.Add(new GenerateBill());
            menu.Add(new ShowClient());
            menu.Add(new ExcessClients());
            menu.Add(new FrequencyMovie());

            bool start = true;

            while(true){
                if(!start)
                    Console.ReadKey(false);
                start = false;
                Console.Clear();
                menu.ShowMenu("Sistema Streaming");
                
            };

            //TODO: Sistema de login para diferenciar Admins de Clientes (Admin pode cadastrar filme, criar planos e tals)
            
            //FIX: ESC + qualquer botão no menu principal
            //FIX: ENTER no menu principal
            
        }
    }
}
