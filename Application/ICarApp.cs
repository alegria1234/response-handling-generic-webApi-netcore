using Application.Model;

namespace Application
{
    public interface ICarApp
    {
        void Create(Car car);
        List<Car> GetByName(string name);
    }
}
