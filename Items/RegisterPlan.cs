using System;

namespace Items.Menu{

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

}