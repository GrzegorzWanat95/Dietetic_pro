using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace DietetykPro
{
    [Serializable]

    public class Patient
    {
        protected long _PESEL;
        protected int _ID_number;
        private int _current_date;
        private int _year;
        private string _full_name;
        private double _weight;
        private double _height;
        private double _activity;
        private int _sex;

        public Patient()
        {

        }

        public Patient(int iD_number, int current_date, int year, long PESEL, string full_name, double weight, double height, double activity, int sex)
        {
            _ID_number = iD_number;
            _current_date = current_date;
            _year = year;
            _PESEL = PESEL;
            _full_name = full_name;
            _weight = weight;
            _height = height;
            _activity = activity;
            _sex = sex;
        }

        [XmlElement("ID_number")]
        public int ID
        {
            get => _ID_number;
            set => _ID_number = value;
        }

        [XmlAttribute("current_date")]
        public int Current_date
        {
            get => _current_date;
            set => _current_date = value;
        }
        [XmlAttribute("Year")]
        public int Year
        {
            get => _year;
            set => _year = value;
        }
        [XmlAttribute("PESEL")]
        public long Pesel
        {
            get => _PESEL;
            set => _PESEL = value;
        }
        [XmlAttribute("Full_Name")]
        public string Full_Name
        {
            get => _full_name;
            set => _full_name = value;
        }

        [XmlAttribute("Sex")]
        public int Sex
        {
            get => _sex;
            set => _sex = value;
        }

        [XmlAttribute("Dane osobowe")]
        public string Name { get => _full_name; }

        [XmlAttribute("Waga")]
        public double Weight { get => _weight; set => _weight = value; }

        [XmlAttribute("Wzrost")]
        public double Height { get => _height; set => _height = value; }

        [XmlAttribute("Aktywność")]
        public double Activity {get => _activity; set => _activity = value;}

        //Metoda obliczająca BMI
        public double Return_Bmi()
        {
            double BMI = Calculate.Bmi_Calculate(Weight, _height);
            return BMI;
        }

        //Metoda zwracająca Podstawową przemianą materii w kaloriach
        public double Return_Bmr()
        {
            double BMR = Calculate.Basal_Metabolic_Rate(_sex, _weight, Height, (DateTime.Now.Year - _year));
            return BMR;
        }

        //Metoda zwracająca prawidłową wagę pacjenta
        public double Return_Ideal_Weight()
        {
            double ideal_weight = Calculate.Broca_Index_Calculator(_sex, _weight, _height);
            return ideal_weight;
        }

        //Metoda zwracająca sugerowaną kaloryczność dla pacjenta
        public double Return_Sugested_Caloricity()
        {
            double caloricity = Calculate.Suggested_Caloricity(_weight, _height, _activity, (DateTime.Now.Year - _year), _sex);
            return caloricity;
        }

        //Metoda wyświetlajaca sugerowaną kaloryczność posiłków
        public void Return_Caloricity_Meal()
        {
            Calculate.Caloricity_Meal(Weight,Height, _activity, DateTime.Now.Year-_year,_sex);
        }

        //Metoda generująca raport na temat stanu zdrowia pacjenta
        public void Return_Report()
        {
            Console.WriteLine("BMI pacjenta wynosi: {0}", Math.Round(Calculate.Bmi_Calculate(Weight, _height)),2);
            Calculate.BMI_Interpretation(Calculate.Bmi_Calculate(Weight, _height));
            Console.WriteLine();
            Console.WriteLine("Prawidłowa masa ciała pacjenta wynosi: {0} kg.", Math.Round(Return_Ideal_Weight()),2);
            Console.WriteLine("Podstawowa przemiana materii dla pacjenta to {0} kcal.", Math.Round(Return_Bmr()),2);
            Console.WriteLine("Sugerowana kaloryczność dla pacjenta wynosi: {0} kcal.", Return_Sugested_Caloricity());
            Console.WriteLine();
            Return_Caloricity_Meal();
        }

        //Metoda zwracająca wprowadzone dane pacjenta
        public void Print_Patient()
        {
            Console.WriteLine("Imię i nazwisko: " + _full_name);
            if (_sex == 1) { Console.WriteLine("Płeć: Kobieta"); }
            else { Console.WriteLine("Płeć: Mężczyzna"); }
            Console.WriteLine("Rok urodzenia: {0}", _year);
            Console.WriteLine("Numer PESEL: {0}", _PESEL);
            Console.WriteLine("Waga: {0} kg.", _weight);
            Console.WriteLine("Wzrost: {0} cm.", _height);
            Console.WriteLine("Aktywność fizyczna: {0}", _activity);
            Console.WriteLine();
        }
    }
}
