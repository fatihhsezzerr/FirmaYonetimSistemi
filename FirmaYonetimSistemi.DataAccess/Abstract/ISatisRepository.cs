using FirmaYonetimSistemi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirmaYonetimSistemi.DataAccess.Abstract
{
    public interface ISatisRepository
    {
        List<Satis> GetAllSatislar();
        Satis GetSatisById(int id);
        Satis CreateSatis(Satis Satis);
        Satis UpdateSatis(Satis Satis);
        void DeleteSatis(int id);
    }
}
