using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace EmailExercise.Model
{   
    public class EmailFormModel
    {        
        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Full name is required.")]
        [StringLength(100, MinimumLength = 1)]
        public string FullName { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email address")]
        [Required(ErrorMessage = "Email address is required.")]
        [EmailAddress(ErrorMessage = "Email address is invalid.")]
        [StringLength(100, MinimumLength = 7)]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Mobile Number")]        
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Mobile number is invalid")]
        public int? Mobile { get; set; }

        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Message is required.")]
        [Display(Name = "Message")]
        [StringLength(500, MinimumLength = 1)]
        public string Message { get; set; }

        [DataType(DataType.ImageUrl)]        
        public string PhotoPath { get; set; }

        [DataType(DataType.Upload)]
        [Display(Name = "Attach Photo")]
        public IFormFile Photo { get; set; }
    }

}
