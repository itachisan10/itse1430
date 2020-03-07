//Carlos Vargas
//ITSE-1430
//Character Creator
//03/07/2020
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CharacterCreator.Bussiness;
using CharacterCreator.WinForms;

namespace CharacterCreator
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private bool DisplayConfirmation(string message, string name)
        {
            //Display a confirmation dialog
            var result = MessageBox.Show(message, name, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            //Return true if user selected OK
            return result == DialogResult.OK;
        }

        private void DisplayError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        void DisplayCharacter(Character character)
        {
            if (character == null)
                return;

            var name = character.Name;

            character = new Character();
        }

        private void OnAddCharacter(object sender, EventArgs e)
        {
            CharacterCreator child = new CharacterCreator();

            if (child.ShowDialog(this) != DialogResult.OK)
                return;

            //save character info 
            _character = child.Character;
        }

        private void OnEditCharacter(object sender, EventArgs e)
        {
            var child = new CharacterCreator();
            if (_character == null)
                return;


            child.Character = _character;
            if (child.ShowDialog(this) != DialogResult.OK)
                return;

            //edit
            _character = child.Character;
        }

        private void OnDeleteCharacter(object sender, EventArgs e)
        {
            if (_character == null)
                return;

            if (!DisplayConfirmation($"Are you sure you want to delete {_character.Name}?", "Delete"))
                return;

            //Delete
            _character = null;
        }

        private void OnExitFile(object sender, EventArgs e)
        {
            //Close file
            Close();
        }

        private void OnAboutHelp(object sender, EventArgs e)
        {
            var about = new AboutBox();

            about.ShowDialog(this);
        }

        private Character _character;

        protected override void  OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (_character != null)
                if (!DisplayConfirmation("Are you sure you want to close?", "Close"))
                    e.Cancel = true;
        }
    }
}
