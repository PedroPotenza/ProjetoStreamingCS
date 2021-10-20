using System;
using System.IO;
using Entities;
using ProjetoStreamingCS;

namespace Items.Menu{

    internal class UpdatePremiumPlan : IItemMenu
    {
        
        public string Name(){
            return ("Plano Premium");
        }

        public void Execute(){
    
            Plan plan = new Plan(Plan.PlanType.Premium);
            plan.ShowPlan();
            
            Console.WriteLine("\nVocê deseja atualizar as informações do " + Name() + " ?");
            
            bool opcao = Validation.ReadYesOrNot();            
            
            if(opcao)
            {
                int dataInt;
                string dataString;
                float dataFloat;
                int opcaoLocal;

                Console.WriteLine("\nCaso queira que alguma propriedade se mantenha como estava antes, apenas digite -1\n");

                dataInt = Validation.IntReadValidation("\nQuantidade de dispositivos simultâneos: ");
                if(dataInt != -1 ) plan.simultaneousDevices = dataInt;

                dataString = Validation.StringReadValidation("Qualidade maxima de imagem: ");
                if(dataString != "-1" ) plan.maxQuality = dataString;

                dataInt = Validation.IntReadValidation("Tempo de fidelidade: ");
                if(dataInt != -1 ) plan.loyaltyFineTime = dataInt;

                dataFloat = Validation.FloatReadValidation("Multa de fidelidade: ");
                if(dataFloat != -1 ) plan.loyaltyFine = (int)dataFloat; 

                Console.Write("\nLimite de filmes: Ilimitado");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("\nApenas o plano Basico possui limitação de filmes.\n");
                Console.ResetColor();

                Console.Write("\nDownload de filmes: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("\t(1) Sim");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(" \t(2) Não");
                Console.ResetColor();

                opcaoLocal = Validation.OptionReadValidationWithEscape(-1,1,2); 

                 if(opcaoLocal!=-1)
                    plan.download = opcaoLocal.Equals(1) ? true : false;
                    //if(opcaoLocal == 1) plan.download = true; else plan.download = false;

                dataFloat = Validation.FloatReadValidation("Valor do plano: ");
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

                FileUtil.UpdateLine(@"./DataBase/Plans.txt", dataString, 3);

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