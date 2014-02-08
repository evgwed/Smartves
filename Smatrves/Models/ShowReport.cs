using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Smatrves.Models
{
    public class ShowReport
    {
        [Key]
        public int ReportId { get; set; }
        [Required]
        public virtual Client ClientViewer { get; set; }
        [Required]
        public virtual Site Site { get; set; }
        [Required]
        [Display(Name = "Дата и время просмотра")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime DateTimeShow { get; set; }
        [Required]
        [Display(Name = "Ip просмотревшего")]
        public string IpViewer { get; set; }
    }
}