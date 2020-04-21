using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary.Business.FileSystems
{
    public class FileMovieDatabase : MovieDatabase
    {
        public FileMovieDatabase ( string filename )
        {
            if (filename ==null)
                throw new ArgumentNullException(nameof(filename));
            if (String.IsNullOrEmpty(filename))
                throw new ArgumentException("File name cannot be empty", nameof(filename));

            _filename = filename;
        }
        protected override Movie AddCore ( Movie movie )
        {
            EnsureLoaded();

            movie.Id = (_items.Any() ? _items.Max(m => m.Id) : 0) + 1;

            _items.Add(movie);
            SaveMovies();

            return movie;
        }
        private void EnsureLoaded ()
        {
            if (_items == null)
                GetAllCore();
        }
        protected override void UpdateCore ( int id, Movie movie )
        {
            var existing = FindById(id);
            if (existing == null)
                throw new Exception("Movie not found");

            _items.Remove(existing);
            movie.Id = id;
            _items.Add(movie);

            SaveMovies();
        }
        protected override Movie GetCore ( int id )
        {
            if (!File.Exists(_filename))
                return null;

            //IOException
            //var stream = File.OpenRead(_filename);

            using (var reader = new StreamReader(_filename))
            {


                //SR is the textual stream reader.
                //streamWriter - writing textual streams
                //BinaryReader - reading binary data
                //BinaryWriter - writing binary data 
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var movie = LoadMovie(line);
                    if (movie?.Id == id)
                        return movie;
                };




            };
            return null;

            //TODO: read the stream using ReadLine 
            //try
            //{
            //    //SR is the textual stream reader.
            //    //streamWriter - writing textual streams
            //    //BinaryReader - reading binary data
            //    //BinaryWriter - writing binary data 
            //    reader = new StreamReader(stream);
            //    while (!reader.EndOfStream)
            //    {
            //        var line = reader.ReadLine();
            //        var movie = LoadMovie(line);
            //        if (movie?.Id == id)
            //            return movie;

            //    };
            //} finally
            //{
            //    reader.Close();
            //};

           // return null;
        }
        protected override void DeleteCore ( int id )
        {
            
            var movie = FindById(id);
            if(movie == null)
            {
                _items.Remove(movie);
                SaveMovies();
            }
        }

        private Movie LoadMovie ( string line ) //:1;29
        {
            var token = line.Split(',');
            if (token.Length != 7)
                return null;

            if (!Int32.TryParse(token[0], out var id) || id <= 0)
                return null;

            var title = UnquotedString(token[1]);
            if (String.IsNullOrEmpty(title))
                return null;

            var description = UnquotedString(token[2]);
            var genre = UnquotedString(token[3]);

            if (!Int32.TryParse(token[4], out var releaseYear))
                return null;
            if (!Int32.TryParse(token[5], out var runLength))
                return null;
            if (!Boolean.TryParse(token[6], out var isClassic))
                return null;

            return new Movie() {
                Id = id,
                Title = title,
                Description = description,
                Genre = !String.IsNullOrEmpty(genre) ? new Genre(genre) : null,
                ReleaseYear = releaseYear,
                RunLength = runLength,
                IsClassic = isClassic
            };

        }
        private IEnumerable<Movie> LoadMovies ()
        {


            //buffered approach 
            //var text = File.ReadAllText(_filename);
            var lines = File.ReadAllLines(_filename);
            foreach (var line in lines)
            {
                //TODO: read logic 
                var movie = LoadMovie(line);
                if (movie != null)
                    yield return movie;
            };
        }

        private void SaveMovies ()
        {
            var lines = new List<string>();
            foreach (var movie in _items)
            {
                var line = SaveMovie(movie);
                if (!String.IsNullOrEmpty(line))
                    lines.Add(line);
            };

            File.WriteAllLines(_filename, lines);
        }
        private string SaveMovie ( Movie movie )
        {
            //CSV - comma separetae values -id,Title,Description
            return $"{ movie.Id}, {QuotedString(movie.Title)},{QuotedString(movie.Description)}, " +
                $"{QuotedString(movie.Genre?.Description)}, {movie.ReleaseYear}, {movie.RunLength}, {movie.IsClassic}";
        }

        protected override IEnumerable<Movie> GetAllCore ()
        {
            _items = new List<Movie>();

            if (File.Exists(_filename))
            {
                try
                {
                    var movies = LoadMovies();

                    _items.AddRange(movies);
                } catch (FileNotFoundException)
                {
                    //ignore
                };
            } 

            return _items;
        }

        private static string UnquotedString ( string value ) => value?.Trim('"', ' ', '\t') ?? "";
        private static string QuotedString ( string value ) => $"\"{value}\"";

        protected override Movie FindById ( int id )
        {
            EnsureLoaded();
            return _items.FirstOrDefault(m => m.Id == id);
        }
        protected override Movie FindByTitle ( string title )
        {
            return _items.FirstOrDefault(m => String.Compare(m.Title, title, true)== 0);
        }

        private List<Movie> _items;
        private readonly string _filename;
    }
}
