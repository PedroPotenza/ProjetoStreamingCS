using System;
using System.IO;
using Entities;

namespace Items.Menu{

    internal class UpdatePremiumPlan : IItemMenu
    {
        
        public string Name(){
            return ("Plano Premium");
        }

        public void Execute(){
    
            string filePath = @"./DataBase/Plans.txt";
            
            var reader = File.OpenText(filePath);
            
            reader.ReadLine();
            reader.ReadLine();

            string line = reader.ReadLine();
            string[] atribute = line.Split(';');
            Plan plan = new Plan(atribute[0], float.Parse(atribute[1])/100, atribute[2], int.Parse(atribute[3]), float.Parse(atribute[4])/100, int.Parse(atribute[5]), int.Parse(atribute[6]), bool.Parse(atribute[7]));
            plan.ShowPlan();
            
            Console.WriteLine("\nVocê deseja atualizar as informações do " + Name() + " ?");
            
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\t(1) Sim");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" \t(2) Não");
            Console.ResetColor();

            int opcao;
            while(true)
            {
                Console.Write("\nOpção: ");
                opcao = Convert.ToInt32(Console.ReadLine());
                if(opcao >= 1 && opcao < 3)
                    break;
                else 
                    Console.Write("\nOpção inválida. Tente novamente.\n");
            }            
            
            if(opcao == 1)
            {
                Console.WriteLine("ler as informações");
            }
            if(opcao == 2)
            {
                Console.WriteLine("\nPressione qualquer tecla para retornar ao menu principal.");
            }
        }
    }
    
}