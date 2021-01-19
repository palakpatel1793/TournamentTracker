﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrackerLibrary;
using TrackerLibrary.Models;

namespace TrackerUI
{
    public partial class CreateTournamentForm : Form
    {

        List<TeamModel> availableTeams = GlobalConfig.Connection.GetTeam_All();
        List<TeamModel> selectedTeams = new List<TeamModel>();
        List<PrizeModel> selectedPrizes = new List<PrizeModel>();
        public CreateTournamentForm()
        {
            InitializeComponent();
            WireUpLists();

        }

        private void WireUpLists()
        {
            selectTeamDropDown.DataSource = null;
            selectTeamDropDown.DataSource = availableTeams;
            selectTeamDropDown.DisplayMember = "TeamName";

            tournamentTeamsListBox.DataSource = null;
            tournamentTeamsListBox.DataSource = selectedTeams;
            tournamentTeamsListBox.DisplayMember = "TeamName";

            prizesListbox.DataSource = null;
            prizesListbox.DataSource = selectedPrizes;
            prizesListbox.DisplayMember = "";

        }

        private void headerLabel_Click(object sender, EventArgs e)
        {

        }

        private void prizesLabel_Click(object sender, EventArgs e)
        {

        }

        private void addTeamButton_Click(object sender, EventArgs e)
        {
           
            TeamModel t = (TeamModel)selectTeamDropDown.SelectedItem;

            if (t != null)
            {
                {
                    availableTeams.Remove(t);
                    selectedTeams.Add(t);

                    WireUpLists();
                }
            }

        }

        private void createPrizeButton_Click(object sender, EventArgs e)
        {
            // Call the CreatePrizeForm

            //CreatePrizeForm frm = new CreatePrizeForm();
            //frm.Show();

            
        }

        public void PrizeComplete(PrizeModel model)
        {
            // Get back from the form a PrizeModel
            //Take the PrizeModel and put it into of selected prizes

            selectedPrizes.Add(model);
            WireUpLists();


        }
    }
}
