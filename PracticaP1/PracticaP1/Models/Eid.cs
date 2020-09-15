using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PracticaP1.Models

{

    public enum CategoryType
    {
        Cine=10,
        Plaza=20,
        Parque=30,
        Teatro=40,
        Colegio=50
    }

    public class Eid
    {

        [Key]
        public int eidID { get; set; }


        [Required]
        [DisplayName("Nombre Completo")]
        [StringLength(24,MinimumLength =2)]
        public string Friendofeid { get; set; }

        [Required]
        public CategoryType Place { get; set; }

        [EmailAddress]
        public string Email { get; set; }


        [DisplayName("Cumpleaños")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{00:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Birthday { get; set; }
    }
}