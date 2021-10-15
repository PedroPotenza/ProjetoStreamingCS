using System;
using System.IO;
using Entities;

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
                    // Console.WriteLine("Linha: " + lineCount);
                    string[] atribute = line.Split(';');
                    Client client = new Client(int.Parse(atribute[0]),atribute[1],atribute[2],atribute[3],atribute[4],int.Parse(atribute[5]));
                    if(client.cpf == cpfLocal){
                       
                        client.ShowClient();
                        Console.WriteLine("Você deseja atualizar os dados do(a) cliente \"" + client.name + "\" ?");
            
                        int opcao = ReadYesOrNot();
                        // opcao.Equals(1) ? UpdateClient() : BackToMenu();
                        BackToMenu();
                        break;
                    }
                }
                if(line == null)
                {
                    Console.WriteLine("CPF não cadastrado!");

                    Console.WriteLine("\nVocê deseja cadastrar um cliente com o cpf \"" + cpfLocal + "\" ?");
            
                    int opcao = ReadYesOrNot();
                    // opcao.Equals(1) ? RegisterClientInFile() : BackToMenu(); 
                    BackToMenu();   
                }
                
             }

            //recebe um CPF
            //verifica se o CPF ja foi cadastrado no Clients.txt
                //se já foi cadastrado
                //recebe outro CPF //se o usuario digitar 0 ele é redirecionado ao menu principal
            //instancia um objeto client da classe Client
            //atribui o CPF ao objeto client
            //recebe as outras informacoes 
            //escreve o objeto client no arquivo Clients.txt
            //incrementar quantidade de clientes no Contadores.txt

            
        }

        private void BackToMenu()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\nPressione qualquer tecla para retornar ao menu principal.");
            Console.ResetColor();
        }

        private int ReadYesOrNot()
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
                        return opcao;
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
    }
    
}