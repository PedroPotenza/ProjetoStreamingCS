using System.Collections.Generic;

namespace ProjetoStreamingCS
{
    internal class Client
    {
        public enum StatusEnum
        {
            Active,
            Inactive
        }

        private string cpf;
        private string name;
        private string email;
        private string phone;
        private StatusEnum status;

        private List<Movie> watched_movies = new List<Movie>();
        

        public Client()
        {
            status = StatusEnum.Inactive;
        }

        //Get e Set
        public string Cpf
        {
            get{return cpf;}
            set{cpf=value;}
        }

        public string Name
        {
            get{return name;}
            set{name=value;}
        }

        public string Email
        {
            get{return email;}
            set{email=value;}
        }

        public string Phone
        {
            get{return phone;}
            set{phone=value;}
        }

        public StatusEnum Status
        {
            get{return status;}
            set{status=value;}
        }

        public Movie GetMovie(int Index)
        {
            return watched_movies[Index];
        }

        public void WatchMovie(Movie WatchedMovie)
        {
            watched_movies.Add(WatchedMovie);
        }

    }
}