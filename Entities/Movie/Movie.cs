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
            this.id = 1000 + MovieController.Count(); 
        }

        //optimize: I think that maybe it's need focus more on encapsulate concept... in this system don't have any problem but on a
        //optimize: system more complete and with others devs maybe I've been doing some mistakes.
        
        /// <summary>
        /// Constructor of a existent movie found by id.
        /// </summary>
        /// <param name="id">Id of a existent movie. Be sure to check for existence of the movie id before call this constructor.</param>
        public Movie(int id)
        {
            string[] atribute = MovieController.LineById(id);

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
        
    }
}