﻿//Carlos Vargas
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
using CharacterCreator.Bussiness.Memory;
using CharacterCreator.WinForms;

namespace CharacterCreator
{
    public partial class MainForm : Form
    {

        private readonly ICharacterRoster _characters;
        public MainForm()
        {
            InitializeComponent();

            _character = new MemoryCharacterDatabase();
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

            do
            {
                if (child.ShowDialog(this)  != DialogResult.OK)
                    return;

                var character = _characters.Add(child.Character);
                if (character != null)
                {
                    UpdateUI();
                    return;
                }
                DisplayError("Failed");
            } while (true);
        }

        protected override void OnLoad (EventArgs e)
        {
            base.OnLoad(e);

            _characters.SeedIfEmpty();

            UpdateUI();
        }

        private Character GetSelectedCharacter ()
        {
            return listCharacters.SelectedItem as Character;
        }

        private void UpdateUI ()
        {
            listCharacters.Items.Clear();

            var characters = from character in _characters.GetAll()
                             where character.Id > 0
                             orderby character.Name descending
                             select character;

            listCharacters.Items.AddRange(characters.ToArray());

        }
        private void OnEditCharacter(object sender, EventArgs e)
        {
            var character = GetSelectedCharacter();
            if (character == null)
                return;

            var child = new MainForm();
            child._character = character;

            do
            {
                if (child.ShowDialog(this) != DialogResult.OK)
                    return;

                var error = _characters.Update(character.Id, child._character);
                if (String.IsNullOrEmpty(error))
                {
                    UpdateUI();
                    return;

                }
                DisplayError( error);

            } while (true);


            
        }

        private void OnDeleteCharacter(object sender, EventArgs e)
        {
            var character = GetSelectedCharacter();

            if (character == null)
                return;

            if (!DisplayConfirmation($"Are you sure you want to delete {character.Name}?", "DELETE"))
                return;

            _characters.Delete(character.Id);
            UpdateUI();
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
