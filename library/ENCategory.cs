using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    public class ENCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Constructor
        public ENCategory(int id, string name)
        {
            Id = id;
            Name = name;
        }

        // Default constructor
        public ENCategory() { }
    }
}
