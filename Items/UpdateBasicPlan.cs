using System;
using System.IO;
using Entities;

namespace Items.Menu{

    internal class UpdateBasicPlan : IItemMenu
    {
        
        public string Name(){
            return ("Plano Basico");
        }

        public void Execute(){
            
            string filePath = @"./DataBase/Plans.txt";
            
            using (var reader = File.OpenText(filePath))
            {
                string line;
                
                    line = reader.ReadLine();
                    string[] atribute = line.Split(';');
                    Plan plan = new Plan(atribute[0], float.Parse(atribute[1])/100, atribute[2], int.Parse(atribute[3]), float.Parse(atribute[4])/100, int.Parse(atribute[5]), int.Parse(atribute[6]), bool.Parse(atribute[7]));
                    plan.ShowPlan();
                
            }
                    
        }
    }
    
}