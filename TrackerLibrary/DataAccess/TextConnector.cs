using System;
using System.Collections.Generic;
using System.Text;
using TrackerLibrary.Models;
using System.Linq;
using System.Configuration;
using TrackerLibrary.DataAccess.TextHelpers;

namespace TrackerLibrary.DataAccess
{
    public class TextConnector : IDataConnection
    {

        private const string PrizesFile = "PrizeModels.csv";
        private const string PersonsFile = "PersonsModels.csv";
        private const string TeamsFile = "TeamModels.csv";
        private const string TournamentFile = "TournamentModels.csv";
        private const string MatchupFile = "MatchupModels.csv";
        private const string MatchupEntryFile = "MatchupEntryModels.csv";



        public PersonModel CreatePerson(PersonModel model)
        {
            List<PersonModel> persons = PersonsFile.FullFilePath().LoadFile().ConvertToPersonModels();

            int currentId = 1;
            if (persons.Count > 0)
            {
                currentId = persons.OrderByDescending(x => x.Id).First().Id + 1;
            }

            model.Id = currentId;
            currentId += 1;

            persons.Add(model);

            persons.SaveToPersonFile(PersonsFile);

            return model;
        }


        //TODO - Wire up the CreatePrize for the text files.
        public PrizeModel CreatePrize(PrizeModel model)
        {
            List<PrizeModel> prizes = PrizesFile.FullFilePath().LoadFile().ConvertToPrizeModels();

            int currentId = 1;
            if (prizes.Count >0)
            {
                currentId = prizes.OrderByDescending(x => x.Id).First().Id + 1;
            }
               
            model.Id = currentId;
            currentId += 1;

            prizes.Add(model);

            prizes.SaveToPrizeFile(PrizesFile);

            return model;
        }

        public TeamModel CreateTeam(TeamModel model)
        {
            List<TeamModel> teams = TeamsFile.FullFilePath().LoadFile().ConvertToTeamsModels(PersonsFile);

            //Find the max ID
            int currentID = 1;
            if (teams.Count > 0)
            {
                currentID = teams.OrderByDescending(x => x.Id).First().Id + 1;
            }
            model.Id = currentID;
            teams.Add(model);
            teams.SaveToTeamFile(TeamsFile);
            return model;

        }

        public void CreateTournament(TournamentModel model)
        {
            List<TournamentModel> tournaments = TournamentFile
                .FullFilePath()
                .LoadFile()
                .ConvertToTournamentModels(TeamsFile, PersonsFile,PrizesFile);

            int currentID = 1;
            if (tournaments.Count > 0)
            {
                currentID = tournaments.OrderByDescending(x => x.Id).First().Id + 1;
            }
            model.Id = currentID;

            model.SaveRoundsToFile(MatchupFile, MatchupEntryFile);

            tournaments.Add(model);

            tournaments.SaveToTournamentFile(TournamentFile);

        }

        public List<PersonModel> GetPerson_All()
        {
            return PersonsFile.FullFilePath().LoadFile().ConvertToPersonModels();
        }

        public List<TeamModel> GetTeam_All()
        {
            return TeamsFile.FullFilePath().LoadFile().ConvertToTeamsModels(PersonsFile);
        }

        public List<TournamentModel> GetTournament_All()
        {
           return TournamentFile
               .FullFilePath()
               .LoadFile()
               .ConvertToTournamentModels(TeamsFile, PersonsFile, PrizesFile);
        }

        public void UpdateMatchup(MatchupModel model)
        {
            model.UpdateMatchupToFile();
        }
    }
}
