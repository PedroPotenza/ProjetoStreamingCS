using System;
using System.Collections.Generic;
using Model.FileUtil;
using ProjetoStreamingCS;

namespace Entities
{
    internal class Client
    {
        public enum PlanType
        {
            Basic = 1,
            Standard,
            Premium
        }

        public int  id { get; set; }
        public string cpf { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public PlanType planType { get; set; }

        public Client()
        {
            this.id = 56213 + (213* FileUtil.CountFile(@"./DataBase/Clients.txt"));
        }
        public Client(int id, string cpf, string name, string email, string phone, PlanType planType)
        {
            this.id = id;
            this.cpf = cpf;
            this.name = name;
            this.email = email;
            this.phone = phone;
            this.planType = planType;
        }

        
        public void ShowClient()
        {
            Console.WriteLine("\n------------------------");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Id: " + id);
            Console.WriteLine("CPF: " + cpf);
            Console.WriteLine("Nome: " + name);
            Console.WriteLine("Email: " + email);
            Console.WriteLine("Telefone: " + phone);
            Console.WriteLine("Tipo de Plano: " + planType);
            Console.ResetColor();
            Console.WriteLine("------------------------\n");
        }

    }
}