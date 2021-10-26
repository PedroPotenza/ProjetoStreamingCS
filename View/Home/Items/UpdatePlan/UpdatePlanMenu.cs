using View.Menu;

namespace UpdatePlan.Items{

    internal class UpdatePlanMenu : IItemMenu
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
            
        }
    }

}