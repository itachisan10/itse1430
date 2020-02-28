using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CharacterCreator.WinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private bool DisplayConfirmation(string message, string name)
        {
            var result = MessageBox.Show(message, "Name", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            return result == DialogResult.OK;
        }

        void DisplayError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        void DisplayCharacter (Character character)
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

            _character = child.Character;
        }
    

        private void OnEditCharacter(object sender, EventArgs e)
        {
            if (_character == null)
                return;

            CharacterCreator child = new CharacterCreator();


        }
    }
}
