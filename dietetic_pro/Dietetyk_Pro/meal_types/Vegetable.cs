using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace DietetykPro
{
    
    [Serializable]
    public class Vegetable : Product
    {
        protected int _type;

        public Vegetable()
        {
            _type = 1;
        }

        public Vegetable(int product_id, string product_name, double caloricity, double carbohydrate, double protein, double fat) : base(product_id, product_name, caloricity, carbohydrate, protein, fat)
        {
            _type = 1;
        }

        public int Type { get => _type; }

        //Metoda wyświetlająca dane produktu
        public override void Print_Product()
        {
            Console.WriteLine("Nazwa produktu: {0}", base.Product_name);
            Console.WriteLine("Kalorie: {0}", base.Caloricity);
            Console.WriteLine("Węglowodany: {0}", base.Carbohydrate);
            Console.WriteLine("Białko: {0}", base.Protein);
            Console.WriteLine("Tłuszcz: {0}", base.Fat);
            Console.WriteLine("Kategoria: Warzywa");
        }
    }
}
