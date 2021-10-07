using System;
using System.IO;

namespace Entities
{
    public class Plan
    {

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

        public void updateLine(string newText, int line)
        {
            string filePath = @"./DataBase/Plans.txt";
            string[] plans = File.ReadAllLines(filePath);
            plans[line - 1] = newText;
            File.WriteAllLines(filePath, plans);
            
            //reference:
            //https://stackoverflow.com/questions/1971008/edit-a-specific-line-of-a-text-file-in-c-sharp
        }
        public float Loyalty()
        {
            //implemento a função
            return 0;
        } 
    }
}