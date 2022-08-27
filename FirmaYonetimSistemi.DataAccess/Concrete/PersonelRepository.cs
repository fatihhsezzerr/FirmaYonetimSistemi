using FirmaYonetimSistemi.DataAccess.Abstract;
using FirmaYonetimSistemi.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirmaYonetimSistemi.DataAccess.Concrete
{
    public class PersonelRepository : IPersonelRepository
    {
        public Personel CreatePersonel(Personel Personel)
        {
            using (var firmaDbContext = new FirmaDbContext())
            {
                firmaDbContext.Personeller.Add(Personel);
                firmaDbContext.SaveChanges();
                return Personel;
            }
        }

        public void DeletePersonel(int id)
        {
            using (var firmaDbContext = new FirmaDbContext())
            {
                var deletedPersonel = GetPersonelById(id);
                firmaDbContext.Personeller.Remove(deletedPersonel);
                firmaDbContext.SaveChanges();
            }
        }

        public DbSet<Personel> GetAllPersonels()
        {
            using(var firmaDbContext = new FirmaDbContext())
            {
                return firmaDbContext.Personeller;
            }
        }

        public Personel GetPersonelById(int id)
        {
            using (var firmaDbContext = new FirmaDbContext())
            {
                return firmaDbContext.Personeller.Find(id);
            }
        }

        public Personel GetPersonelByUsernamePassword(Personel p)
        {
            using (var firmaDbContext = new FirmaDbContext())
            {
                return firmaDbContext.Personeller.FirstOrDefault(x => x.KullaniciAdi == p.KullaniciAdi && x.Sifre == p.Sifre);
            }
        }

        public Personel UpdatePersonel(Personel Personel)
        {
            using (var firmaDbContext = new FirmaDbContext())
            {
                firmaDbContext.Personeller.Update(Personel);
                firmaDbContext.SaveChanges();
                return Personel;
            }
        }
    }
}
