
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EmailExercise.Pages
{
    
    public class ContactModel : PageModel
    {
        public string Message { get; private set; }

        public void OnGet()
        {
            Message = "My contact page.";
        }
        
    }
}
