using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieLibrary.Business
{
    public abstract class MovieDatabase : IMovieDatabase
    {
        // is-a relationship
        public Movie Add ( Movie movie )
        {
            //created 02/26/20 //edited 03/02/20
            //TODO: validate
            if (movie == null)
                throw new ArgumentNullException(nameof(movie), "Movie is null");
                //return null;

            //.Net validation
            ObjectValidator.Validate(movie);


            //TODO: movie names must be unique 
            try
            {
                var existing = FindByTitle(movie.Title);
                if (existing != null)
                    throw new InvalidOperationException("movie must be unique");

                return AddCore(movie);
            } catch (InvalidOperationException)
            {
                throw;
            } catch(Exception e)
            {
               throw new InvalidOperationException("Error adding movie", e);
            };
            
        }
        protected abstract Movie AddCore ( Movie movie );
    

        public Movie Get (int id )
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be greater than zero");

            return GetCore(id);
        }
        protected abstract Movie GetCore (int id);


        public void Delete ( int id )
        {
            //TODO: validate movie
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be greater than zero");
              
            DeleteCore(id);
        }
        protected abstract void DeleteCore ( int id );


        public string Update ( int id, Movie movie )
        {

            //TODO: validate
            //TODO: movie names must be unique 
            //TODO: clone movie to store
            //TODO: dont need original movie.
            if (movie == null)
                throw new ArgumentNullException(nameof(movie), "Movie is null");
            //return "Movie is null";

            ObjectValidator.Validate(movie);

            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be greater than zero");
                //return "Id is invalid";

            var existing = FindById(id);
            if (existing == null)
                throw new ArgumentException("Movie not found", nameof(id));
                //return "Movie not found";

            //TODO: movie names must be unique 
            var sameName = FindByTitle(movie.Title);
            if (sameName != null && sameName.Id != id)
                if (sameName != null)
                    throw new InvalidOperationException("movie must be unique");
                    //return "Movie must be unique";

            UpdateCore(id,movie);
            return null;
        }
        protected abstract void UpdateCore ( int id, Movie movie );


        public IEnumerable<Movie> GetAll () => GetAllCore() ?? Enumerable.Empty<Movie>();
        protected abstract IEnumerable<Movie> GetAllCore ();


        protected abstract Movie FindByTitle ( string title );

        protected abstract Movie FindById ( int id );
      
    }
}
