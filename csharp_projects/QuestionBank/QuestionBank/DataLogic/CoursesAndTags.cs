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
                    QuestionId = questionId,
                    TagId = tagId
                };
                _context.Add(questionTag);
            }
            foreach (int courseId in courseIds)
            {
                QuestionCourse questionCourse = new QuestionCourse()
                {
                    QuestionId = questionId,
                    CourseId = courseId
                };
                _context.Add(questionCourse);
            }
            _context.SaveChanges();
        }
    }
}
