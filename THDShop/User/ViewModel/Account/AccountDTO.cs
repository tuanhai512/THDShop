using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace User.ViewModel.Account
{
    public class AccountDTO
    {
       
        public string PASSWORD { get; set; }    
        public string EMAIL { get; set; }
        public string NAME { get; set; }
        public string PHONE { get; set; }

        [NotMapped]
        public string Comfirm { get; set; }
    }
}