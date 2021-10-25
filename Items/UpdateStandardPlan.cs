using System;
using System.IO;
using Entities;
using InputValidation;
using ProjetoStreamingCS;

namespace Items.Menu{

    internal class UpdateStandardPlan : IItemMenu
    {
        
        public string Name(){
            return ("Plano Padrão");
        }

        public void Execute(){
            
            Plan plan = new Plan(Plan.PlanType.Standard);
            plan.ShowPlan();

            Console.WriteLine("\nVocê deseja atualizar as informações do " + Name() + " ?");
            
            bool opcao = Validation.ReadYesOrNot();

            if(opcao)
            {
                int dataInt;
                string dataString;
                float dataFloat;

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nCaso queira que alguma propriedade se mantenha como estava antes, apenas digite -1\n");
                Console.ResetColor();

                dataInt = Validation.GenericRead<int>("\nQuantidade de dispositivos simultâneos: ");
                if(dataInt != -1 ) plan.simultaneousDevices = dataInt;

                dataString = Validation.StringRead("Qualidade maxima de imagem: ");
                if(dataString != "-1" ) plan.maxQuality = dataString;

                dataInt = Validation.GenericRead<int>("Tempo de fidelidade: ");
                if(dataInt != -1 ) plan.loyaltyFineTime = dataInt;

                dataFloat = Validation.GenericRead<float>("Multa de fidelidade: ");
                if(dataFloat != -1 ) plan.loyaltyFine = (int)dataFloat; 

                Console.Write("Limite de filmes: Ilimitado");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("\nApenas o plano Basico possui limitação de filmes.\n");
                Console.ResetColor();

                Console.Write("Download de filmes: Não");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("\nApenas o plano Premium pode permitir download de filmes.\n");
                Console.ResetColor();
                
                dataFloat = Validation.GenericRead<float>("Valor do plano: ");
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

                FileUtil.UpdateLine(@"./DataBase/Plans.txt", dataString, 2);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n\tPlano Atualizado com Sucesso!\n");
                Console.ResetColor();
            }
            else
            {
                FileUtil.BackToMenu();
            }        
        }
    }
    
}