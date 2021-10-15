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
            Plan plan = new Plan(atribute[0], int.Parse(atribute[1]), atribute[2], int.Parse(atribute[3]), int.Parse(atribute[4]), int.Parse(atribute[5]), int.Parse(atribute[6]), bool.Parse(atribute[7]));
            plan.ShowPlan();
            
            Console.WriteLine("\nVocê deseja atualizar as informações do " + Name() + " ?");
            
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\v\t(1) Sim");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" \t(2) Não");
            Console.ResetColor();

            int opcao;
            while(true)
            {
                Console.Write("\nOpção: ");
                opcao = Convert.ToInt32(Console.ReadLine());
                if(opcao >= 1 && opcao <= 2)
                    break;
                else 
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("\n\tOpção inválida. Tente novamente.\n");
                    Console.ResetColor();
            }            
            
            if(opcao == 1)
            {
                int dataInt;
                string dataString;
                float dataFloat;

                Console.WriteLine("\nCaso queira que alguma propriedade se mantenha como estava antes, apenas digite -1");

                Console.Write("\nQuantidade de dispositivos simultâneos: ");
                dataInt = Convert.ToInt32(Console.ReadLine());
                if(dataInt != -1 ) plan.simultaneousDevices = dataInt;

                Console.Write("Qualidade maxima de imagem: ");
                dataString = Console.ReadLine();
                if(dataString != "-1" ) plan.maxQuality = dataString;

                Console.Write("Tempo de fidelidade: ");
                dataInt = Convert.ToInt32(Console.ReadLine());
                if(dataInt != -1 ) plan.loyaltyFineTime = dataInt;

                Console.Write("Multa de fidelidade: ");
                dataFloat = float.Parse(Console.ReadLine());
                if(dataFloat != -1 ) plan.loyaltyFine = (int)dataFloat; 

                Console.Write("Limite de filmes: Ilimitado");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("\nApenas o plano Basico possui limitação de filmes.\n");
                Console.ResetColor();

                Console.Write("Download de filmes: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("\t(1) Sim");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(" \t(2) Não");
                Console.ResetColor();

                while(true)
                {
                    Console.Write("\nOpção: ");
                    opcao = Convert.ToInt32(Console.ReadLine());
                    if(opcao == -1 || (opcao >= 1 && opcao <= 2)) break;
                    else Console.Write("\nOpção inválida. Tente novamente.\n");
                } 

                 if(opcao!=0)
                    if(opcao == 1) plan.download = true; else plan.download = false;

                Console.Write("Valor do plano: ");
                dataFloat = float.Parse(Console.ReadLine());
                if(dataFloat != -1 ) plan.valor = (int)dataFloat; 
    
                string[] newLine = {
                    plan.name, 
                    plan.valor.ToString(), 
                    plan.maxQuality,
                    plan.simultaneousDevices.ToString(),
                    plan.loyaltyFine.ToString(),
                    plan.loyaltyFineTime.ToString(), 
                    plan.maxMovies.ToString(),
                    plan.download.ToString()
                    };

                dataString = string.Join(";", newLine);

                plan.UpdateLine(dataString, 3);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n\tPlano Atualizado com Sucesso!\n");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("\nPressione qualquer tecla para retornar ao menu principal.");
            }
        }
    }
    
}