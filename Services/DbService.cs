using Cwiczenia7.Exceptions;
using Cwiczenia7.Models;
using Cwiczenia7.Models.DTO;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cwiczenia7.Services
{
    public class DbService : IDbService
    {
        private readonly masterContext _dbContext;
        public DbService(masterContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<SomeSortOfTrip>> GetTripsAsync()
        {
            return await _dbContext.Trips
                .Include(e => e.CountryTrips)
                .Include(e => e.ClientTrips)
                .Select(e => new SomeSortOfTrip
                {
                    Name = e.Name,
                    Description = e.Description,
                    MaxPeople = e.MaxPeople,
                    DateFrom = e.DateFrom,
                    DateTo = e.DateTo,
                    Countries = e.CountryTrips.Select(e => new SomeSortOfCountry { Name = e.IdCountryNavigation.Name}).ToList(),
                    Clients = e.ClientTrips.Select(e => new SomeSortOfClient { FirstName = e.IdClientNavigation.FirstName, LastName = e.IdClientNavigation.LastName})
                }).OrderByDescending(c => c.DateFrom).ToListAsync();
        }
        public async Task RemoveClientAsync(int id)
        {
            var client = await _dbContext.Clients.Where(e => e.IdClient == id).FirstOrDefaultAsync();
            if (client == null) throw new ClientNotFoundException();
            if (client.ClientTrips.Count > 0) throw new TripsAssignedException();
            _dbContext.Remove(client);
            await _dbContext.SaveChangesAsync();
        }
        
        public async Task AssignToTripAsync(SomeSortOfClientTrip trip)
        {
            var client = _dbContext.Clients.FirstOrDefault(e => e.Pesel == trip.Pesel);
            if(client == null) await InsertClientAsync(trip);

            var clientTrip = await _dbContext.Trips.FirstOrDefaultAsync(e => e.IdTrip == trip.IdTrip);
            if( clientTrip == null) throw new TripNotFoundException();

            var tripAlreadyAssigned = await _dbContext.ClientTrips.FirstOrDefaultAsync(e => e.IdClient == client.IdClient && e.IdTrip == trip.IdTrip);
            if (tripAlreadyAssigned != null) throw new ClientAssignedToTripException();

            var addClientTrip = new ClientTrip { IdClient = client.IdClient, IdTrip = clientTrip.IdTrip, IdClientNavigation = client, IdTripNavigation = clientTrip, PaymentDate = trip.PaymentDate, RegisteredAt = System.DateTime.Now};
            _dbContext.Add(addClientTrip);

            clientTrip.ClientTrips.Add(addClientTrip);

            await _dbContext.SaveChangesAsync();
        }

        public async Task InsertClientAsync(SomeSortOfClientTrip client)
        {
            await _dbContext.AddAsync(new Client
            {
                FirstName = client.FirstName,
                LastName = client.LastName,
                Email = client.Email,
                Telephone = client.Telephone,
                Pesel = client.Pesel
            });
            await _dbContext.SaveChangesAsync();
        }
    }
}
