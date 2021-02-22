using System.ComponentModel.DataAnnotations;

namespace travel.Models
{
    class Trip : Vacation
    {
        [Required]
        public int Id { get; set; }

        public Trip(int id)
        {
            Id = id;
        }
    }
}