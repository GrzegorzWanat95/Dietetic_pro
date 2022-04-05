using System;
using System.Collections.Generic;
using System.Text;

namespace DietetykPro
{
    [Serializable]
    public class Meal
    {

        protected int _meal_id;
        private List<Product> ingredient = new List<Product>();//baza składników danego posiłku
        private List<int> restriction = new List<int>();//baza alergenów/składników wykluczonych 
        private List<double> _weight = new List<double>();
        private string _meal_name;
        private double _meal_caloricity;
        private double _meal_carbohydrate;
        private double _meal_protein;
        private double _meal_fat;

        public Meal()
        {

        }
        public Meal(string _food_name, int meal_id)
        {
            this._meal_name = _food_name;
            this._meal_id = meal_id;
        }

        public int Meal_id { get => _meal_id; }
        public string Meal_name { get => _meal_name; set => _meal_name = value; }
        public double Meal_caloricity { get => _meal_caloricity; set => _meal_caloricity = value; }
        public double Meal_carbohydrate { get => _meal_carbohydrate; set => _meal_carbohydrate = value; }
        public double Meal_protein { get => _meal_protein; set => _meal_protein = value; }
        public double Meal_fat { get => _meal_fat; set => _meal_fat = value; }

        public List<Product> Ingredient { get => ingredient;}
        public List<double> Weight { get => _weight; set => _weight = value; }

        public void Add_Ingredient(Product product, double get)
        {
            ingredient.Add(product);
            Weight.Add(get);
        }

        public void Remove_ingredient(string product)
        {
            int iterator = 0;
            foreach (var item in ingredient)
            {
                ingredient.Remove(item);
                _weight.Remove(_weight[iterator]);
                iterator++;
                break;
            }
        }

        public void Edit_ingredient(int index, double weight)
        {
            _weight[index] = weight;
        }

        public void Calculate()
        {
            for (int i = 0; i < ingredient.Count; i++)
            {
                Meal_caloricity += ingredient[i].Caloricity * Weight[i]/100;
                Meal_carbohydrate += ingredient[i].Carbohydrate * Weight[i]/100;
                Meal_protein += ingredient[i].Protein * Weight[i]/100;
                Meal_fat += ingredient[i].Fat * Weight[i]/100;
            }
        }

        public void Print_Meal()
        {
            int iterator = 1;
            Console.WriteLine("Nazwa posiłku: {0}", Meal_name);
            Console.WriteLine("Kaloryczność: {0}", Math.Round(Meal_caloricity),2);
            Console.WriteLine("Węglowodany: {0}", Math.Round(Meal_carbohydrate),2);
            Console.WriteLine("Białko: {0}", Math.Round(Meal_protein),2);
            Console.WriteLine("Tłuszcze: {0}", Math.Round(Meal_fat),2);
            Console.WriteLine();
            Console.WriteLine("Składniki posiłku:");
            foreach (var product in ingredient)
            {
                if (product != null)
                {
                    Console.WriteLine("{0}. {1}, {2}g.", iterator, product.Product_name, Weight[iterator-1]);
                    iterator++;
                }
            }
        }

        public void Print_Ingredients()
        {
            int iterator = 1;
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("-{0}-", Meal_name);
            Console.ResetColor();
            foreach (var product in ingredient)
            {
                if (product != null)
                {
                    Console.WriteLine("{0}. {1}, {2}g.", iterator, product.Product_name, Weight[iterator-1]);
                    iterator++;
                }
            }
        }
    }
}

