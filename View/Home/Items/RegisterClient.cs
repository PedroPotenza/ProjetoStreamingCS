using System;
using System.IO;
using Entities;
using Utils.InputValidation;
using Utils.FileUtil;
using View.Menu;

namespace Items{

    internal class RegisterClient : IItemMenu
    {
        
        public string Name(){
            return ("Cadastrar/Atualizar Cliente");
        }

        public void Execute(){

            string filePath = @"./DataBase/Clients.txt";

            string cpfLocal;
            Console.WriteLine("---- " + Name() + " ----\n");
            Console.Write("CPF: ");
            cpfLocal = Console.ReadLine();

            var lineCount = 0;
            bool exist = true;
            string line;
            using (var reader = File.OpenText(filePath))
            {
                
                while ((line = reader.ReadLine()) != null)
                {
                    
                    lineCount++;
                    string[] atribute = line.Split(';');
                    Client client = new Client(int.Parse(atribute[0]),atribute[1],atribute[2],atribute[3],atribute[4],Enum.Parse<Client.PlanType>(atribute[5]));
                    if(client.cpf == cpfLocal){


                       
                        client.ShowClient();
                        Console.WriteLine("Você deseja atualizar os dados do(a) cliente \"" + client.name + "\" ?");
            
                        bool opcao = Validation.ReadYesOrNot();
                        
                        if(opcao)
                        {
                            reader.Close();
                            UpdateClient(client, lineCount);
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
                    exist = false;
                }
                
             }

             if(!exist)
             {
                 Console.WriteLine("CPF não cadastrado!");

                Console.WriteLine("\nVocê deseja cadastrar um cliente com o cpf \"" + cpfLocal + "\" ?");
            
                bool opcao = Validation.ReadYesOrNot();

                if(opcao)
                {
                    RegisterClientInFile(cpfLocal);
                }
                else
                {
                    FileUtil.BackToMenu();  
                }
             }

        }

        private void UpdateClient(Client client, int lineCount)
        {
            //int dataInt;
            string dataString;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nCaso queira que alguma propriedade se mantenha como estava antes, apenas digite -1");
            Console.ResetColor();

            dataString = Validation.StringRead("Nome: ");
            if(dataString != "-1" ) client.name = dataString;

            dataString = Validation.StringRead("Email: ");
            if(dataString != "-1" ) client.email = dataString;

            dataString = Validation.StringRead("Telefone: ");
            if(dataString != "-1") client.phone = dataString;

            Console.Write("Plano: " + client.planType.ToString());
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\nPara efetuar a mudança de plano, é necessario atualizar o contrato no menu principal!\n");
            Console.ResetColor();
  
            string[] newLine = {
                client.id.ToString(),
                client.cpf,
                client.name,
                client.email,
                client.phone,
                client.planType.ToString()
            };

            dataString = string.Join(";", newLine);
            FileUtil.UpdateLine(@"./DataBase/Clients.txt", dataString, lineCount);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\tPlano Atualizado com Sucesso!\n");
            Console.ResetColor();

        }

        private void RegisterClientInFile(string cpf)
        {
            string dataString;
            Client client = new Client();
            
            Console.Write("\nCPF: " + cpf + "\n");
            client.cpf = cpf;
            client.name = Validation.StringRead("Nome: ");
            client.email = Validation.StringRead("Email: ");
            client.phone = Validation.StringRead("Telefone: ");

            Console.WriteLine("Tipo de Plano: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\t(1) Basico");
            Console.WriteLine("\t(2) Padrão");
            Console.WriteLine("\t(3) Premium");
            Console.ResetColor();

            TypeSelection: 
            int opcao = Validation.OptionRead(1,3);
            Plan plan = new Plan((Plan.PlanType)opcao);

            Console.Write("\n");
            plan.ShowPlan();

            Console.WriteLine("\nVocê confirma a assinatura nesse plano?");
            bool confirm = Validation.ReadYesOrNot();
            if(confirm)
            {
                client.planType = (Client.PlanType)opcao;
                string[] newLine = {
                    client.id.ToString(),
                    client.cpf,
                    client.name,
                    client.email,
                    client.phone,
                    client.planType.ToString()
                };

                dataString = string.Join(";", newLine);
                FileUtil.AddLine(@"./DataBase/Clients.txt", dataString);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n\tCliente Cadastrado com Sucesso!\n");
                Console.ResetColor();
            }
            else 
                goto TypeSelection; //repeat type selection, the user is obrigatory to enter a plan.
                //REVIEW: This is really the best way to do? Maybe have a escape to user cancel the process... idk
            
        }
    }
    
}