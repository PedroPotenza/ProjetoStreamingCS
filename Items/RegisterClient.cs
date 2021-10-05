using System;

namespace Items.Menu{

    internal class RegisterClient : IItemMenu
    {
        
        public string Name(){
            return ("Cadastrar Cliente");
        }

        public void Execute(){

            

            /*
            Todo cliente vai inicializar com o plano basico ja
            logo posso adicionar um objeto de contrato no cliente (?)
            como vou trabalhar com esse contrato?
            são arquivos separados?
            */


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