using System;

namespace ProjetoStreamingCS
{
    
    internal class ExitSystem : IItemMenu
    {
        
        public string Name(){
            return ("Encerrar o sistema");
        }

        public void Execute(){
            Console.WriteLine("Finalizando Sistema...\n");
            Console.WriteLine("Pressione qualquer tecla para encerrar.");
            Console.ReadKey(false);
            Console.Clear();
            Environment.Exit(1);
        }
    }
    
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

    internal class RegisterMovie : IItemMenu
    {
        
        public string Name(){
            return ("Cadastrar Filme");
        }

        public void Execute(){

            /*
            instancio um objeto filme
            informa qual o codigo do filme a ser cadastrado (1001 + contador de filmes atuais no banco)
            Apertar ESC cancela o registro e volta ao menu principal (como faço isso???)
            ler os dados do filme (e inserir no objeto)
            escrever objeto no arquivo Movies.txt
            incrementar a quantidade de filmes no Contadores.txt
            */

            Console.WriteLine("---- " + Name() + " ----\n");      
        }  
    }

    internal class RegisterPlan : IItemMenu
    {
        
        public string Name(){
            return ("Cadastrar Plano");
        }

        public void Execute(){
            Console.WriteLine("---- " + Name() + " ----\n");        
            /*
            Criar uma classe abstrata ou uma interface para plano (atributos em comum e metodos de impressão)
                atributos em comum: mensalidade, anuidade, etc...
                metodos: Imprimir plano (sobreescrever essa para cada plano)
            Criar tres classes que herdam a classe plano (uma classe para cada plano)
                adicionar informações de detalhes apenas porque sim (para deixar mais completo a ideia KKKKKKKKKKK)
                por exemplo: quantidade de dispositivos simultaneos, pode fazer download?, max resolução do filme

            --------------------------------------------------------------------------------------------------------

            Criar submenu
                1 - Plano Basico
                2 - Plano Padrão
                3 - Plano Premium

            PLANO BASICO
                Abrir arquivo Plans/Basic.txt
                cria um objeto do plano basico e atribui o que ta no Plans/Premium.txt a ele
                Informar quais são as informações atuais do plano basico 
                perguntar se deseja atualizar 
                    se sim, recebe novas informações
                    se não, retorna ao menu principal

            PLANO PADRÃO
                Abrir arquivo Plans/Standard.txt
                cria um objeto do plano standard e atribui o que ta no Plans/Standard.txt a ele
                Informar quais são as informações atuais do plano standard 
                perguntar se deseja atualizar 
                    se sim, recebe novas informações
                    se não, retorna ao menu principal
            
            PLANO PREMIUM
                Abrir arquivo Plans/Premium.txt
                cria um objeto do plano premium e atribui o que ta no Plans/Premium.txt a ele
                Informar quais são as informações atuais do plano premium
                perguntar se deseja atualizar 
                    se sim, recebe novas informações (sobreescreve arquivo)
                    se não, retorna ao menu principal
            */

        }
    }

    internal class RegisterContract : IItemMenu
    {
        
        public string Name(){
            return ("Cadastrar Contrato");
        }

        public void Execute(){
            Console.WriteLine("---- " + Name() + " ----\n");        
        }
    }

    internal class WatchMovie : IItemMenu
    {
        
        public string Name(){
            return ("Assistir filme");
        }

        public void Execute(){
            Console.WriteLine("---- " + Name() + " ----\n");        
        }
    }

    internal class CancelContract : IItemMenu
    {
        
        public string Name(){
            return ("Cancelar Contrato");
        }

        public void Execute(){
            Console.WriteLine("---- " + Name() + " ----\n");        
        }
    }

    internal class GenerateBill : IItemMenu
    {
        
        public string Name(){
            return ("Gerar fatura");
        }

        public void Execute(){
            Console.WriteLine("---- " + Name() + " ----\n");        
        }
    }

    internal class ShowClient : IItemMenu
    {
        
        public string Name(){
            return ("Dados Cliente");
        }

        public void Execute(){
            Console.WriteLine("---- " + Name() + " ----\n");        
        }
    }

    internal class ShowHistory : IItemMenu
    {
        
        public string Name(){
            return ("Historico Cliente");
        }

        public void Execute(){
            Console.WriteLine("---- " + Name() + " ----\n");        
        }
    }

    internal class ExcessClients : IItemMenu
    {
        
        public string Name(){
            return ("Clientes Execentes");
        }

        public void Execute(){
            Console.WriteLine("---- " + Name() + " ----\n");        
        }
    }

    internal class FrequencyMovie : IItemMenu
    {
        
        public string Name(){
            return ("Frequencia de um Filme");
        }

        public void Execute(){
            Console.WriteLine("---- " + Name() + " ----\n");        
        }
    }
}