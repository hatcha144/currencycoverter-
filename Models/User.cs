//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CurrencyAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class User
    {
        public int UserID { get; set; }
        [DisplayName("User Name")]
        [Required(ErrorMessage ="This field is requried")]
        public string UserName { get; set; }
        [DisplayName("Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage ="This field is required")]
        public string Passwrod { get; set; }

        public string LoginErrorMessage { get; set; }
    }
}
