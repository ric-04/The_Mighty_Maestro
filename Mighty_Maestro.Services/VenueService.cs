using Mighty_Maestro.Data;
using Mighty_Maestro.Models.Venue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mighty_Maestro.Services
{
    public class VenueService
    {
        private readonly Guid _userId;

        public VenueService(Guid userId)
        {
            _userId = userId;
        }
        
        public IEnumerable<VenueListItem> GetVenues()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Venues
                        //.Where(e => e.OwnerId == _userId) // <-> Line 19 in VenueController.cs
                        .Select(
                                e =>
                                    new VenueListItem
                                    {
                                        Name = e.Name,
                                        //PointsRequired = e.PointsRequired,
                                        VenueId = e.VenueId,
                                    }
                        );
                return query.ToArray();
            }
        }
        public VenueDetail GetVenueById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Venues
                        .Single(e => e.VenueId == id /*&& e.OwnerId == _userId*/);
                return
                    new VenueDetail
                    {
                        Name = entity.Name,
                        VenueId = entity.VenueId,
                        Stage = entity.Stage,
                        PointsRequired = entity.PointsRequired,
                        Questions = entity.Questions
                    };
            }
        }
    }
}