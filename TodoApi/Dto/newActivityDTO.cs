using System.ComponentModel.DataAnnotations;

namespace TodoApi.Dto
{
    public class newActivityDTO
    {
        [Required]
        public string userName { get; set; }
        [Required]
        public string details { get; set; }
    }
}