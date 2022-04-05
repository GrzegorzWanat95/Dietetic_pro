using System;
using System.Collections.Generic;
using System.Text;

namespace DietetykPro
{
    public class WegeDiet :Diet
    {
        private int _type;
        private List<Meal> _1 = new List<Meal>();//Posiłek 1
        private List<Meal> _2 = new List<Meal>();//Posiłek 2
        private List<Meal> _3 = new List<Meal>();//Posiłek 3
        private List<Meal> _4 = new List<Meal>();//Posiłek 4
        private List<Meal> _5 = new List<Meal>();//Posiłek 5

        public WegeDiet()
        {
        }

        public WegeDiet(int _diet_id, int _meal_number, int patient_id) : base(_diet_id, _meal_number, patient_id)
        {
            this._type = 4;
        }

        protected int Type { get => _type;}

        public override void Print_Day(int number, Diet diet)
        {
            if (number == 1)
            {
                DietAction.Print_Breakfast(diet);
                DietAction.Print_Dinner(diet);
                DietAction.Print_Supper(diet);
            }
            if (number == 2)
            {
                DietAction.Print_Breakfast(diet);
                DietAction.Print_Lunch(diet);
                DietAction.Print_Dinner(diet);
                DietAction.Print_Supper(diet);
            }
            if (number == 3)
            {
                DietAction.Print_Breakfast(diet);
                DietAction.Print_Lunch(diet);
                DietAction.Print_Dinner(diet);
                DietAction.Print_Tea(diet);
                DietAction.Print_Supper(diet);
            }
        }

        public override void Diet_Report(Diet diet, int patient_id, List<Patient> patient_base)
        {
            Calculate_Day(diet);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine();
            Console.WriteLine("---Ocena jadłospisu:---");
            Console.ResetColor();
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
                Console.WriteLine("---Dieta wegetariańska---");
            }
        }
    }
}
