using ECommerce.Areas.Management.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Areas.Management.Models.Entities
{
    public enum autoClass
    {
        Ekonomik,
        OrtaSınıf,
        LüxSınıf
    }
    public enum autoFuelType
    {
        Benzin,
        Dizel,
        Elektrik,
        BenzinElektrik,
        Gaz
    }
    public enum autoGearType
    {
        Manuel,
        Otomatik
    }
    public enum autoModelYear
    {
        
    }
    public class Product:BaseEntity
    {
        [Display(Name="Araç Sınıfı")]
        [Required(ErrorMessage ="Araç Sınıf Tipini Seçmediniz")]
        public autoClass ClassType { get; set; }
        [Display(Name = "Yakıt Tipi")]
        [Required(ErrorMessage = "Araç Yakıt Tipini Seçmediniz")]
        public autoFuelType FuelType { get; set; }
        [Display(Name = "Vites Tipi")]
        [Required(ErrorMessage = "Araç Vites Tipini Seçmediniz")]
        public autoGearType GearType { get; set; }
        [Display(Name = "Tutar")]
        [Required(ErrorMessage = "Araç Günlük Ücretini Girmediniz")]
        public decimal dailyPrice { get; set; }
        [Display(Name="İndirim")]
        public decimal discount { get; set; }
        [Display(Name="Model Yılı")]
        public int autoModelYear { get; set; }
        [Display(Name="Kilometre")]
        public int km { get; set; }
        [Display(Name="Resim")]
        public byte[] İmage { get; set; }

        public int brandId { get; set; }
        public int categoryId { get; set; }

        public Category Category { get; set; }
        public Brand Brand { get; set; }
    }
}