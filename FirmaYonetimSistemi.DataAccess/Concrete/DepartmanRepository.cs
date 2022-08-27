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
    public class DepartmanRepository : IDepartmanRepository
    {
        public Departman CreateDepartman(Departman Departman)
        {
            using (var firmaDbContext = new FirmaDbContext())
            {
                firmaDbContext.Departmanlar.Add(Departman);
                firmaDbContext.SaveChanges();
                return Departman;
            }
        }

        public void DeleteDepartman(int id)
        {
            using (var firmaDbContext = new FirmaDbContext())
            {
                var deletedDepartman = GetDepartmanById(id);
                firmaDbContext.Departmanlar.Remove(deletedDepartman);
                firmaDbContext.SaveChanges();
            }
        }

        public DbSet<Departman> GetAllDepartmans()
        {
            using (var firmaDbContext = new FirmaDbContext())
            {
                return firmaDbContext.Departmanlar;
            }
        }

        public Departman GetDepartmanById(int id)
        {
            using (var firmaDbContext = new FirmaDbContext())
            {
                return firmaDbContext.Departmanlar.Find(id);
            }
        }

        public Departman UpdateDepartman(Departman Departman)
        {
            using (var firmaDbContext = new FirmaDbContext())
            {
                firmaDbContext.Departmanlar.Update(Departman);
                firmaDbContext.SaveChanges();
                return Departman;
            }
        }

    }
}
