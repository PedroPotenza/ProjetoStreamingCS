using System;
using System.IO;
using Entities;
using ProjetoStreamingCS;

namespace Items.Menu{

    internal class RegisterClient : IItemMenu
    {
        
        public string Name(){
            return ("Cadastrar Cliente");
        }

        public void Execute(){

            string filePath = @"./DataBase/Clients.txt";

            string cpfLocal;
            Console.WriteLine("---- " + Name() + " ----\n");
            Console.Write("CPF: ");
            cpfLocal = Console.ReadLine();

            //seria possivel fazer uma função dentro de Client.cs fazendo essa busca(se o cliente existe)? (e consequentemente instanciando um client dentro da classe client)
            //o retorno seria o cliente ja cadastrado
            
            var lineCount = 0;
            string line;
            using (var reader = File.OpenText(filePath))
            {
                
                while ((line = reader.ReadLine()) != null)
                {
                    
                    lineCount++;
                    string[] atribute = line.Split(';');
                    Client client = new Client(int.Parse(atribute[0]),atribute[1],atribute[2],atribute[3],atribute[4],int.Parse(atribute[5]));
                    if(client.cpf == cpfLocal){
                       
                        client.ShowClient();
                        Console.WriteLine("Você deseja atualizar os dados do(a) cliente \"" + client.name + "\" ?");
            
                        bool opcao = Validation.ReadYesOrNot();
                        
                        if(opcao)
                        {
                            UpdateClient(client);
                        }
                        else
                        {
                            FileUtil.BackToMenu();
                        }

                        break;
                    }
                }
                if(line == null)
                {
                    Console.WriteLine("CPF não cadastrado!");

                    Console.WriteLine("\nVocê deseja cadastrar um cliente com o cpf \"" + cpfLocal + "\" ?");
            
                    bool opcao = Validation.ReadYesOrNot();
                    // opcao.Equals(1) ? RegisterClientInFile() : BackToMenu(); 
                    FileUtil.BackToMenu();   
                }
                
             }

        }

        private void UpdateClient(Client client)
        {
            //int dataInt;
            string dataString;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nCaso queira que alguma propriedade se mantenha como estava antes, apenas digite -1");
            Console.ResetColor();

            dataString = Validation.StringReadValidation("Nome: ");
            if(dataString != "-1" ) client.name = dataString;

            dataString = Validation.StringReadValidation("Email: ");
            if(dataString != "-1" ) client.email = dataString;

            dataString = Validation.StringReadValidation("Telefone: ");
            if(dataString != "-1") client.phone = dataString;

            
        }
    }
    
}