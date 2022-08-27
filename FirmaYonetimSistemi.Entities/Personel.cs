using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirmaYonetimSistemi.Entities
{
    public class Personel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(50)]
        public string AdSoyad { get; set; }
        [StringLength(50)]
        public string KullaniciAdi { get; set; }
        [StringLength(50)]
        public string Eposta { get; set; }
        [StringLength(50)]
        public string Sifre { get; set; }
        [ForeignKey("DepartmanId")]
        public Departman Departman { get; set; }
        public int? DepartmanId { get; set; }
    }
}
