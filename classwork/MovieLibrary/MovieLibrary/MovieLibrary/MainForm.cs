using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MovieLibrary.Business;
using MovieLibrary.WinForms;

namespace MovieLibrary
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Represents a movie.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            // MovieLibrary.Business.Movie;

            //How to create an instance of a class.
          // Movie movie = new Movie();

   
          //  //memeber
          //  movie.title = "Jaws";
          //  movie.description = movie.title;

          //movie = new Movie();

            //DisplayMovie(movie);
            //DisplayMovie(null);
            //DisplayConfirmation("are you sure?", "Start");
        }

        private bool DisplayConfirmation(string message, string title)
        {
            //DialogResult
            var result = MessageBox.Show(message, "title", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            return result == DialogResult.OK;
        }
        /// <summary>
        /// Displays an error messsage
        /// </summary>
        /// <param name="message">Error to display.</param>
        void DisplayError(string message)
        {

            //var that = this;


            //var Text = ""; WONT FIND IT
            //var newTitle = this.Text;
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        void DisplayMovie (Movie movie)
        {
            if (movie == null)
                return; 

            var title = movie.Title;
            movie.Description = "Test";

            movie = new Movie();

        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (_movie != null)
                if (!DisplayConfirmation("Are you sure you want close?", "Close"))

                   e.Cancel = true;
            
        }

        private void OnMovieAdd(object sender, EventArgs e)
        {
            MovieForm child = new MovieForm();

            if (child.ShowDialog(this) != DialogResult.OK)
                return;

            //TODO: save the movie
            _movie = child.Movie;
            //child.Show(); can open multiple windows. 
        }

        private void OnMovieEdit(object sender, EventArgs e)
        {
            //verity movie
            if (_movie == null)
                return;

            MovieForm child = new MovieForm();
            child.Movie = _movie;

            if (child.ShowDialog(this) != DialogResult.OK)
                return;

            //TODO: save the movie
            _movie = child.Movie;
            //child.Show(); can open multiple windows. 
        }

        private Movie _movie;

        private void OnMovieDelete(object sender, EventArgs e)
        {
            //verity movie
            if (_movie == null)
                return;

            if (DisplayConfirmation($"Are you sure you want to delete{_movie.Title}?", "Delete"))
            return;

            //TODO: delete
            _movie = null;
        }

        private void OnFileExit(object sender, EventArgs e)
        {
            Close();
        }

        private void OnHelpAbout(object sender, EventArgs e)
        {
            var about = new AboutBox();

            about.ShowDialog(this);
        }
    }
}
//Classes are not primitives 
//always passed by value 
//methods -> fuctions
//methods are stored in the exsecutable 
///
