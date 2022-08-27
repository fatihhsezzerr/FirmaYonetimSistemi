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
    public class UrunManager : IUrunService
    {
        private IUrunRepository _urunRepository;

        public UrunManager()
        {
            _urunRepository = new UrunRepository();
        }
        public Urun CreateUrun(Urun Urun)
        {
            return _urunRepository.CreateUrun(Urun);
        }

        public void DeleteUrun(int id)
        {
            _urunRepository.DeleteUrun(id);
        }

        public List<Urun> GetAllUruns()
        {
            return _urunRepository.GetAllUruns();
        }

        public Urun GetUrunById(int id)
        {
            return _urunRepository.GetUrunById(id);
        }

        public Urun UpdateUrun(Urun Urun)
        {
            return _urunRepository.UpdateUrun(Urun);
        }
    }
}
