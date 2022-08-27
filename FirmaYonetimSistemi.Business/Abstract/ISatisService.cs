using FirmaYonetimSistemi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirmaYonetimSistemi.Business.Abstract
{
    public interface ISatisService
    {
        List<Satis> GetAllSatislar();
        Satis GetSatisById(int id);
        Satis CreateSatis(Satis Satis);
        Satis UpdateSatis(Satis Satis);
        void DeleteSatis(int id);

    }
}
