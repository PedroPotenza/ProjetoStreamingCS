using System;
using System.IO;
using Utils.InputValidation;
using Utils.FileUtil;
using Entities.Controller;

namespace Entities
{
    internal class Movie
    {

        public enum MovieRating
        {
            NotSet = 0,
            G,
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

        //optimize: I think that maybe it's need focus more on encapsulate concept... in this system don't have any problem but on a
        //optimize: system more complete and with others devs maybe I've been doing some mistakes.
        
        /// <summary>
        /// Constructor of a existent movie found by id.
        /// </summary>
        /// <param name="id">Id of a existent movie. Be sure to check for existence of the movie id before call this constructor.</param>
        public Movie(int id)
        {
            var reader = File.OpenText(@"./DataBase/Movies.txt");
            
            for(int i=1; i < id - 1000; i++)
                reader.ReadLine();
            
            string line = reader.ReadLine();
            reader.Close();
            string[] atribute = line.Split(';');

            this.id = int.Parse(atribute[0]);
            this.name = atribute[1];
            this.plot = atribute[2];
            this.year = int.Parse(atribute[3]);
            this.director = atribute[4];
            this.rating = Enum.Parse<MovieRating>(atribute[5]);
        }

        /// <summary>
        /// Constructor of a existent movie found by name.
        /// </summary>
        /// <param name="name">Name of a existent movie. Be sure to check for existence of the movie name before call this constructor.</param>
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
    }
}