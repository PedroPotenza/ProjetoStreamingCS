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
            this.id = 1000 + FileUtil.CountFile(@"./DataBase/Movies.txt"); 
        }

        public Movie(int id)
        {
            var reader = File.OpenText(@"./DataBase/Movies.txt");
            
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

        public Movie(string name)
        {
            var reader = File.OpenText(@"./DataBase/Movies.txt");
            
            while(true)
            {           
                string line = reader.ReadLine();
                string[] atribute = line.Split(';');

                string nameLine = atribute[1];
             
                if(nameLine == name)
                {
                    this.id = int.Parse(atribute[0]);
                    this.name = atribute[1];
                    this.plot = atribute[2];
                    this.year = int.Parse(atribute[3]);
                    this.director = atribute[4];
                    this.rating = Enum.Parse<MovieRating>(atribute[5]);
                    break;
                }
            }

            reader.Close();
        }

        public void ShowMovieShort()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("\t" + id);
            Console.Write("\t" + name );
            for(int i = name.Length; i <=50; i++)
                Console.Write(" ");
            Console.Write("\t" + rating + "\n");
            Console.ResetColor();
        }

        public void ShowMovieLong()
        {
            Console.Clear();
            Console.WriteLine("\t".PadRight(57,'-'));
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\tId: " + id);
            Console.WriteLine("\tNome: " + name);
            Console.WriteLine("\tSinopse: " + plot);
            Console.WriteLine("\tAno: " + year);
            Console.WriteLine("\tDiretor: " + director);
            Console.WriteLine("\tClassificação: " + rating);
            Console.WriteLine("\tGeneros: ");
            Console.ResetColor();
            Console.WriteLine("\t".PadRight(57,'-'));
        }
    }
}