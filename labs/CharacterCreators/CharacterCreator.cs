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
            var character = GetCharacter();
            if (!character.Validate(out var error))
            {
                DisplayError(error);
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
            ddlAttributes.Items.AddRange(attributes);

            var professions = Professions.GetAll();
            ddlProfession.Items.AddRange(professions);

            if(Character != null)
            {
                txtName.Text = Character.Name;
                txtDescription.Text = Character.Description;

                if (Character.Race != null)
                    ddlRace.SelectedText = Character.Race.Description;
                if (Character.Attribute != null)
                    ddlAttributes.SelectedText = Character.Attribute.Description;
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
            if (ddlAttributes.SelectedItem is Bussiness.Attribute attribute)
                character.Attribute = attribute;
            character.Description = txtDescription.Text?.Trim();
            return character;

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

        private void OnCancel(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close(); //<- dismisses form 
        }


    }
}
