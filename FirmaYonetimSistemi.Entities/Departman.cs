using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirmaYonetimSistemi.Entities
{
    public class Departman
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(50)]
        public string DepartmanAdi { get; set; }
        public int Yetki { get; set; }
    }
}
