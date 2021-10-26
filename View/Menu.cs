using System;
using System.Collections.Generic;
using View.Menu;

namespace ProjetoStreamingCS
{
    internal class Menu
    {
        private int opcao;
        private List<IItemMenu> items = new List<IItemMenu>();

        public void Add(IItemMenu item)
        {
            this.items.Add(item);
        }

        public void ShowMenu(string title)
        {
            Console.WriteLine("---- " + title + " ----\n");
            for(int i=0; i < items.Count; i++ )
            {
                Console.WriteLine("  " + (i+1) + " - " + items[i].Name());
            }

            ReadOption();

        }

        private void ReadOption()
        {
            while(true)
            {
                try
                {
                    Console.Write("\nOpção: ");
                    opcao = Convert.ToInt32(Console.ReadLine());
                    if(opcao >= 1 && opcao <items.Count+1)
                        break;
                    else 
                        throw new FormatException();
                }
                catch(FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("\n\tOpção inválida. Tente novamente.\n");
                    Console.ResetColor();
                }
            }
            Console.Clear();

            items[opcao-1].Execute();
            
        
        }

    }
}