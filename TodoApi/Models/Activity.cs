using System.ComponentModel.DataAnnotations;

namespace TodoApi.Models
{
    public class Activity
    {
        public long Id{get; set;}
        [Required]
        public string userName {get; set;}
        [Required]
        public string details {get; set;}
    }
}