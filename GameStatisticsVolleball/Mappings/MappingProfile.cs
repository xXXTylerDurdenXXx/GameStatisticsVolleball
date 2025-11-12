namespace GameStatisticsVolleball.Mappings
{
    using AutoMapper;
    using GameStatisticsVolleball.Models;
    using GameStatisticsVolleball.Models.DTO;
    public class MappingProfile: Profile
    {
        public MappingProfile() 
        {
            CreateMap<CreatePlayerDTO, Player>();
            CreateMap<UpdatePlayerDTO, Player>();

            CreateMap<CreateTeamDTO, Team>();
            CreateMap<UpdateTeamDTO, Team>();

            CreateMap<CreateTournamentDTO, Tournament>();

            CreateMap<CreatePositionDTO, Position>();

            CreateMap<CreateMatchDTO, Match>();

            CreateMap<CreatePlayerMatchStatsDTO, PlayerMatchStats>();
            
        }
    }
}
