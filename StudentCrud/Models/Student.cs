using StudentCrud.ViewModels.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentCrud.Models
{
    public class Student
    {
        [Required(ErrorMessage = "Név kitöltése kötelező")]
        [StringLength(20, ErrorMessage = "Max 20 karakter!")]
        [Display(Name = "Hallgató neve")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Neptunkód kitöltése kötelező")]
        [StringLength(20, ErrorMessage = "Max 20 karakter!")]
        [Display(Name = "Hallgató neptunkódja")]
        public string NeptunCode { get; set; }

        [Required(ErrorMessage = "Évfolyam kitöltése kötelező")]
        [Display(Name = "Hallgató évfolyama")]
        [StudentClassValidation(1,3)]
        public int Class { get; set; }

        [Required(ErrorMessage = "Szak kitöltése kötelező")]
        [StringLength(20, ErrorMessage = "Max 20 karakter!")]
        [Display(Name = "Hallgató szakja")]
        public string Faculty { get; set; }

        public string UID { get; set; }

        public Student()
        {
            UID = Guid.NewGuid().ToString();
        }
    }
}
