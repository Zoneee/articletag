using System.ComponentModel.DataAnnotations;

namespace Businesses.ViewModels.Requsets
{
    public class UserLoginVm
    {
        [Required]
        public string LoginName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
