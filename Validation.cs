using System;

namespace InputValidation
{
    /// <summary>
    /// Do all the validations of inputs to avoid Null inputs or Invalid Formats.
    /// If any input be invalid, the same error message is shown and the user's keep on a loop of read data waiting a valid input.
    /// </summary>    
    static public class Validation
    {
        /// <summary>
        /// Read a input and validate with a generic TryParse. The function keep a loop where's need a valid data to exit.
        /// Don't validate strings, for that we have StringRead().</summary>
        /// <param name="message"> Write on console before read the input. </param>
        /// <typeparam name="T"> The type read and validade by the fuction.</typeparam>
        /// <exception cref="ApplicationException">If something really strange happen.</exception>
        /// <returns> A valid data of type T</returns>
        
        static public T GenericRead<T>(string message) where T : struct
        {
            bool isValid = false;
            while (!isValid)
            {
                Console.Write(message);

                string input = Console.ReadLine();
                isValid = input.TryParse(out T validatedOutput);
                //isValid = InputValidation.TryParse(input, out T validatedOutput);

                if (isValid)
                {
                    return validatedOutput;
                }
                else
                {
                    ShowErrorMessage();
                }
            }

            throw new ApplicationException("Method shouldn't reach this point. Something terribly wrong happended.");
        }

        public static bool TryParse<T>(this string input, out T output)
        {
            var type = typeof(T);
            var temp = default(T);
            var method = type.GetMethod(
                "TryParse",
                new[]
                    {
                        typeof (string),
                        Type.GetType(string.Format("{0}&", type.FullName))
                    });

            object[] args = new object[] { input, temp };
            bool ret = (bool)method.Invoke(null, args);

            output = (T)args[1];
            return ret;
        }

        ///<summary>Just show a red message: "Entrada inválida. Tente novamente".</summary> 
        private static void ShowErrorMessage()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Entrada inválida. Tente novamente\n");
            Console.ResetColor();
        }

        //reference https://github.com/JeffersonAmori/GenericValidation/blob/master/GenericValidation/InputValidation.cs
        //OPTIMIZE: maybe make a override of GenericRead() to validate string? 
        //look: a new idea of parameter: max char of a string? and a default value to string without this limitation 

        /// <summary>
        /// Read a string input and validate. The function keep a loop where's need a valid data to exit.
        /// Validate if the string data's <c>null</c>.</summary>
        /// <param name="message"> Write on console before read the input. </param>
        /// <returns> A valid string data</returns>
        static public string StringRead(string message)
        {
            string dataString;
            while(true)
            {
                Console.Write(message);
                dataString = Console.ReadLine();
                if(string.IsNullOrEmpty(dataString))
                    ShowErrorMessage();
                else 
                    return dataString;               
            }
        }

        /// <summary>
        /// Write a green "(1) Sim" and red "(2) Não", after that read a input between 1 and 2. The user's keep on a loop waiting a valid input.
        /// </summary>
        /// <returns>return <c>true</c> if the user write 1 and <c>false</c> if write 2.</returns>
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
                Console.Write("\nOpção: ");
                string read = Console.ReadLine();
                if(int.TryParse(read, out opcao) && opcao >= 1 && opcao <= 2)
                {                  
                    if(opcao == 1)
                        return true;
                    else
                        return false;   
                }
                else 
                    ShowErrorMessage();              
            }
        }

        /// <summary>
        /// Read a range input option.The user's keep on a loop waiting a valid input. 
        /// </summary>
        /// <param name="lowerLimit">lower valid input of range (this value's a valid.)</param>
        /// <param name="upperLimit">upper valid input of range (this value's a valid.)</param>
        /// <returns>The value selected by user</returns>
        static public int OptionRead(int lowerLimit, int upperLimit)
        {
            int opcao;
            while(true)
            {     
                Console.Write("\nOpção: ");
                string read = Console.ReadLine();
                if(int.TryParse(read, out opcao) && opcao >= lowerLimit && opcao <= upperLimit) 
                    return opcao;
                else 
                    ShowErrorMessage();
            }
        }

        /// <summary>
        /// Read a range input option, with a espace possibilite.The user's keep on a loop waiting a valid input.
        /// </summary>
        /// <param name="lowerLimit">lower valid input of range (this value's a valid.)</param>
        /// <param name="upperLimit">uper valid input of range (this value's a valid.)</param>
        /// <param name="escape">a escape value of range (normally use for moments where a default data is something relevant)</param>
        /// <returns></returns>
        static public int OptionRead(int lowerLimit, int upperLimit, int escape)
        {
            int opcao;
            while(true)
            {
                
                Console.Write("\nOpção: ");
                string read = Console.ReadLine();
                if(int.TryParse(read, out opcao) && (opcao == escape || (opcao >= lowerLimit && opcao <= upperLimit)))
                    return opcao;
                else 
                    ShowErrorMessage();
            }
        }
    }
}