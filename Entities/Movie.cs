using System;
using System.IO;
using InputValidation;
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

            this.id = int.Parse(atribute[0]);
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
            Console.WriteLine("".PadRight(57,'-'));
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Id: " + id);
            Console.WriteLine("Nome: " + name);
            Console.WriteLine("Sinopse: " + plot);
            Console.WriteLine("Ano: " + year);
            Console.WriteLine("Diretor: " + director);
            Console.WriteLine("Classificação: " + rating);
            Console.WriteLine("Generos: ");
            Console.ResetColor();
            Console.WriteLine("".PadRight(57,'-'));
        }

        static public void ShowListMovie(int page)
        {
            int lastPage = (FileUtil.CountFile(@"./DataBase/Movies.txt")/10)+1;
            int firstIdOfPage = 1000 + (10*(page-1))+1;
            int lastIdOfPage = firstIdOfPage + 9;

            Console.Clear(); 
                Console.WriteLine("----------------------------------- LISTA DE FILMES -----------------------------------");
                
                    Console.WriteLine("\n\tId\tNome\t\t\t\t\t\t\tClassificação");
                    ShowItemMovie(firstIdOfPage, lastIdOfPage);
    
                Console.WriteLine("\n-------------------------------------- [{0}/{1}] -----------------------------------------", page,lastPage);
                
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nPara avançar uma página na lista de filmes digite \"next\"");
                Console.WriteLine("Para voltar uma página na lista de filmes digite \"back\"");
                Console.WriteLine("Para voltar ao menu principal digite \"home\"");
                Console.ResetColor();
        }

        /// <summary>
        /// USAR ESSE METODO PARA CHAMAR 
        /// </summary>
        /// <param name="message"></param>
        static public bool ControllerOfListMovies(string message, Movie movie)
        {
            int page = 1;
            int lastPage = (FileUtil.CountFile(@"./DataBase/Movies.txt")/10)+1;

            while(true)
            {

                ShowListMovie(page);

                Console.WriteLine("\n" + message);
                
                bool ask = true;
                while(ask)
                {
                    string dataString = Validation.StringRead("Filme Selecionado: ");

                    switch(dataString)
                    {
                        case "home":
                        {
                            FileUtil.BackToMenu();
                            //don't repeat anything, go to home
                            return false;
                        }         

                        case "next":
                        {
                            if(page != lastPage)
                            {
                                page++;
                                ask = false;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("\nUltima página alcançada!\n");
                                Console.ResetColor(); 
                            }
                            break;
                        }

                        case "back":
                        {
                            if(page != 1)
                            {
                                page--;    
                                ask = false;
                            } 
                            else 
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("\nVocê ja está na primeira pagina!\n");
                                Console.ResetColor();
                            }
                            break;
                        }

                        default:
                        {
                            bool findSucess = FindMovie(dataString, ref movie);
                            
                            if(findSucess)
                            {
                                ask = false;
                                movie.ShowMovieLong();

                                Console.WriteLine("\nConfirma a escolha do filme?");
                                bool opcao = Validation.ReadYesOrNot();
                                return opcao;
                            }
                            else 
                            {
                                return false;
                            }
                            
                        }

                    }
                }
            }
        }

        static private bool FindMovie(string dataMovie, ref Movie movie)
        {

            bool findById = Int32.TryParse(dataMovie, out int Id);
            if(findById)
            {

                if(Id >= 1001 && Id<=1000+FileUtil.CountFile(@"./DataBase/Movies.txt"))
                {
                    movie = new Movie(Id);
                    //movie.ShowMovieLong();
                    return true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Não foi possivel localizar o filme com o Id correspondente a \"{0}\"", Id);
                    Console.ResetColor();
                    return false;
                }

            }
            else
            {
                try
                {
                    movie = new Movie(dataMovie);
                    return true;
                }
                catch(NullReferenceException) //ASK: it's possible to see if that movie exist without a exception? 
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Não foi possivel localizar o filme \"{0}\"", dataMovie);
                    Console.ResetColor();
                    return false;
                }

            }
        }
        static private void ShowItemMovie(int lower, int upper)
        {
            for(;lower<=upper; lower++)
            {
                try{
                    Movie movie = new Movie(lower);
                    movie.ShowMovieShort();
                    
                }
                catch(NullReferenceException)
                {
                    Console.WriteLine();
                }
            }
        }
    }
}