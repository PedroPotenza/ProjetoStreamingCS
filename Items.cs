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
            Console.WriteLine("Opção Cadastrar Cliente selecionada\n");
        }
    }

    internal class RegisterMovie : IItemMenu
    {
        
        public string Name(){
            return ("Cadastrar Filme");
        }

        public void Execute(){
            Console.WriteLine("Opção Cadastrar Filme selecionada\n");
        }
    }

    internal class RegisterPlan : IItemMenu
    {
        
        public string Name(){
            return ("Cadastrar Plano");
        }

        public void Execute(){
            Console.WriteLine("Opção Cadastrar Plano selecionada\n");
            //vou ter que fazer um menu dentro do menu, deus me ajude a saber fazer isso
        }
    }

    internal class RegisterContract : IItemMenu
    {
        
        public string Name(){
            return ("Cadastrar Contrato");
        }

        public void Execute(){
            Console.WriteLine("Opção Cadastrar Contrato selecionada\n");
        }
    }

    internal class WatchMovie : IItemMenu
    {
        
        public string Name(){
            return ("Assistir filme");
        }

        public void Execute(){
            Console.WriteLine("Opção assistir filme selecionada\n");
        }
    }

    internal class CancelContract : IItemMenu
    {
        
        public string Name(){
            return ("Cancelar Contrato");
        }

        public void Execute(){
            Console.WriteLine("Opção cancelar contrato selecionada\n");
        }
    }

    internal class GenerateBill : IItemMenu
    {
        
        public string Name(){
            return ("Gerar fatura");
        }

        public void Execute(){
            Console.WriteLine("Opção gerar fatura selecionada\n");
        }
    }

    internal class ShowClient : IItemMenu
    {
        
        public string Name(){
            return ("Dados Cliente");
        }

        public void Execute(){
            Console.WriteLine("Opção dados cliente selecionada\n");
        }
    }

    internal class ShowHistory : IItemMenu
    {
        
        public string Name(){
            return ("Historico Cliente");
        }

        public void Execute(){
            Console.WriteLine("Opção historico cliente selecionada\n");
        }
    }

    internal class ExcessClients : IItemMenu
    {
        
        public string Name(){
            return ("Clientes Execentes");
        }

        public void Execute(){
            Console.WriteLine("Opção clientes exedentes selecionada\n");
        }
    }

    internal class FrequencyMovie : IItemMenu
    {
        
        public string Name(){
            return ("Frequencia de um Filme");
        }

        public void Execute(){
            Console.WriteLine("Opção frequencia de um filme selecionada\n");
        }
    }
}