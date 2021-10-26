using System;
using Home.Items;
using UpdatePlan.Items;

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
            menu.Add(new UpdatePlanMenu());
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
            //TOFIX:
            //BUG:
            //UGLY:
            //IDEA:
            //ANNOTATION:
            //OBS:
            //REVIEW:
            //LOOK:
            //OPTIMIZE:

            
        }
    }
}
