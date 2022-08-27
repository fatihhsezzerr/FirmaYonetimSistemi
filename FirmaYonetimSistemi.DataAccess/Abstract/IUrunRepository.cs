using FirmaYonetimSistemi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirmaYonetimSistemi.DataAccess.Abstract
{
    public interface IUrunRepository
    {
        List<Urun> GetAllUruns();
        Urun GetUrunById(int id);
        Urun CreateUrun(Urun Urun);
        Urun UpdateUrun(Urun Urun);
        void DeleteUrun(int id);
    }
}
