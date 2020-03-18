using System.ComponentModel.DataAnnotations;


namespace CleanBlog.Core.ViewModels
{
    public class ContactViewModel
    { 
        [Required(ErrorMessage = "Please enter your name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your email")]
        [EmailAddress(ErrorMessage = "You must enter a valid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your message")]
        [MaxLength(500, ErrorMessage = "Your message should be no longer that 500 characters")]
        public string Message { get; set; }

        // id to store properties of the form 
        public int ContactPageId { get; set; }
    }
}
