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
    public class PersonelManager : IPersonelService
    {
        private IPersonelRepository _personelRepository;

        public PersonelManager()
        {
            _personelRepository = new PersonelRepository();
        }
        public Personel CreatePersonel(Personel Personel)
        {
            return _personelRepository.CreatePersonel(Personel);
        }

        public void DeletePersonel(int id)
        {
            _personelRepository.DeletePersonel(id);
        }

        public DbSet<Personel> GetAllPersonels()
        {
            return _personelRepository.GetAllPersonels();
        }

        public Personel GetPersonelById(int id)
        {
            return _personelRepository.GetPersonelById(id);
        }

        public Personel UpdatePersonel(Personel Personel)
        {
            return _personelRepository.UpdatePersonel(Personel);
        }

        public Personel GetPersonelByUsernamePassword(Personel p)
        {
            return _personelRepository.GetPersonelByUsernamePassword(p);
        }
    }
}
