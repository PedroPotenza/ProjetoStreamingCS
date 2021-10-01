using System;

namespace ProjetoStreamingCS
{
    internal class Item : IItem
    {
        private string name;

        public Item(string itemName)
        {
            name = itemName;
        }

        public void Name(){
            Console.WriteLine("---- " + name + " ----");
        }

        public void Execute(){
            Console.WriteLine("Opção '"+ name +"' selecionada\n");
        }
    }
}