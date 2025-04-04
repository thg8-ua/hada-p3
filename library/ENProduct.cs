using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    public class ENProduct
    {
        private string _code;
        private string _name;
        private int _amount;
        private float _price;
        private int _category;
        private DateTime _creationDate;

        public string code { get { return _code; } set { _code = value; } }
        public string name { get { return _name; } set { _name = value; } }
        public int amount { get { return _amount; } set { _amount = value; } }
        public float price { get { return _price; } set { _price = value; } }
        public int category { get { return _category; } set { _category = value; } }

        public DateTime creationDate
        {
            get { return _creationDate; }
            set { _creationDate = value; }
        }


        public ENProduct()
        {
        }
        public ENProduct(string code, string name, int amount, float price, int category, DateTime creationDate)
        {
            this.code = code;
            this.name = name;
            this.amount = amount;
            this.price = price;
            this.category = category;
            this.creationDate = creationDate;
        }

        public bool Create()
        {
            CADProduct cad = new CADProduct();
            return cad.Create(this);
        }

        public bool Update()
        {
            CADProduct cad = new CADProduct();
            return cad.Update(this);
        }

        public bool Delete()
        {
            CADProduct cad = new CADProduct();
            return cad.Delete(this);
        }

        public bool Read()
        {
            CADProduct cad = new CADProduct();
            return cad.Read(this);
        }

        public bool ReadFirst()
        {
            CADProduct cad = new CADProduct();
            return cad.ReadFirst(this);
        }

        public bool ReadNext()
        {
            CADProduct cad = new CADProduct();
            return cad.ReadNext(this);
        }

        public bool ReadPrev()
        {
            CADProduct cad = new CADProduct();
            return cad.ReadPrev(this);
        }
    }
}
