using FSK_BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSK_DAOs
{
    public class KoiFishDAO
    {
        private readonly FengShuiKoiDbContext _dbContext;
        private static KoiFishDAO _instance;

        public static KoiFishDAO Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new KoiFishDAO();
                return _instance;
            }
        }

        private KoiFishDAO()
        {
            _dbContext = new FengShuiKoiDbContext();
        }

        public List<KoiFish> GetKoiFish()
        {
            return _dbContext.KoiFishes
                .Include(k => k.Elements)
                .Include(k => k.KoiType)
                .ToList();
        }

        public KoiFish GetKoiFishById(string id)
        {
            return _dbContext.KoiFishes
                .Include(k => k.Elements)
                .Include(k => k.KoiType)
                .SingleOrDefault(k => k.KoiId.Equals(id));
        }

        public bool AddKoiFish(KoiFish koiFish, List<int> elementIds)
        {
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    if (_dbContext.KoiFishes.Any(k => k.KoiId == koiFish.KoiId))
                    {
                        return false;
                    }

                    // Get the elements
                    var elements = _dbContext.Elements
                        .Where(e => elementIds.Contains(e.ElementId))
                        .ToList();

                    // Add elements to the fish
                    foreach (var element in elements)
                    {
                        koiFish.Elements.Add(element);
                    }

                    _dbContext.KoiFishes.Add(koiFish);
                    _dbContext.SaveChanges();
                    transaction.Commit();
                    return true;
                }
                catch
                {
                    transaction.Rollback();
                    return false;
                }
            }
        }

        public bool UpdateKoiFish(KoiFish koiFish, List<int> elementIds)
        {
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    var existingFish = _dbContext.KoiFishes
                        .Include(k => k.Elements)
                        .SingleOrDefault(k => k.KoiId == koiFish.KoiId);

                    if (existingFish == null)
                    {
                        return false;
                    }

                    // Update basic properties
                    existingFish.Name = koiFish.Name;
                    existingFish.Size = koiFish.Size;
                    existingFish.Weight = koiFish.Weight;
                    existingFish.Color = koiFish.Color;
                    existingFish.Description = koiFish.Description;
                    existingFish.KoiTypeId = koiFish.KoiTypeId;

                    // Clear existing elements
                    existingFish.Elements.Clear();

                    // Get and add new elements
                    var elements = _dbContext.Elements
                        .Where(e => elementIds.Contains(e.ElementId))
                        .ToList();

                    foreach (var element in elements)
                    {
                        existingFish.Elements.Add(element);
                    }

                    _dbContext.SaveChanges();
                    transaction.Commit();
                    return true;
                }
                catch
                {
                    transaction.Rollback();
                    return false;
                }
            }
        }

        public bool DeleteKoiFish(string koiId)
        {
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    var koiFish = _dbContext.KoiFishes
                        .Include(k => k.Elements)
                        .SingleOrDefault(k => k.KoiId == koiId);

                    if (koiFish == null)
                    {
                        return false;
                    }

                    // Clear related elements
                    koiFish.Elements.Clear();

                    // Remove the fish
                    _dbContext.KoiFishes.Remove(koiFish);

                    _dbContext.SaveChanges();
                    transaction.Commit();
                    return true;
                }
                catch
                {
                    transaction.Rollback();
                    return false;
                }
            }
        }

        public List<KoiFish> GetKoiFishByFilter(string search)
        {
            return _dbContext.KoiFishes
                .Include(k => k.Elements)
                .Include(k => k.KoiType)
                .Where(a => EF.Functions.Like(a.Name, "%" + search + "%"))
                .ToList();
        }
    }
}
