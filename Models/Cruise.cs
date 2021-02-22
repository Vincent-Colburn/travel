using System;
using System.ComponentModel.DataAnnotations;

namespace travel.Models
{
    public class Cruise : Vacation
    {
        [Required]
        public int Id { get; set; }

        // public Cruise(int id)
        // {
        //     Id = id;
        // }
        public Cruise()
        {
            Category = "Cruise";
        }
    }
}
