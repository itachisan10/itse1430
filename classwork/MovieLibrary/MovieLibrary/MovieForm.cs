using MovieLibrary.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieLibrary.WinForms
{
    public partial class MovieForm : Form
    {
        public MovieForm()
        {
            InitializeComponent();
        }

        // call the more specific constructor first - constructor chaining.
        public MovieForm (Movie movie) : this(movie != null ? "Edit" : "Add", movie)
        {
            //InitializeComponent();
            //Movie = movie;

            //Text = movie != null ? "Edit" : "Add";
        }

        public MovieForm(string title, Movie movie) : this()
        {
            Text = title;
            Movie = movie;
        }

        //private void Initialize (string title, Movie movie)
        //{
        //    InitializeComponent();
        //    Text = title;
        //    Movie = movie;
        //}

        public Movie Movie
        {
            get { return _movie; }
            set { _movie = value; }
        }
        private Movie _movie;

        private void OnCancel(object sender, EventArgs e)
        {
            //TODO: Validation and error reporting.
            DialogResult = DialogResult.Cancel;
            Close(); //<- dismisses form 
        }
        private void OnOk(object sender, EventArgs e)
        {
            if (!ValidateChildren())
                return;

            //TODO: Validation and error reporting.
            var movie = GetMovie();
            if (!movie.Validate(out var error))
            {
                DisplayError(error);
                return;
            }            

            Movie = movie;
            DialogResult = DialogResult.OK;
            Close(); //<- dismisses form 
        }
        protected override void OnLoad(EventArgs e)
        {
            
            base.OnLoad(e);

            //populate combo
            var genres = Genres.GetAll();
            ddlGenres.Items.AddRange(genres);

            if (Movie != null)
            {
                txtTitle.Text = Movie.Title;
                txtDescription.Text = Movie.Description;
                txtReleaseYear.Text = Movie.ReleaseYear.ToString();
                txtRunLength.Text = Movie.RunLength.ToString();
                chkIsClassic.Checked = Movie.IsClassic;

                if (Movie.Genre != null)
                    ddlGenres.SelectedText = Movie.Genre.Description;
                //triggering validation option 
                ValidateChildren();
            };
        }

        private Movie GetMovie()
        {
            var movie = new Movie();

            //null conditional example
            //No string property will ever return null
            movie.Title = txtTitle.Text?.Trim();
            movie.RunLength = GetAsInt32(txtRunLength);
            movie.ReleaseYear = GetAsInt32(txtReleaseYear, 1900);
            movie.Description = txtDescription.Text.Trim();
            movie.IsClassic = chkIsClassic.Checked;

            // C-style, crashes if wrong
            //movie.Genre = (Genre)ddlGenres.SelectedItem; // only used when nothing else will work..extremely rare

            // Preferred - as operator
            //var genre = ddlGenres.SelectedItem as Genre; 
            //if (genre != null)
            //    movie.Genre = genre;

            //as is equals to 
            //if (ddlGenres.SelectedItem is Genre)
            //genre = (Genre)ddlGenres.SelectedItem;

            //Pattern match
            if (ddlGenres.SelectedItem is Genre genre)
                movie.Genre = genre;
            //movie.Genre = ddlGenres.SelectedItem;


            return movie;
            
            
           
        }            

        private int GetAsInt32(Control control)
        {
            return GetAsInt32(control, 0);
        }
        
        private int GetAsInt32(Control control, int emptyValue)
        {
            //if users doesnt enter anything 0 will be displayed
            if (String.IsNullOrEmpty(control.Text))
                return emptyValue;
            //taking a string and trying to turn it into an int
            if (Int32.TryParse(control.Text, out var result))
                return result;

            return -1;
        }
        void DisplayError(string message)
        {
            //var that = this;
            //var Text = ""; WONT FIND IT
            //var newTitle = this.Text;
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void OnValidateTitle ( object sender, CancelEventArgs e )
        {
            var control = sender as TextBox;

            if (String.IsNullOrEmpty(control.Text))
            {
                //DisplayError("Title is requiredz");     
                _errors.SetError(control, "Title is requiredz");
                e.Cancel = true;
            } else
                _errors.SetError(control, "");
        }

        private void OnValidateRunLength ( object sender, CancelEventArgs e )
        {
            var control = sender as Control;
            var value = GetAsInt32(control, 0);
            if (value < 0)
            {
                //DisplayError("Run length must be >= 0.");
                _errors.SetError(control, "Run length must be >= 0.");
                e.Cancel = true;
            } else
                _errors.SetError(control, "");
        }
        private void OnValidateReleaseYear ( object sender, CancelEventArgs e )
        {
            var control = sender as Control;
            var value = GetAsInt32(control, 1900);
            if (value < 1900)
            {
                //DisplayError("Release year must be >= 0.");
                _errors.SetError(control, "Release year must be >= 0.");
                e.Cancel = true;
            } else
                _errors.SetError(control, "");
        }
    }
}
