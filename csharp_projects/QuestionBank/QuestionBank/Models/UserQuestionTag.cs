namespace QuestionBank.Models
{
    public class UserQuestionTag
    {
        public int Id { get; set; }
        public string ApplicationUserId { get; set; } = null!;
        public int QuestionTagId { get; set; }
        public ApplicationUser ApplicationUser { get; set; } = null!;
        public QuestionTag QuestionTag { get; set; } = null!;
    }
}
