﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary.Business
{
    public class MovieDatabase
    {
        public Movie Add( Movie movie )
        {
            //created 02/26/20 //edited 03/02/20
            //TODO: validate
            if (movie == null)
                return null;
            if (!movie.Validate(out var error))
                return null;


            //TODO: movie names must be unique 
            var existing = FindByTitle(movie.Title);
            if (existing != null)
                return null;
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
        
        public void Delete ( int id)
        {

            //TODO: validate movie
            if (id <= 0)
                return;

            var movie = FindById(id);
            if (movie != null)
                _movies.Remove(movie);
            //TODO: find better way to find movie
            //for (var index = 0; index < _movies.Count; ++index)
            //{
            //    if (_movies[index]?.Id == id)
            //    {
            //        _movies[index] = null;
            //        return;
            //    };
            //};     
        }
        public void Update ( int id, Movie newMovie )
        {
            //TODO: validate
            //TODO: movie names must be unique 
            //TODO: clone movie to store
            //TODO: dont need original movie.
            for (var index = 0; index < _movies.Count; ++index)
            {
                if (_movies[index]?.Id == id)
                {
                    _movies[index] = newMovie;
                    return;
                };
            };
        }

        public Movie[] GetAll ()
        {
            //TODO: clone objects 03/02/20
            var items = new Movie[_movies.Count];
            var index = 0;
            foreach( var movie in _movies)
            {
                items[index++] = CloneMovie(movie);
            };
            return items;
        }
        //private movie array // 03/02/20
        // private readonly Movie[] _movies = new Movie[100];
        private readonly List<Movie> _movies = new List<Movie>();

        //creating id for clone 03/02/20
        private int _id = 1;
        //creating FindByTitle function  03/02/20
        private Movie FindByTitle( string title )
        {
            foreach(var movie in _movies)
            {
                if (String.Compare(movie?.Title, title, true) == 0)
                    return movie;
            };
            return null;
        }
        //Created 03/02/20 cloning function 
        private Movie CloneMovie( Movie movie )
        {
            //object initializer syntax 

                return new Movie() {
                Id = movie.Id,
                Title = movie.Title,
                Description = movie.Description,
                Genre = new Genre(movie.Genre.Description),
                IsClassic = movie.IsClassic,
                ReleaseYear = movie.ReleaseYear,
                RunLength = movie.RunLength,
            };
           
            //item.Id = movie.Id;
            //item.Title = movie.Title;
            //item.Description = movie.Description;
            //item.Genre = movie.Genre;
            //item.IsClassic = movie.IsClassic;
            //item.ReleaseYear = movie.ReleaseYear;
            //item.RunLength = movie.RunLength;

            
        }
        //Creted 02/03/20 finding the movie by id number
        private Movie FindById(int id )
        {
            foreach (var movie in _movies)
            {
                if (movie.Id == id)
                    return movie;
            };
            return null;
        }
    }
}
