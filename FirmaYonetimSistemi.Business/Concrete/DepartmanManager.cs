using FirmaYonetimSistemi.Business.Abstract;
using FirmaYonetimSistemi.DataAccess.Abstract;
using FirmaYonetimSistemi.DataAccess.Concrete;
using FirmaYonetimSistemi.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace FirmaYonetimSistemi.Business.Concrete
{
    public class DepartmanManager : IDepartmanService
    {
        private IDepartmanRepository _departmanRepository;

        public DepartmanManager()
        {
            _departmanRepository = new DepartmanRepository();
        }
        public Departman CreateDepartman(Departman Departman)
        {
            return _departmanRepository.CreateDepartman(Departman);
        }

        public void DeleteDepartman(int id)
        {
            _departmanRepository.DeleteDepartman(id);
        }

        public DbSet<Departman> GetAllDepartmans()
        {
            return _departmanRepository.GetAllDepartmans();
        }

        public Departman GetDepartmanById(int id)
        {
            return _departmanRepository.GetDepartmanById(id);
        }

        public Departman UpdateDepartman(Departman Departman)
        {
            return _departmanRepository.UpdateDepartman(Departman);
        }
    }
}
