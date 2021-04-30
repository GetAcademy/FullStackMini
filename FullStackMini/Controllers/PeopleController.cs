using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using FullStackMini.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FullStackMini.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        // GET: api/<PeopleController>
        [HttpGet]
        public IEnumerable<Person> Get()
        {
            return GetConnection().Query<Person>("select * from People3");
        }

        private static SqlConnection GetConnection()
        {
            var conStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=terje;Integrated Security=True";
            var conn = new SqlConnection(conStr);
            return conn;
        }

        // POST api/<PeopleController>
        [HttpPost]
        public void Post(Person person)
        {
            GetConnection().Execute("insert into People3 values (@Id, @FirstName)", person);
        }

        [HttpDelete("{id}")]
        public void Post(Guid id)
        {
            GetConnection().Execute("delete from People3 where Id = @Id", new { Id = id });
        }
    }
}
