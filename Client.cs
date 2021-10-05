using System.Collections.Generic;

namespace ProjetoStreamingCS
{
    internal class Client
    {
        // public enum StatusEnum
        // {
        //     Active,
        //     Inactive
        // }

        private string cpf { get; set; }
        private string name { get; set; }
        private string email { get; set; }
        private string phone { get; set; }
        private int  contractId { get; set; }

        // private List<Movie> watched_movies = new List<Movie>();
        
        public Client()
        {
            // status = StatusEnum.Inactive;
        }

        // public Movie GetMovie(int Index)
        // {
        //     return watched_movies[Index];
        // }

        // public void WatchMovie(Movie WatchedMovie)
        // {
        //     watched_movies.Add(WatchedMovie);
        // }

    }
}