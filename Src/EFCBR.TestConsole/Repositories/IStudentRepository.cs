using EFCBR.TestConsole.Models;

namespace EFCBR.TestConsole.Repositories
{
    public interface IStudentRepository : IBaseRepository<Student>
    {
        void SaveChanges();
    }
}
