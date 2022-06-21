using Cwiczenia7.Models.DTO;
using Cwiczenia7.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cwiczenia7.Services
{
    public interface IDbService
    {
        Task<IEnumerable<SomeSortOfTrip>> GetTripsAsync();   
        Task InsertClientAsync(SomeSortOfClientTrip client);
        Task RemoveClientAsync(int id);
        Task AssignToTripAsync(SomeSortOfClientTrip trip);
    }
}
