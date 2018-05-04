using System.ComponentModel.DataAnnotations;

namespace Zya.IdentityServer.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}