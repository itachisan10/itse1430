using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary.Business.FileSystem
{
    public class FileMovieDatabase : MovieDatabase
    {
        public FileMovieDatabase(string filename )
        {
            if (filename ==null)
                throw new ArgumentNullException(nameof(filename));
            if (String.IsNullOrEmpty(filename))
                throw new ArgumentException("File name cannot be empty", nameof(filename));

            _filename = filename;
        }
        protected override Movie AddCore ( Movie movie )
        {
            throw new NotImplementedException();
        }
        protected override void DeleteCore ( int id )
        {
            throw new NotImplementedException();
        }
        protected override Movie FindById ( int id )
        {
            throw new NotImplementedException();
        }
        protected override Movie FindByTitle ( string title )
        {
            throw new NotImplementedException();
        }
        protected override IEnumerable<Movie> GetAllCore ()
        {
            //buffered approach 
            //var text = File.ReadAllText(_filename);
            var lines = File.ReadAllLines(_filename);
            foreach( var line in lines)
            {
                //TODO: read logic 
            };
            return Enumerable.Empty<Movie>();
        }
        protected override Movie GetCore ( int id )
        {
            throw new NotImplementedException();
        }
        protected override void UpdateCore ( int id, Movie movie )
        {
            throw new NotImplementedException();
        }

        private readonly string _filename;
    }
}
