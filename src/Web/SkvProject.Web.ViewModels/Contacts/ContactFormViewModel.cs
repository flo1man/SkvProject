namespace SkvProject.Web.ViewModels.Contacts
{
    using System.ComponentModel.DataAnnotations;

    using SkvProject.Web.Infrastructure;

    using static SkvProject.Common.DataConstants;

    public class ContactFormViewModel
    {
        [Required]
        [MinLength(ContactNameMinLength, ErrorMessage = "The name must have at least {1} characters")]
        [MaxLength(ContactNameMaxLength, ErrorMessage = "You can't use more than {1} characters")]
        [Display(Name = "Your Full Name")]
        public string Name { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Please enter valid email address")]
        [Display(Name = "Your Email Address")]
        public string Email { get; set; }

        [Required]
        [MinLength(ContactTitleMinLength, ErrorMessage = "The subject must have at least {1} characters")]
        [MaxLength(ContactTitleMaxLength, ErrorMessage = "You can't use more than {1} characters")]
        [Display(Name = "Subject")]
        public string Title { get; set; }

        [Required]
        [MinLength(ContactContentMinLength, ErrorMessage = "The message must have at least {1} characters")]
        [MaxLength(ContactContentMaxLength, ErrorMessage = "You can't use more than {1} characters")]
        [Display(Name = "Message")]
        public string Content { get; set; }

        //[GoogleReCaptchaValidation]
        //public string RecaptchaValue { get; set; }
    }
}
