using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace DietetykPro
{
    [XmlInclude(typeof(Product))]
    [Serializable]
    public abstract class Product
    {
        protected int _product_id;
        private string _product_name;
        private double _caloricity;
        private double _carbohydrate;
        private double _protein;
        private double _fat;

        public Product()
        {
            
        }

        public Product( int _product_id, string _product_name, double _caloricity, double _carbohydrate, double _protein, double _fat) 
        {
            this._product_id = _product_id;
            this._product_name = _product_name;
            this._caloricity = _caloricity;
            this._carbohydrate = _carbohydrate;
            this._protein = _protein;
            this._fat = _fat;
        }

        public string Product_name { get => _product_name; set => _product_name = value; }
        public int Product_id { get => _product_id; }
        public double Caloricity { get => _caloricity; set => _caloricity = value; }
        public double Carbohydrate { get => _carbohydrate; set => _carbohydrate = value; }
        public double Protein { get => _protein; set => _protein = value; }
        public double Fat { get => _fat; set => _fat = value; }

        //Metoda wyświetlająca dane produktu
        public virtual void Print_Product()
        {
            Console.WriteLine("Nazwa produktu: {0}", Product_name);
            Console.WriteLine("Kalorie: {0}", _caloricity);
            Console.WriteLine("Węglowodany: {0}", _carbohydrate);
            Console.WriteLine("Białko: {0}", _protein);
            Console.WriteLine("Tłuszcz: {0}", _fat);
        }

        public virtual void Product_Restriction()
        {
            Console.WriteLine("Pomyślnie dodano produkt");
        }
    }
}
