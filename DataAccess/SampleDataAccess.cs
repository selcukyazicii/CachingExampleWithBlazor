using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class SampleDataAccess
    {
        private readonly IMemoryCache _memoryCache;

        public SampleDataAccess(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }
        public List<EmployeeModel> GetEmployees()
        {
            List<EmployeeModel> output = new();
            output.Add(new EmployeeModel { FirstName = "Mark", LastName = "Zuckerberg" });
            output.Add(new EmployeeModel { FirstName = "Leo", LastName = "Xandre" });
            output.Add(new EmployeeModel { FirstName = "Mark", LastName = "Zuckerberg" });
            output.Add(new EmployeeModel { FirstName = "Beer", LastName = "Gryls" });

            Thread.Sleep(3000);

            return output;
        }
        public async Task<List<EmployeeModel>> GetEmployeesAsync()
        {
            List<EmployeeModel> output = new();
            output.Add(new EmployeeModel { FirstName = "Mark", LastName = "Zuckerberg" });
            output.Add(new EmployeeModel { FirstName = "Leo", LastName = "Xandre" });
            output.Add(new EmployeeModel { FirstName = "Mark", LastName = "Zuckerberg" });
            output.Add(new EmployeeModel { FirstName = "Beer", LastName = "Gryls" });

            await Task.Delay(3000);
            return output;
        }
        public async Task<List<EmployeeModel>> GetEmployeesCache()
        {
            List<EmployeeModel> output;
            output = _memoryCache.Get<List<EmployeeModel>>("employees");
            if (output is null)
            {
                output = new();
                output.Add(new EmployeeModel { FirstName = "Mark", LastName = "Zuckerberg" });
                output.Add(new EmployeeModel { FirstName = "Leo", LastName = "Xandre" });
                output.Add(new EmployeeModel { FirstName = "Lark", LastName = "Parlıament" });
                output.Add(new EmployeeModel { FirstName = "Beer", LastName = "Gryls" });
                await Task.Delay(3000);
                _memoryCache.Set("employees", output, TimeSpan.FromMinutes(1));
            }
            return output;
        }
    }
}
