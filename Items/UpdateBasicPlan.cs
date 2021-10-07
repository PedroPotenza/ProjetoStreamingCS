using System;
using System.IO;
using Entities;

namespace Items.Menu{

    internal class UpdateBasicPlan : IItemMenu
    {
        
        public string Name(){
            return ("Plano Basico");
        }

        public void Execute(){
            
            string filePath = @"./DataBase/Plans.txt";
            
            var reader = File.OpenText(filePath);
            
            string line = reader.ReadLine();
            string[] atribute = line.Split(';');

            Plan plan = new Plan(atribute[0], int.Parse(atribute[1]), atribute[2], int.Parse(atribute[3]), int.Parse(atribute[4]), int.Parse(atribute[5]), int.Parse(atribute[6]), bool.Parse(atribute[7]));
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
                try{
                    Console.Write("\nOpção: ");
                    opcao = Convert.ToInt32(Console.ReadLine());
                    if(opcao >= 1 && opcao <= 2)
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

            if(opcao == 1)
            {
                int dataInt;
                string dataString;
                float dataFloat;

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nCaso queira que alguma propriedade se mantenha como estava antes, apenas digite -1");
                Console.ResetColor();

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

                Console.Write("Limite de filmes: ");
                dataInt = Convert.ToInt32(Console.ReadLine());
                if(dataInt != -1 ) plan.maxMovies = dataInt;

                Console.Write("Download de filmes: Não");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("\nApenas o plano Premium pode permitir download de filmes.\n");
                Console.ResetColor();
                
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

                dataString = string.Join("; ", newLine);

                plan.updateLine(dataString, 1);

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