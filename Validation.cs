using System;

namespace ProjetoStreamingCS
{
    public class Validation
    {
        static public int IntReadValidation(string mensage)
        {
            int dataInt = -1;
            while(true)
            {
               
                Console.Write(mensage);
                bool valid = int.TryParse(Console.ReadLine(), out dataInt); 

                if(valid)
                    return dataInt;
                else 
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Entrada inválida. Tente novamente.\n");
                    Console.ResetColor();
                }                  
            }        
        }

        static public float FloatReadValidation(string mensage)
        {
            float dataFloat = -1;
            while(true)
            {
                Console.Write(mensage);
                bool valid = float.TryParse(Console.ReadLine(), out dataFloat); 

                if(valid)
                    return dataFloat;
                else 
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Entrada inválida. Tente novamente.\n");
                    Console.ResetColor();
                }                  
            }  
        }

        static public string StringReadValidation(string mensage)
        {
            string dataString;
            while(true)
            {
                
                Console.Write(mensage);
                dataString = Console.ReadLine();
                if(string.IsNullOrEmpty(dataString))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Entrada inválida. Tente novamente.\n");
                    Console.ResetColor();
                }
                else 
                    return dataString;
                
            }
        }

        static public bool ReadYesOrNot()
        {
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
                        if(opcao == 1)
                            return true;
                        else
                            return false;
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
        }

        static public int OptionReadValidation(int lowerLimit, int upperLimit)
        {
            int opcao;
            while(true)
            {
                try{
                    Console.Write("\nOpção: ");
                    opcao = Convert.ToInt32(Console.ReadLine());
                    if(opcao >= lowerLimit && opcao <= upperLimit) 
                        return opcao;
                    else 
                        throw new FormatException();
                }
                catch(FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Opção inválida. Tente novamente.");
                    Console.ResetColor();
                }
            }
        }

        static public int OptionReadValidationWithEscape(int escape,int lowerLimit, int upperLimit)
        {
            int opcao;
            while(true)
            {
                try{
                    Console.Write("\nOpção: ");
                    opcao = Convert.ToInt32(Console.ReadLine());
                    if(opcao == escape || (opcao >= lowerLimit && opcao <= upperLimit))
                       return opcao;
                    else 
                        throw new FormatException();
                }
                catch(FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Opção inválida. Tente novamente.");
                    Console.ResetColor();
                }
            }
        }
    }
}