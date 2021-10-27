using System;
using View.Menu;

namespace Items{
        internal class ExitSystem : IItemMenu
        {
            
            public string Name(){
                return ("Encerrar o sistema");
            }

            public void Execute(){
                Console.WriteLine("Finalizando Sistema...\n");
                Console.WriteLine("Pressione qualquer tecla para encerrar.");
                Console.ReadKey(false);
                Console.Clear();
                Environment.Exit(1);
            }
        }
}
    