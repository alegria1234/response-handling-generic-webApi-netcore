using Application.Helpers;
using Application.Model;

namespace Application
{
    /// <summary>
    /// Car App
    /// </summary>
    public class CarApp : ICarApp
    {
        /// <summary>
        /// Create a new Car
        /// </summary>
        /// <param name="car"></param>
        public void Create(Car car)
        {
            ResponseRequest.UnSuccess(car == null, "invalid input");

            ResponseRequest.UnSuccess(string.IsNullOrWhiteSpace(car.Name), "Required Name");
        }

        /// <summary>
        /// Get by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public List<Car> GetByName(string name)
        {
            return carsTestes.Where(c => c.Name.Contains(name)).ToList();
        }

        /// <summary>
        /// Get by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Car GetById(int id)
        {
            return carsTestes.FirstOrDefault(c => c.Id == id);
        }

        
        private static List<Car> carsTestes = new List<Car>
        {
            new  Car
            {
                Id = 10,
                Name = "Hunday",
                Brand = "i10",
                Price = 3000
            },
            new  Car
            {
                Id = 20,
                Name = "Hunday",
                Brand = "i20",
                Price = 4000
            },
            new  Car
            {
                Id = 30,
                Name = "Hunday",
                Brand = "Tucson",
                Price = 5000
            }
        };
    }
}