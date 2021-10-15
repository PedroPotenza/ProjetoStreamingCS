using System.Collections.Generic;

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

        static private int counterClients = 0;
        public int  id { get; set; }
        public string cpf { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public PlanType planType { get; set; }

        public Client()
        {

        }
        public Client(int id, string cpf, string email, string phone, int planType)
        {
            this.id = id;
            this.cpf = cpf;
            this.email = email;
            this.phone = phone;
            this.planType = (PlanType) planType;
        }

        int GetCounterClients()
        {
            return(counterClients);
        }

        void IncrementCounterClients()
        {
            counterClients++;
        }

        void DecrementCounterClients()
        {
            counterClients--;
        }

        public void ShowClient()
        {

        }

    }
}