using System;
using System.Collections.Generic;
using System.Text;

namespace DietetykPro
{
    static class Calculate
    {
        //Metoda obliczająca wartość Body Mass Index
        public static double Bmi_Calculate(double weight, double height)
        {
            double bmi = (weight / (Math.Pow((height/100),2)));
            return Math.Round(bmi,2);
        }

        //Metoda wyświetlajaca interpretację wyniku BMI
        public static void BMI_Interpretation(double bmi)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            if (bmi < 16) {Console.Write("Wartosc BMI oznacza niedowage");}
            else if (bmi >= 16 && bmi < 17) {Console.Write("Wartosc BMI oznacza  wychudzenie");}
            else if (bmi >= 17 && bmi < 18.5) {Console.Write("Wartosc BMI oznacza  niedowage");}
            else if (bmi >= 18.5 && bmi < 24.5) {Console.Write("Wartosc BMI jest prawidłowa");}
            else if (bmi >= 24.5 && bmi < 30) {Console.Write("Wartosc BMI oznacza  nadwage");}
            else if (bmi >= 30 && bmi < 34.5) {Console.Write("Wartosc BMI oznacza I stopień otyłości");}
            else if (bmi >= 35 && bmi < 40) {Console.Write("Wartosc BMI oznacza II stopień otyłości");}
            else {Console.Write(" Wartosc BMI oznacza skrajną otyłość");}
            Console.ResetColor();
        }

        //Metoda obliczająca prawidłową masę ciała
        public static double Broca_Index_Calculator(int sex, double weight, double height)
        {
            double ideal_weight = 0;
            if (sex == 1)
            {
                ideal_weight = ((height-100)*(0.85));
            }
            else
            {
                ideal_weight = ((height - 100) * (0.9));
            }
            return Math.Round(ideal_weight,2);
        }

        //Metoda obliczająca Podstawową Przemianę Materii
        public static double Basal_Metabolic_Rate(int sex, double weight, double height, int age)
        {
            double BMR = 0;
            if (sex == 1)
            {
                BMR = (655.1 + ((9.563 * weight) + (1.85*height) - (4.676*age)));
            }
            else
            {
                BMR = (66.5 + ((13.75*weight)+(5.003*height)-(6.775*age)));
            }
            return Math.Round(BMR,2);
        }

        //Metoda obliczająca sugerowaną kaloryczność
        public static double Suggested_Caloricity(double weight, double height, double activity, int age, int sex)
        {
            double caloricity=0;
            double BMI = Bmi_Calculate(weight, height);
            double BMR = Basal_Metabolic_Rate(sex, weight, height, age);
            if (BMI < 18.5)
            {
                caloricity = (BMR * activity + 500);//Tycie
            }
            else if (BMI >= 24.5)
            {
                caloricity = (BMR * activity - 500);//Redukcja
            }
            else
            {
                caloricity = BMR * activity;//Utrzymanie masy ciała
            }
            return Math.Round(caloricity,2);
        }

        //Metoda obliczająca kaloryczność poszczególnych posiłków
        public static void Caloricity_Meal(double weight, double height, double activity, int age, int sex)
        {
            double BMR = Calculate.Suggested_Caloricity(weight, height, activity, age, sex);
            Console.WriteLine("Śniadanie: {0} kcal.", Math.Round(BMR*0.25),2);
            Console.WriteLine("Drugie śniadanie: {0} kcal.", Math.Round(BMR*0.1),2);
            Console.WriteLine("Obiad: {0} kcal.", Math.Round(BMR*0.35),2);
            Console.WriteLine("Podwieczorek {0} kcal.", Math.Round(BMR*0.1),2);
            Console.WriteLine("Kolacja {0} kcal.", Math.Round(BMR*0.2),2);
        }
    }
}
