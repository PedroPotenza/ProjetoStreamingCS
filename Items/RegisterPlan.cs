using System;

namespace Items.Menu{

    internal class UpdatePlan : IItemMenu
    {
        
        public string Name(){
            return ("Atualizar Plano");
        }

        public void Execute(){
            
            ProjetoStreamingCS.Menu subMenu = new ProjetoStreamingCS.Menu();
            
            subMenu.Add(new UpdateBasicPlan());
            subMenu.Add(new UpdateStandardPlan());
            subMenu.Add(new UpdatePremiumPlan());

            subMenu.ShowMenu(Name());
            

            /*

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