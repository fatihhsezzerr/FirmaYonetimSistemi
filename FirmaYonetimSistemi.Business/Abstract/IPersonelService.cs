using FirmaYonetimSistemi.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirmaYonetimSistemi.Business.Abstract
{
    public interface IPersonelService
    {
        DbSet<Personel> GetAllPersonels();
        Personel GetPersonelById(int id);
        Personel CreatePersonel(Personel Personel);
        Personel UpdatePersonel(Personel Personel);
        void DeletePersonel(int id);
        Personel GetPersonelByUsernamePassword(Personel p);

    }
}
