using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Smatrves.Models
{
    public class Site
    {
        [Key]
        public int SiteID { get; set; }
        //Адрес сайта
        [Required]
        [Display(Name = "Адрес сайта")]
        public string SiteAdress { get; set; }
        //Название сайта
        [Required]
        [Display(Name = "Название сайта")]
        public string SiteName { get; set; }
        //Описание сайта
        [Required]
        [Display(Name = "Описание")]
        public string SiteDescription { get; set; }
        //Время показа
        [Required]
        [Display(Name = "Время показа")]
        public int ShowTime { get; set; }
        //баланс сайта[в просмотрах]
        [Required]
        [Display(Name = "Баланс")]
        public int SiteBalance { get; set; }
        //Цена одного показа
        [Required]
        [Display(Name = "Цена показа")]
        public int ShowPrice { get; set; }
        //Только для уникальных IP адресов
        [Required]
        [Display(Name = "Только для уникальных IP")]
        public bool OnlyUniqueIP { get; set; }

        public virtual Client Owner { get; set; }
        public virtual ICollection<ShowReport> Reports { get; set; }
    }
}