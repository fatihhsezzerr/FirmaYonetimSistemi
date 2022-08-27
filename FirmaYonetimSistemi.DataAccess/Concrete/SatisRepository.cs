using FirmaYonetimSistemi.DataAccess.Abstract;
using FirmaYonetimSistemi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirmaYonetimSistemi.DataAccess.Concrete
{
    public class SatisRepository : ISatisRepository
    {
        public Satis CreateSatis(Satis Satis)
        {
            using (var firmaDbContext = new FirmaDbContext())
            {
                firmaDbContext.Satislar.Add(Satis);
                firmaDbContext.SaveChanges();
                return Satis;
            }
        }

        public void DeleteSatis(int id)
        {
            using (var firmaDbContext = new FirmaDbContext())
            {
                var deletedSatis = GetSatisById(id);
                firmaDbContext.Satislar.Remove(deletedSatis);
                firmaDbContext.SaveChanges();
            }
        }

        public List<Satis> GetAllSatislar()
        {
            using (var firmaDbContext = new FirmaDbContext())
            {
                return firmaDbContext.Satislar.ToList();
            }
        }

        public Satis GetSatisById(int id)
        {
            using (var firmaDbContext = new FirmaDbContext())
            {
                return firmaDbContext.Satislar.Find(id);
            }
        }

        public Satis UpdateSatis(Satis Satis)
        {
            using (var firmaDbContext = new FirmaDbContext())
            {
                firmaDbContext.Satislar.Update(Satis);
                firmaDbContext.SaveChanges();
                return Satis;
            }
        }

    }
}
