using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Manager.ViewModel.Customer
{
    public class CreateCustomerInput
    {public int ID { get; set; }
public int IDUSER { get; set; }
        [Required]
        [Display(Name = "Nhap Ten")]
        public string NAME { get; set; }
        public DateTime BIRTHDAY { get; set; }

        [Required]
        [Display(Name = "Nhap Dia chi giao hang")]
        public string ADDRESS { get; set; }
        [Required]
        [Display(Name = "Nhap SDT lien lac")]
        public string PHONE { get; set; }
        [Required]
        [Display(Name = "Nhap Email lien lac")]
        public string EMAIL { get; set; }

        [Required]
        [Display(Name = "Nhap Pass")]
        public string PASSWORD { get; set; }
        public string AVATAR { get; set; }
        public class UpdateCustomerInput : CreateCustomerInput
        {
            public int IDUSER { get; set; }

            public int ID { get; set; }
            [Required]
            [Display(Name = "Nhap Ten")]
            public string NAME { get; set; }
            public DateTime BIRTHDAY { get; set; }

            [Required]
            [Display(Name = "Nhap Dia chi giao hang")]
            public string ADDRESS { get; set; }
            [Required]
            [Display(Name = "Nhap SDT lien lac")]
            public string PHONE { get; set; }
            [Required]
            [Display(Name = "Nhap Email lien lac")]
            public string EMAIL { get; set; }

            [Required]
            [Display(Name = "Nhap Pass")]
            public string PASSWORD { get; set; }
            public string AVATAR { get; set; }
        }
    }
}