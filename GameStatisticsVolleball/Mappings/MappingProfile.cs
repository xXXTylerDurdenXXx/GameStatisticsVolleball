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

           
            CreateMap<Player, PlayerDTO>()
                .ForPath(dest => dest.TeamName, opt => opt.MapFrom(src => src.Team.Name))
                .ForPath(dest => dest.PositionName, opt => opt.MapFrom(src => src.Position.NamePosition));

            CreateMap<CreateTeamDTO, Team>();
            CreateMap<UpdateTeamDTO, Team>();
            CreateMap<Team, TeamDTO>();

            CreateMap<CreateTournamentDTO, Tournament>();

            CreateMap<CreatePositionDTO, Position>();

            CreateMap<CreateMatchDTO, Match>();

            CreateMap<CreatePlayerMatchStatsDTO, PlayerMatchStats>();
            
        }
    }
}
