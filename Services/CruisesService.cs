using System;
using System.Collections.Generic;
using travel.Models;
using travel.Repositories;

namespace travel.Services
{
    public class CruisesService
    {
        private readonly CruiseRepository _repo;

        public CruisesService(CruiseRepository repo)
        {
            _repo = repo;
        }

        internal IEnumerable<Cruise> Get()
        {
            return _repo.GetAll();
        }

        internal Cruise Get(int id)
        {
            Cruise cruise = _repo.GetById(id);
            if (cruise == null)
            {
                throw new Exception("invalid ID");
            }
            return cruise;
        }

        internal Cruise Create(Cruise newCruise)
        {
            return _repo.Create(newCruise);
        }

        internal Cruise Edit(Cruise editCruise)
        {
            Cruise original = Get(editCruise.Id);

            original.Price = editCruise.Price > 0 ? editCruise.Price : original.Price;
            original.Destination = editCruise.Destination != null ? editCruise.Destination : original.Destination;
            original.Occupants = editCruise.Occupants > 0 ? editCruise.Occupants : original.Occupants;
            original.DepartureDate = editCruise.DepartureDate != null ? editCruise.DepartureDate : original.DepartureDate;
            original.ReturnDate = editCruise.ReturnDate != null ? editCruise.ReturnDate : original.ReturnDate;

            return _repo.Edit(original);
        }

        internal Cruise Delete(int id)
        {
            Cruise cruise = Get(id);
            _repo.Delete(cruise);
            return cruise;
        }



    }
}