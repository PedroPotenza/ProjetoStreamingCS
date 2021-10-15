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
            Console.Write("CPF: ");
            cpfLocal = Console.ReadLine();

            var lineCount = 0;
            //seria possivel fazer uma função dentro de Client.cs fazendo essa busca? (e consequentemente instanciando um client dentro da classe client)
            //o retorno seria o cliente ja cadastrado
            using (var reader = File.OpenText(filePath))
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    lineCount++;
                    string[] atribute = line.Split(';');
                    Client client = new Client(int.Parse(atribute[0]),atribute[1],atribute[2],atribute[3],int.Parse(atribute[4]));
                    if(client.cpf == cpfLocal){
                        Console.WriteLine("CPF já cadastrado!\n");
                        client.ShowClient();
                    }
                    

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

            Console.WriteLine("---- " + Name() + " ----\n");
        }
    }
    
}