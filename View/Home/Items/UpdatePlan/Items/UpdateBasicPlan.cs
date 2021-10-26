using System;
using Entities;
using InputValidation;
using Utils.FileUtil;
using View.Menu;

namespace UpdatePlan.Items{

    internal class UpdateBasicPlan : IItemMenu
    {
        
        public string Name(){
            return ("Plano Basico");
        }

        public void Execute(){
                  
            Plan plan = new Plan(Plan.PlanType.Basic);
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
                
                dataInt = Validation.GenericRead<int>("Quantidade de dispositivos simultâneos: ");
                if(dataInt != -1 ) plan.simultaneousDevices = dataInt;
            
                dataString = Validation.StringRead("Qualidade maxima de imagem: ");
                if(dataString != "-1" ) plan.maxQuality = dataString;

                dataInt = Validation.GenericRead<int>("Tempo de fidelidade: ");
                if(dataInt != -1 ) plan.loyaltyFineTime = dataInt;

                dataFloat = Validation.GenericRead<float>("Multa de fidelidade: ");
                if(dataFloat != -1 ) plan.loyaltyFine = (int)dataFloat;

                dataInt = Validation.GenericRead<int>("Limite de filmes: ");
                if(dataInt != -1 ) plan.maxMovies = dataInt;

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

                FileUtil.UpdateLine(@"./DataBase/Plans.txt", dataString, 1);

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