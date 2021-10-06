using System;

namespace Entities
{
    public class Plan
    {

        private string name { get; set; }
        private float valor { get; set; }
        private string maxQuality { get; set; }
        private int simultaneousDevices { get; set; }
        private float loyaltyFine { get; set; } 
        private int loyaltyFineTime { get; set; } 
        private int maxMovies { get; set; }
        private bool download { get; set; }

        public Plan(string name, float valor, string maxQuality, int simultaneousDevices, float loyaltyFine, int loyaltyFineTime, int maxMovies, bool download)
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
        public void ShowPlan()
        {
            Console.WriteLine("---------- Plano " + name + " ----------");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Quantidade de dispositivos simultâneos: " + simultaneousDevices);
            Console.WriteLine("Qualidade maxima de imagem: " + maxQuality);
            Console.WriteLine("Tempo de fidelidade: " + loyaltyFineTime);
            Console.WriteLine("Multa de fidelidade: " + String.Format("{0:C}", loyaltyFine));
            Console.WriteLine("Limite de filmes: " + (maxMovies.Equals(-1) ? "Ilimitado" : maxMovies));
            Console.WriteLine("Download de filmes? " + (download ? "Sim" : "Não"));
            Console.WriteLine("Valor do plano: " + String.Format("{0:C}", valor));
            Console.ResetColor();
        } 
        public float Loyalty()
        {
            //implemento a função
            return 0;
        } 
    }
}