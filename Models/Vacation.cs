using System;

namespace travel.Models
{
    public abstract class Vacation
    {
        public double Price { get; set; }

        public string Destination { get; set; }

        public int Occupants { get; set; }

        public DateTime DepartureDate { get; set; }
        public DateTime ReturnDate { get; set; }

        public string Category { get; set; }
    }
}