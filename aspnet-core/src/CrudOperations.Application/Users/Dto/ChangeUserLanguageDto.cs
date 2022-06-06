using System.ComponentModel.DataAnnotations;

namespace CrudOperations.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}