using Mighty_Maestro.Data;
using Mighty_Maestro.Models.Maestro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mighty_Maestro.Services
{
    public class MaestroService
    {
        private readonly Guid _userId;

        public MaestroService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateMaestro(MaestroCreate model)
        {
            var entity =
                new Maestro()
                {
                    OwnerId = _userId,
                    VenueId = model.VenueId,
                    MaestroName = model.MaestroName,
                    ProfessorId = model.ProfessorId,
                    //Password = model.Password,
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Venues.SingleOrDefault(v => v.VenueId == entity.VenueId).Maestros.Add(entity);
                ctx.Maestros.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<MaestroListItem> GetMaestros()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Maestros
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                                e =>
                                    new MaestroListItem
                                    {
                                        MaestroId = e.MaestroId,
                                        MaestroName = e.MaestroName,
                                        //TotalPoints = e.TotalPoints,
                                        //ScalesPoints = e.ScalesPoints,
                                        //ChordsPoints = e.ChordsPoints,
                                        //KeysPoints = e.KeysPoints,
                                        //ProgressionsPoints = e.ProgressionsPoints,
                                        //VenueAchieved = e.VenueAchieved,
                                        //Password = e.Password
                                    }
                        );
                return query.ToArray();
            }
        }
        public MaestroDetail GetMaestroById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Maestros
                        .Single(e => e.MaestroId == id && e.OwnerId == _userId);
                return
                    new MaestroDetail
                    {
                        MaestroId = entity.MaestroId,
                        MaestroName = entity.MaestroName,
                        TotalPoints = entity.TotalPoints,
                        ScalesPoints = entity.ScalesPoints,
                        ChordsPoints = entity.ChordsPoints,
                        KeysPoints = entity.KeysPoints,
                        ProgressionsPoints = entity.ProgressionsPoints,
                        VenueAchieved = entity.VenueAchieved,
                    };
            }
        }
        public bool UpdateMaestro(MaestroEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Maestros
                        .Single(e => e.MaestroId == model.MaestroId && e.OwnerId == _userId);

                entity.MaestroName = model.MaestroName;
                //entity.Password = model.Password;
                entity.MaestroId = model.MaestroId;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteMaestro(int maestroId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Maestros
                        .Single(e => e.MaestroId == maestroId && e.OwnerId == _userId);

                ctx.Maestros.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}