using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    internal class ENProduct
    {
        //TODO: create the function asshole
        private string _code;
        private string _name;
        private int _amount;
        private float _price;
        private int _category;
        private DateTime _creationDate;

        public string code { get { return _code; } set { _code = value; } }
        public string name { get { return _name;    } set { _name = value; } }
        public int amount { get { return _amount;   } set { _amount = value; } }
        public float price { get { return _price;   } set { _price = value; } } 
        public int category { get { return _category;   } set { _category = value; } }
        public DateTime creationDate { get { return _creationDate;  } set { _creationDate = value; }

    }
}
