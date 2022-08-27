using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirmaYonetimSistemi.Entities
{
    public class Urun
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(50)]
        public string UrunAdi { get; set; }
        public float Fiyat { get; set; }
        public int Stok { get; set; }
        [StringLength(50)]
        public string Birim { get; set; }
    }
}
