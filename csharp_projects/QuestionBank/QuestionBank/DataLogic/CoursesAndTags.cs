using QuestionBank.Data;
using QuestionBank.Models;

namespace QuestionBank.DataLogic
{
    public class CoursesAndTags
    {
        private readonly ApplicationDbContext _context = null!;

        public CoursesAndTags(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddCoursesAndTags(int questionId, List<int> courseIds, List<int> tagIds)
        {
            foreach (int tagId in tagIds)
            {
                QuestionTag questionTag = new QuestionTag()
                {
                    QuestionsId = questionId,
                    TagsId = tagId
                };
                _context.Add(questionTag);
            }
            _context.SaveChanges();
        }
    }
}
