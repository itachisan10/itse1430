﻿using System.Collections.Generic;

namespace MovieLibrary.Business
{
    public interface IMovieDatabase
    {

        // properties are allowed 
        //string Title { get; }

        Movie Add ( Movie movie );
        void Delete ( int id );
        Movie Get ( int id );
        IEnumerable<Movie> GetAll ();
        string Update ( int id, Movie movie );
    }
}