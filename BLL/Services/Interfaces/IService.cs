using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface IService<out T, TU>
    {
        T GetAll();
        Task Create(TU entity);
        Task Update(TU entity);
        Task Delete(int id);
    }
}
