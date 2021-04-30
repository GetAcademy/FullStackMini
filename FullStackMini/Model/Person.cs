using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullStackMini.Model
{
    public class Person
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }

        public Person(string name)
        {
            FirstName = name;
            Id = Guid.NewGuid();
        }

        public Person() : this(null)
        {
        }
    }
}
