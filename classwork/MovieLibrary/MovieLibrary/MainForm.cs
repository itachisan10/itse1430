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
           Movie movie = new Movie();

   
            //memeber
            movie.title = "Jaws";
            movie.description = movie.title;

          movie = new Movie();

            //DisplayMovie(movie);
            //DisplayMovie(null);
            DisplayConfirmation("are you sure?", "Start");
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

            var title = movie.title;
            movie.description = "Test";

            movie = new Movie();

        }
    }
}
//Classes are not primitives 
//always passed by value 
//methods -> fuctions
//methods are stored in the exsecutable 
///
