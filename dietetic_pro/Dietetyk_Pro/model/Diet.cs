using System;
using System.Collections.Generic;
using System.Text;

namespace DietetykPro
{
    [Serializable]
    public abstract class Diet
    {
        protected int _diet_id;
        protected int _patient_id;
        private List<Meal> _1 = new List<Meal>();//Posiłek 1
        private List<Meal> _2 = new List<Meal>();//Posiłek 2
        private List<Meal> _3 = new List<Meal>();//Posiłek 3
        private List<Meal> _4 = new List<Meal>();//Posiłek 4
        private List<Meal> _5 = new List<Meal>();//Posiłek 5
        private double _day_caloricity;
        private double _day_carbohydrates;
        private double _day_protein;
        private double _day_fat;
        private int _meal_number;
        
        public Diet()
        {

        }
        public Diet(int _diet_id, int _meal_number, int _patient_id)
        {
            this._diet_id = _diet_id;
            this._meal_number = _meal_number;
            this._patient_id = _patient_id;
        }

        public List<Meal> m1 { get => _1; set => _1 = value; }
        public List<Meal> m2 { get => _2; set => _2 = value; }
        public List<Meal> m3 { get => _3; set => _3 = value; }
        public List<Meal> m4 { get => _4; set => _4 = value; }
        public List<Meal> m5 { get => _5; set => _5 = value; }
        public double Day_caloricity { get => _day_caloricity; set => _day_caloricity = value; }
        public double Day_carbohydrates { get => _day_carbohydrates; set => _day_carbohydrates = value; }
        public double Day_protein { get => _day_protein; set => _day_protein = value; }
        public double Day_fat { get => _day_fat; set => _day_fat = value; }
        public int Patient_id { get => _patient_id; set => _patient_id = value; }
        public int Meal_number { get => _meal_number; set => _meal_number = value; }

        public virtual void Print_Day(int number, Diet diet)
        {
            if(number == 1)
            {
                DietAction.Print_Breakfast(diet);
                DietAction.Print_Dinner(diet);
                DietAction.Print_Supper(diet);
            }
            if(number == 2)
            {
                DietAction.Print_Breakfast(diet);
                DietAction.Print_Lunch(diet);
                DietAction.Print_Dinner(diet);
                DietAction.Print_Supper(diet);
            }
            if(number == 3)
            {
                DietAction.Print_Breakfast(diet);
                DietAction.Print_Lunch(diet);
                DietAction.Print_Dinner(diet);
                DietAction.Print_Tea(diet);
                DietAction.Print_Supper(diet);
            }
        }

        public virtual void Diet_Report(Diet diet, int patient_id, List<Patient> patient_base)
        {
            Calculate_Day(diet);
            Console.WriteLine("---Ocena jadłospisu:---");
            Console.WriteLine("Kaloryczność: {0}", Math.Round(Day_caloricity), 2);
            Console.WriteLine("Węglowodany: {0}", Math.Round(Day_carbohydrates), 2);
            Console.WriteLine("Białko: {0}", Math.Round(Day_protein), 2);
            Console.WriteLine("Tłuszcze: {0}", Math.Round(Day_fat), 2);
            Console.WriteLine();
            double caloricity = Day_caloricity - (patient_base[patient_id].Return_Sugested_Caloricity());
            if (caloricity < 0)
            {
                Console.WriteLine("Kaloryczność diety jest zbyt mała. Pozostało do wykorzystania {0} kcal dla pacjenta {1}", Math.Round(Math.Abs(caloricity), 2), patient_base[patient_id].Name);
                Console.WriteLine("Zalecane jest zwiększenie kaloryczności diety");
            }
            if (caloricity >= 0)
            {
                Console.WriteLine("Kaloryczność diety jest zbyt wysoka. Przekroczono bilans o {0} kcal dla pacjenta {1}", Math.Round(Math.Abs(caloricity), 2), patient_base[patient_id].Name);
                Console.WriteLine("Zalecane jest zmniejszenie kaloryczności diety");
                Console.WriteLine();
            }
        }

        public void Calculate_Day(Diet diet)
        {
            Day_caloricity =0;
            Day_carbohydrates = 0; ;
            Day_protein =0;
            Day_fat = 0; ;

            foreach (var item in _1)
            {
                Day_caloricity += item.Meal_caloricity;
                Day_carbohydrates += item.Meal_carbohydrate;
                Day_protein += item.Meal_protein;
                Day_fat += item.Meal_fat;
            }
            foreach (var item in _2)
            {
                Day_caloricity += item.Meal_caloricity;
                Day_carbohydrates += item.Meal_carbohydrate;
                Day_protein += item.Meal_protein;
                Day_fat += item.Meal_fat;
            }
            foreach (var item in _3)
            {
                Day_caloricity += item.Meal_caloricity;
                Day_carbohydrates += item.Meal_carbohydrate;
                Day_protein += item.Meal_protein;
                Day_fat += item.Meal_fat;
            }
            foreach (var item in _4)
            {
                Day_caloricity += item.Meal_caloricity;
                Day_carbohydrates += item.Meal_carbohydrate;
                Day_protein += item.Meal_protein;
                Day_fat += item.Meal_fat;
            }
            foreach (var item in _5)
            {
                Day_caloricity += item.Meal_caloricity;
                Day_carbohydrates += item.Meal_carbohydrate;
                Day_protein += item.Meal_protein;
                Day_fat += item.Meal_fat;
            }
        }

        public void Remove(Meal meal)
        {
            Day_caloricity -= meal.Meal_caloricity;
            Day_carbohydrates -= meal.Meal_carbohydrate;
            Day_protein -= meal.Meal_protein;
            Day_fat -= meal.Meal_fat;
        }
    }
}
