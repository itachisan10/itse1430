using System;
using System.Linq; //Language integrated natural query 
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MovieLibrary.Business;
using MovieLibrary.Business.Memory;
using MovieLibrary.WinForms;
using MovieLibrary.Business.FileSystems;
using System.Configuration;
using MovieLibrary.Business.SqlServer;

namespace MovieLibrary
{
    public partial class MainForm : Form
    {
        #region Construction

        public MainForm ()
        {
            InitializeComponent();

            _movies = new MemoryMovieDatabase();
            #region Playing with objects

            //Full name
            //MovieLibrary.Business.Movie;
            //var movie = new Movie();

            //movie.title = "Jaws";
            //movie.description = movie.title;

            //movie = new Movie();

            //DisplayMovie(movie);
            //DisplayMovie(null);
            //DisplayConfirmation("Are you sure?", "Start");
            #endregion
        }
        #endregion

        private bool DisplayConfirmation ( string message, string title )
        {
            //Display a confirmation dialog
            var result = MessageBox.Show(message, title, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            //Return true if user selected OK
            return result == DialogResult.OK;
        }

        /// <summary>Displays an error message.</summary>
        /// <param name="message">Error to display.</param>
        private void DisplayError ( string message )
        {
            #region Playing with this

            //this represents the current instance
            //var that = this;

            //var Text = "";

            //These are equal
            //var newTitle = this.Text;
            //var newTitle = Text;
            #endregion

            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #region Playing with methods

        void DisplayMovie ( Movie movie )
        {
            if (movie == null)
                return;

            var title = movie.Title;
            movie.Description = "Test";

            movie = new Movie();
        }
        #endregion

        private void OnMovieAdd ( object sender, EventArgs e )
        {
            MovieForm child = new MovieForm();

            do
            {
                //child.Show(); //Modeless, both windows are interactive
                //Modal - must dismiss child form before main form is accessible
                if (child.ShowDialog(this) != DialogResult.OK)
                    return;

                //TODO: Save the movie
                var movie = _movies.Add(child.Movie);
                if (movie != null)
                {
                    UpdateUI();
                    return;
                };
                DisplayError("Add failed");
            } while (true);
        }

        //private string SortByTitle ( Movie movie ) => movie.Title;
        //private int SortByReleaseYear ( Movie movie ) => movie.ReleaseYear;

        private void UpdateUI ()
        {
            lstMovies.Items.Clear();

            //Extension method Approach 
            //var movies = _movies.GetAll()
            //                    .OrderBy(movie =>movie.Title) //IEnumerable<T> OrderBy<T> (this IEnumeralbe<T> source, Func<T>, string sorter);
            //                    .ThenBy(movie => movie.ReleaseYear);

            //Error handling = try - catch block
            //try
            //{ S* }
            //catch(T id)
            //{ S* }
            //
            //
            var movies = Enumerable.Empty<Movie>();
            try 
            {
                movies = _movies.GetAll();
            } 
            catch (Exception e)
            { 
                DisplayError($"Failed to load movies: {e.Message}");
            };
            //LINQ syntax
            //from
            //select
            movies = from movie in movies
                         where movie.Id > 0
                         orderby movie.Title, movie.ReleaseYear descending 
                         select movie;


            lstMovies.Items.AddRange(movies.ToArray());
            //foreach (var movie in movies)
            //{
            //    lstMovies.Items.Add(movie);
            //};

        }

        protected override void OnLoad ( EventArgs e )
        {
           base.OnLoad(e);
            
            var connString = ConfigurationManager.ConnectionStrings["MovieDatabase"];
            _movies = new SqlMovieDatabase(connString.ConnectionString);

            //new System.Data.SqlClient.SqlConnection(connString.ConnectionString).Open();
            //SeedDatabase.SeedIfEmpty(_movies);
            //call extension methoed as thougth it is an instance Discover it.
            //try
            //{
            //    _movies.SeedIfEmpty();
            //} catch (InvalidOperationException)
            //{
            //    DisplayError("Invalid OP");
            //} catch (ArgumentException)
            //{
            //    DisplayError("Invalid argument");
            //} catch( Exception ex)
            //{
            //    DisplayError(ex.Message);
            //}

            UpdateUI();
        }

        private Movie GetSelectedMovie ()
        {
            //preferred
            //return lstMovies.SelectedItem as Movie;

            var selectedItems = lstMovies.SelectedItems.OfType<Movie>();

            //T? FirstOrDefault (This IEnumerable<T>) :: returns first item that meets criteria or default for type if none
            //T? LastOrDefault (this IEnumerable<T>) :: returns last item that meets criteria or default for tpe if none; not always supported 

            //T First (this IEnumerable<T>) :: returns first item that meets criteria or blows up 
            //T Last (this IEnumerable<T>) :: returns last item that meets criteria or blows up 
            return selectedItems.FirstOrDefault();
        }

        private void OnMovieEdit ( object sender, EventArgs e )
        {
            //Verify movie
            var movie = GetSelectedMovie();
            if (movie == null)
                return;

            var child = new MovieForm();
            child.Movie = movie;
            do
            {
                if (child.ShowDialog(this) != DialogResult.OK)
                    return;

                //TODO: Save the movie
                var error = _movies.Update(movie.Id, child.Movie);
                if (!String.IsNullOrEmpty(error))
                {
                    UpdateUI();
                    return;
                };

                DisplayError(error);
            } while (true);
        }

        private void OnMovieDelete ( object sender, EventArgs e )
        {
            //Verify movie
            var movie = GetSelectedMovie();
            if (movie == null)
                return;

            //Confirm
            if (!DisplayConfirmation($"Are you sure you want to delete {movie.Title}?", "Delete"))
                return;

            //TODO: Delete
            _movies.Delete(movie.Id);
        }

        private void OnFileExit ( object sender, EventArgs e )
        {
            Close();
        }

        private void OnHelpAbout ( object sender, EventArgs e )
        {
            var about = new AboutBox();

            about.ShowDialog(this);
        }

        private void MainForm_Load ( object sender, EventArgs e )
        {

        }

        private IMovieDatabase _movies;
    }
}
//Classes are not primitives 
//always passed by value 
//methods -> fuctions
//methods are stored in the exsecutable 
///
