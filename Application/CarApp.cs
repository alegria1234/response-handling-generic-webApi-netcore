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
            RequestResponse.UnSuccess(car == null, "invalid input");

            RequestResponse.UnSuccess(string.IsNullOrWhiteSpace(car.Name), "Required Name");
        }

        /// <summary>
        /// Get cars by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public List<Car> GetByName(string name)
        {
            return carsTestes.Where(c => c.Name.Contains(name)).ToList();
        }

        private static List<Car> carsTestes = new List<Car>
        {
            new  Car
            {
                Id = 10,
                Name = "Hyundai",
                Brand = "i10",
                Price = 3000
            },
            new  Car
            {
                Id = 20,
                Name = "Hyundai",
                Brand = "i20",
                Price = 4000
            },
            new  Car
            {
                Id = 30,
                Name = "Hyundai",
                Brand = "Tucson",
                Price = 5000
            }
        };
    }
}