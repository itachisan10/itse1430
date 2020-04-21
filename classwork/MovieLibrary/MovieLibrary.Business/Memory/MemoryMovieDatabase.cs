using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace MovieLibrary.Business.Memory
{
    public class MemoryMovieDatabase : MovieDatabase
    {

        // is-a relationship
        protected override Movie AddCore ( Movie movie )
        {
            
            //TODO: clone movie to store 03/02/20
            var item = CloneMovie(movie);
            item.Id = _id++;
            _movies.Add(item);
            //for (var index = 0; index < _movies.Count; ++index)
            //{
            //    if (_movies[index] == null)
            //    {
            //        _movies[index] = item;
            //        //passing the clone 
            //        item.Id = _id++;
            //        return CloneMovie(item);
            //    };
            //};
            return CloneMovie(item);
        }

        protected override Movie GetCore (int id )
        {
           
            var movie = FindById(id);
            if (movie == null)
                return null;

            return CloneMovie(movie);
        }

        protected override void DeleteCore ( int id )
        {
            var movie = FindById(id);
            if (movie != null)
                _movies.Remove(movie);
            
        }

        protected override void UpdateCore ( int id, Movie movie ) 
        {
            var existing = FindById(id);

            
            //Update movie now...03/04/20
            CopyMovie(existing, movie, false);
        }

        protected override IEnumerable<Movie> GetAllCore ()
        {
           // throw new Exception("failed");
            var items = _movies.Where(m => true);

            return _movies.Select(m => CloneMovie(m));

            //items.Any() => true if any elements or any elements meet a condition
            //items.All() => true for all elements 
            

            //Debug.WriteLine("Starting GetAllCore");
            ////use an iterator luke
            //foreach(var movie in _movies)
            //{
            //    Debug.WriteLine($"Returning {movie.Id}");
            //    yield return CloneMovie(movie);
            //    Debug.WriteLine($"Returned {movie.Id}");
            //};
        }

        private readonly List<Movie> _movies = new List<Movie>();
        private int _id = 1;

        //Example of doing more complex querying with programmatic filters.
        private IEnumerable<Movie> Query ( string title, int releaseYear )
        {
            var query = from movie in _movies
                        select movie;

            if (!String.IsNullOrEmpty(title))
                query = query.Where(m => String.Compare(m.Title, title, true) == 0);

            if (releaseYear > 0)
                query = query.Where(m => m.ReleaseYear >= releaseYear);

            return query.ToList();
        }                                 
        protected override Movie FindByTitle ( string title ) => (from movie in _movies
                                                                  where String.Compare(movie.Title, title, true) == 0
                                                                  select movie).FirstOrDefault();
        //movies.FirstOrDefault(m => String.Compare(m?.Title, title, true) ==0);
        //{
        //    foreach (var movie in _movies)
        //    {
        //        if (String.Compare(movie?.Title, title, true) == 0)
        //            return movie;
        //    };
        //    return null;
        //}

        private Movie CloneMovie ( Movie movie )
        {
            var item = new Movie();
            CopyMovie(item, movie, true);

            return item;
            //object initializer syntax 

            //    return new Movie() {
            //    Id = movie.Id,
            //    Title = movie.Title,
            //    Description = movie.Description,
            //    Genre = new Genre(movie.Genre.Description),
            //    IsClassic = movie.IsClassic,
            //    ReleaseYear = movie.ReleaseYear,
            //    RunLength = movie.RunLength,
            //};

            //item.Id = movie.Id;
            //item.Title = movie.Title;
            //item.Description = movie.Description;
            //item.Genre = movie.Genre;
            //item.IsClassic = movie.IsClassic;
            //item.ReleaseYear = movie.ReleaseYear;
            //item.RunLength = movie.RunLength;


        }
        
        private void CopyMovie ( Movie target, Movie source, bool includeId )
        {
            if (includeId)
                target.Id = source.Id;
            target.Id = source.Id;
            target.Title = source.Title;
            target.Description = source.Description;
            if (source.Genre != null)
                target.Genre = new Genre(source.Genre.Description);
            else
                target.Genre = null;
            target.IsClassic = source.IsClassic;
            target.ReleaseYear = source.ReleaseYear;
            target.RunLength = source.RunLength;
        }

        //private bool IsId ( Movie movie ) { return movie.Id == id; }

        protected override Movie FindById ( int id ) => _movies.FirstOrDefault(m => m.Id == id);
        //{
        //    //lambda syntax ::= parameters => body 
        //    // 1 parameter, 1 return type :: = x => E
        //    //no return types =>{}
        //    //2+ parameters (x,y) => ?

        //    _movies.FirstOrDefault(m => m.Id == id);
        //    //var temp = new DUmmyType(){Id = id}
        //    //_movies.FirstOrDefault(temp.@Fak);
        //    foreach (var movie in _movies)
        //    {
        //        if (movie.Id == id)
        //            return movie;
        //    };
        //    return null;
        //}
    }
}
