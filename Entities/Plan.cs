using System;
using System.IO;

namespace Entities
{
    public class Plan
    {
        public enum PlanType
        {
            NotSet = 0,
            Basic,
            Standard,
            Premium
        }
        public string name { get; set; }
        public int valor { get; set; }
        public string maxQuality { get; set; }
        public int simultaneousDevices { get; set; }
        public int loyaltyFine { get; set; } 
        public int loyaltyFineTime { get; set; } 
        public int maxMovies { get; set; }
        public bool download { get; set; }

        public Plan(string name, int valor, string maxQuality, int simultaneousDevices, int loyaltyFine, int loyaltyFineTime, int maxMovies, bool download)
        {
            this.name = name;
            this.valor = valor;
            this.maxQuality = maxQuality;
            this.simultaneousDevices = simultaneousDevices;
            this.loyaltyFine = loyaltyFine;
            this.loyaltyFineTime = loyaltyFineTime;
            this.maxMovies = maxMovies;
            this.download = download;
        }

        public Plan(PlanType planType)
        {
            var reader = File.OpenText(@"./DataBase/Plans.txt");
            
            for(int i=1; i<(int)planType; i++)
                reader.ReadLine();
            
            string line = reader.ReadLine();
            reader.Close();
            string[] atribute = line.Split(';');

            this.name = atribute[0];
            this.valor = int.Parse(atribute[1]);
            this.maxQuality = atribute[2];
            this.simultaneousDevices = int.Parse(atribute[3]);
            this.loyaltyFine = int.Parse(atribute[4]);
            this.loyaltyFineTime = int.Parse(atribute[5]);
            this.maxMovies = int.Parse(atribute[6]);
            this.download = bool.Parse(atribute[7]);
        }
        public void ShowPlan()
        {
            Console.WriteLine("---------- Plano " + name + " ----------");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Quantidade de dispositivos simultâneos: " + simultaneousDevices);
            Console.WriteLine("Qualidade maxima de imagem: " + maxQuality);
            Console.WriteLine("Tempo de fidelidade: " + loyaltyFineTime);
            Console.WriteLine("Multa de fidelidade: " + String.Format("{0:C}", ((float)loyaltyFine)/100));
            Console.WriteLine("Limite de filmes: " + (maxMovies.Equals(-1) ? "Ilimitado" : maxMovies));
            Console.WriteLine("Download de filmes? " + (download ? "Sim" : "Não"));
            Console.WriteLine("Valor do plano: " + String.Format("{0:C}", ((float)valor)/100));
            Console.ResetColor();
        } 

        public float Loyalty()
        {
            //implemento a função
            return 0;
        } 

    }
}