using Microsoft.AspNetCore.Identity;

namespace QuestionBank.Models
{
    public class ApplicationUser : IdentityUser
    {
        public List<UserQuestionTag> UserQuestionTags { get; } = new();
    }
}