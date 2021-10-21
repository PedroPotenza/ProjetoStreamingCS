using System;
using System.IO;
using ProjetoStreamingCS;

namespace Entities
{
    internal class Movie
    {

        public enum MovieRating
        {
            G = 1,
            PG,
            PG13,
            R,
            NC17

        }

        public int id { get; set; }
        public string name { get; set; }
        public string plot { get; set; }
        public int year { get; set; }
        public string director {get; set; }

        public MovieRating rating { get; set; }

        public Movie()
        {
            this.id = 1000 + FileUtil.CountFile(@"./DataBase/Movie.txt"); 
        }

        public Movie(int id)
        {
            var reader = File.OpenText(@"./DataBase/Movie.txt");
            
            for(int i=1; i < id - 1000; i++)
                reader.ReadLine();
            
            string line = reader.ReadLine();
            reader.Close();
            string[] atribute = line.Split(';');

            this.id = id;
            this.name = atribute[1];
            this.plot = atribute[2];
            this.year = int.Parse(atribute[3]);
            this.director = atribute[4];
            this.rating = Enum.Parse<MovieRating>(atribute[5]);
        }

        public void ShowMovieShort()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\t" + id + "\t" + name + "\t" + rating);
            Console.ResetColor();
        }

        
        
    }

}