using FirmaYonetimSistemi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirmaYonetimSistemi.Business.Abstract
{
    public interface IUrunService
    {
        List<Urun> GetAllUruns();
        Urun GetUrunById(int id);
        Urun CreateUrun(Urun Urun);
        Urun UpdateUrun(Urun Urun);
        void DeleteUrun(int id);

    }
}
