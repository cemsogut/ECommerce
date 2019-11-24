using ECommerce.Areas.Management.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Areas.Management.Models.Entities
{
    public class Category:BaseEntity
    {
        [Display(Name="Üst Kategri")]
        public int ParentId { get; set; }
        [Display(Name ="Açıklama")]
        public string Description { get; set; }
        
    }
}