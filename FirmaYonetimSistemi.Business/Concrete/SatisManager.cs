using FirmaYonetimSistemi.Business.Abstract;
using FirmaYonetimSistemi.DataAccess.Abstract;
using FirmaYonetimSistemi.DataAccess.Concrete;
using FirmaYonetimSistemi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace FirmaYonetimSistemi.Business.Concrete
{
    public class SatisManager : ISatisService
    {
        private ISatisRepository _satisRepository;

        public SatisManager()
        {
            _satisRepository = new SatisRepository();
        }
        public Satis CreateSatis(Satis Satis)
        {
            return _satisRepository.CreateSatis(Satis);
        }

        public void DeleteSatis(int id)
        {
            _satisRepository.DeleteSatis(id);
        }

        public List<Satis> GetAllSatislar()
        {
            return _satisRepository.GetAllSatislar();
        }

        public Satis GetSatisById(int id)
        {
            return _satisRepository.GetSatisById(id);
        }

        public Satis UpdateSatis(Satis Satis)
        {
            return _satisRepository.UpdateSatis(Satis);
        }
    }
}
