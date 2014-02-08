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
        public string SiteAdress { get; set; }
        //Название сайта
        [Required]
        public string SiteName { get; set; }
        //Описание сайта
        [Required]
        public string SiteDescription { get; set; }
        //Время показа
        [Required]
        public int ShowTime { get; set; }
        //баланс сайта[в просмотрах]
        [Required]
        public int SiteBalance { get; set; }
        //Цена одного показа
        [Required]
        public int ShowPrice { get; set; }
        //Только для уникальных IP адресов
        [Required]
        public bool OnlyUniqueIP { get; set; }

        public virtual Client client { get; set; }
    }
}