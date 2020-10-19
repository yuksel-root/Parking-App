using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using Parking_App.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;

namespace Parking_App.Repositories
{
    public class DpCarRepository
    {
        public List<Car> GetAllData()
        {
            using var connection = new SqlConnection("server=DESKTOP-VNKEEQV\\SQLEXPRESS;database=dbParking; integrated security=true;");

            return connection.GetAll<Car>().ToList();
        }

 
    }
}
