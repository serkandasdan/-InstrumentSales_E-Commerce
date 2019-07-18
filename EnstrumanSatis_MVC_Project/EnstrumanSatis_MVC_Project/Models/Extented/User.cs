using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EnstrumanSatis_MVC_Project.Models
{
    [MetadataType(typeof(UserMetadata))]
    public partial class User_
    {
        public string ConfirmPassword { get; set; }
    }
    public class UserMetadata
    {
        [Display(Name = "Ad")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "*Ad Gerekli")]
       public string FirstName { get; set; }


        [Display(Name = "Soyad")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "*Soyad Gerekli")]
        public string LastName { get; set; }


        [Display(Name = "E-Posta")]
        [RegularExpression(@"^[\w-]+(\.[\w-]+)*@([a-z0-9-]+(\.[a-z0-9-]+)*?\.[a-z]{2,6}|(\d{1,3}\.){3}\d{1,3})(:\d{4})?$", ErrorMessage = "Lütfen geçerli bir e-posta adresi giriniz")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "*Email Adresi Gerekli")]
        public string Email { get; set; }

        [Display(Name = "Kullanıcı Adı")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "*Kullanıcı Adı Gerekli")]
        public string UserName { get; set; }


        [Display(Name = "Doğum Tarihi")]
        [DataType(DataType.Date)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "*Doğum Tarihi Gerekli")]
        [DisplayFormat(ApplyFormatInEditMode =true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime BirthDate { get; set; }


        [Display(Name = "Şifre")]
        [DataType(DataType.Password)]
        [MinLength(6,ErrorMessage = "Minimum 6 karakter gerekli")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "*Şifre Gerekli")]
        public string Password { get; set; }


        [Display(Name = "Şifre Tekrar")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Şifre Alanları Uyuşmuyor")]
        public string ConfirmPassword { get; set; }


        [Display(Name = "Cinsiyet")]
        [Required(ErrorMessage = "*Cinsiyet Gerekli")]
        public string Gender { get; set; }


        [Display(Name = "Telefon 1")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-.●]?([0-9]{3})[-.●]?([0-9]{4})$", ErrorMessage = "Lütfen Geçerli Telefon Numarası Griniz")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "*Telefon Numarası Gerekli")]
        public string TelNumber1 { get; set; }

        [Display(Name = "Telefon 2")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-.●]?([0-9]{3})[-.●]?([0-9]{4})$", ErrorMessage = "Lütfen Geçerli Telefon Numarası Griniz")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "*Telefon Numarası Gerekli")]
        public string TelNumber2 { get; set; }


        [Display(Name = "Şehir")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "*Şehir Gerekli")]
        public int CityID { get; set; }

        [Display(Name = "İlçe")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "*İlçe Gerekli")]

        public int TownID { get; set; }

        [Display(Name = "Posta Kodu")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "*Posta Kodu Gerekli")]
        public string PostalCode { get; set; }

        [Display(Name = "Adres")]
        [DataType(DataType.MultilineText)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "*Adres Gerekli")]
        public string AddressText { get; set; }


    }
}