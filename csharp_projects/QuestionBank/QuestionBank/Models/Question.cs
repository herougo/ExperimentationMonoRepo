namespace QuestionBank.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string? QuestionText { get; set; }
        public string? AnswerText { get; set; }
        public List<Tag> Tags { get; } = new();
        public List<Course> Course { get; } = new();
    }
}
