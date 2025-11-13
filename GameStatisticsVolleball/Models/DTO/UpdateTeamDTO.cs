using System.ComponentModel.DataAnnotations;

namespace GameStatisticsVolleball.Models.DTO
{
    public class UpdateTeamDTO
    {
        [Required(ErrorMessage = "Наименования обязательно")]
        [MinLength(2, ErrorMessage = "Имя должно содержать минимум 2 символа")]
        [MaxLength(50)]
        public string Name { get; set; } = null!;
        [Required(ErrorMessage = "Имя тренера обязательно")]
        [MinLength(2, ErrorMessage = "Имя должно содержать минимум 2 символа")]
        [MaxLength(50)]
        public string CoachName { get; set; } = null!;
        
    }
}
