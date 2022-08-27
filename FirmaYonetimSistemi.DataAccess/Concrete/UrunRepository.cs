using FirmaYonetimSistemi.DataAccess.Abstract;
using FirmaYonetimSistemi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirmaYonetimSistemi.DataAccess.Concrete
{
    public class UrunRepository : IUrunRepository
    {
        public Urun CreateUrun(Urun Urun)
        {
            using (var firmaDbContext = new FirmaDbContext())
            {
                firmaDbContext.Urunler.Add(Urun);
                firmaDbContext.SaveChanges();
                return Urun;
            }
        }

        public void DeleteUrun(int id)
        {
            using (var firmaDbContext = new FirmaDbContext())
            {
                var deletedUrun = GetUrunById(id);
                firmaDbContext.Urunler.Remove(deletedUrun);
                firmaDbContext.SaveChanges();
            }
        }

        public List<Urun> GetAllUruns()
        {
            using(var firmaDbContext = new FirmaDbContext())
            {
                return firmaDbContext.Urunler.ToList();
            }
        }

        public Urun GetUrunById(int id)
        {
            using (var firmaDbContext = new FirmaDbContext())
            {
                return firmaDbContext.Urunler.Find(id);
            }
        }

        public Urun UpdateUrun(Urun Urun)
        {
            using (var firmaDbContext = new FirmaDbContext())
            {
                firmaDbContext.Urunler.Update(Urun);
                firmaDbContext.SaveChanges();
                return Urun;
            }
        }
    }
}
