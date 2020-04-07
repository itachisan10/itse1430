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


namespace CharacterCreator
{
    public partial class CharacterCreator : Form
    {
        public CharacterCreator()
        {
            InitializeComponent();
        }

       public CharacterCreator (Character character) : this(character != null ? "Edit" : "Add", character)
        {

        }

        public CharacterCreator(string name, Character character) : this()
        {
            Name = name;
            Character = character;

        }

        public Character Character
        {
            get { return _character; }
            set { _character = value; }
        }
        private Character _character;

        private void OnOk(object sender, EventArgs e)
        {
            if (!ValidateChildren())
                return;

            var character = GetCharacter();
            var errors = ObjectValidator.Validate(character);

            if (errors.Any())
            {
                DisplayError("ERROR");
                return;

            }
            Character = character;
            DialogResult = DialogResult.OK;
            Close();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            var races = Races.GetAll();
            ddlRace.Items.AddRange(races);

            var attributes = Attributes.GetAll();
          
            var professions = Professions.GetAll();
            ddlProfession.Items.AddRange(professions);

            if(Character != null)
            {
                txtName.Text = Character.Name;
                txtDescription.Text = Character.Description;

                if (Character.Race != null)
                    ddlRace.SelectedText = Character.Race.Description;

                if (Character.Profession != null)
                    ddlProfession.SelectedText = Character.Profession.Description;

            };
        }

        private Character GetCharacter()
        {
            var character = new Character();

            character.Name = txtName.Text?.Trim();
            if (ddlProfession.SelectedItem is Profession profession)
                character.Profession = profession;
            if (ddlRace.SelectedItem is Race race)
                character.Race = race;
            character.Description = txtDescription.Text?.Trim();
            return character;

        }

        void DisplayError(string message)
        {
            //var that = this;
            //var Text = ""; WONT FIND IT
            //var newTitle = this.Text;
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void OnCancel(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close(); //<- dismisses form 
        }

        private void dwStrength_ValueChanged ( object sender, EventArgs e )
        {

        }
    }
}
