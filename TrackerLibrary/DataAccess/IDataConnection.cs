﻿using System;
using System.Collections.Generic;
using System.Text;
using TrackerLibrary.Models;
using System.IO;


namespace TrackerLibrary.DataAccess
{
    public interface IDataConnection
    {
        PrizeModel CreatePrize(PrizeModel model);

        PersonModel CreatePerson(PersonModel model);

        TeamModel CreateTeam(TeamModel model);

        void CreateTournament(TournamentModel model);
        void UpdateMatchup(MatchupModel model);
        List<TeamModel> GetTeam_All();
        List<PersonModel> GetPerson_All();

        List<TournamentModel> GetTournament_All();

    }
}
