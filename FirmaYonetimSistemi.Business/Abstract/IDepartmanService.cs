using FirmaYonetimSistemi.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirmaYonetimSistemi.Business.Abstract
{
    public interface IDepartmanService
    {
        DbSet<Departman> GetAllDepartmans();
        Departman GetDepartmanById(int id);
        Departman CreateDepartman(Departman Departman);
        Departman UpdateDepartman(Departman Departman);
        void DeleteDepartman(int id);

    }
}
