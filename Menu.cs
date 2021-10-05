using System;
using System.Collections.Generic;
using Items.Menu;

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
                Console.WriteLine("  " + i + " - " + items[i].Name());
            }

            ReadOption();

        }

        private void ReadOption()
        {
            while(true)
            {
                Console.Write("\nOpção: ");
                opcao = Convert.ToInt32(Console.ReadLine());
                if(opcao >= 0 && opcao <items.Count)
                    break;
                else 
                    Console.Write("\nOpção inválida. Tente novamente.\n");
            }
            Console.Clear();

            items[opcao].Execute();
            
        
        }
    }
}