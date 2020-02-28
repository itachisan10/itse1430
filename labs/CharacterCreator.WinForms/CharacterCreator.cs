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
    public partial class CharacterCreator : Form
    {
        public CharacterCreator()
        {
            InitializeComponent();
        }

        //public CharacterCreator (Character character) : this(character != null ? "Edit" : "Add", character)
        //{

        //}

        //public CharacterCreator (string name, Character character) : this()
        //{
        //    Text = name;
        //    Character = character;
        //}

        public Character Character
        {
            get { return _character; }
            set { _character = value; }
        }
        private Character _character;
        private void OnOkay(object sender, EventArgs e)
        {
            Close();
        }

        private void OnCancel(object sender, EventArgs e)
        {
            Close();
        }

        void DisplayError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
