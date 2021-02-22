using System;
using System.Collections.Generic;
using System.Data;
using travel.Models;
using Dapper;


namespace travel.Repositories
{
    public class CruiseRepository
    {

        public readonly IDbConnection _db;

        public CruiseRepository(IDbConnection db)
        {
            _db = db;
        }
        public IEnumerable<Cruise> GetAll()
        {
            string sql = "SELECT * FROM cruises;";
            return _db.Query<Cruise>(sql);
        }

        internal Cruise GetById(int id)
        {
            string sql = "SELECT * FROM cruises WHERE id = @id;";
            return _db.QueryFirstOrDefault<Cruise>(sql, new { id });
        }

        internal Cruise Create(Cruise newCruise)
        {
            string sql = @"
        INSERT INTO cruises
        (price, destination, occupants, departuredate, returndate)
        VALUE
        (@Price, @Destination, @Occupants, @DepartureDate, @ReturnDate);
        SELECT LAST_INSERT_ID();";
            int id = _db.ExecuteScalar<int>(sql, newCruise);
            newCruise.Id = id;
            return newCruise;
        }

        internal Cruise Edit(Cruise original)
        {
            string sql = @"
        UPDATE cruises
        SET
            price = @Price,
            destination = @Destination, 
            occupants = @Occupants, 
            depatureDate = @DepartureDate,
            returnDate = @ReturnDate
        WHERE id = @id;
        SELECT * FROM cruises WHERE id = @id;";

            return _db.QueryFirstOrDefault<Cruise>(sql, original);
        }

        internal void Delete(Cruise cruise)
        {
            string sql = "DELETE FROM Cruises WHERE id = @id";
            _db.Execute(sql, cruise);
        }

    }
}