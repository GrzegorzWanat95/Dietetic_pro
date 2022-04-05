using System;
using System.Collections.Generic;
using System.Text;

namespace DietetykPro
{
    class Test
    {
        //Tworzenie małej bazy pacjentów na potrzeby testów
        static public void New_Patient_Test(ref List <Patient> patient_base,ref int patient_iterator,ref int current_date)
        {
            int _ID_number = patient_iterator;
            int _current_date = current_date;
            int _year = 1968;
            long _PESEL = 68081511870;
            string _full_name = "Stanisław Wąski";
            double _weight = 96;
            double _height = 184;
            float _activity = 1;
            int _sex = 2;
            patient_base.Add(new Patient(_ID_number, _current_date, _year, _PESEL, _full_name, _weight, _height, _activity, _sex));//Stworzenie nowego obiektu.
            patient_iterator++;

            _ID_number = patient_iterator;
            _current_date = current_date;
            _year = 1985;
            _PESEL = 85081511870;
            _full_name = "Zbigniew Kowalski";
            _weight = 80;
            _height = 174;
            _activity = 2;
            _sex = 2;
            patient_base.Add(new Patient(_ID_number, _current_date, _year, _PESEL, _full_name, _weight, _height, _activity, _sex));//Stworzenie nowego obiektu.
            patient_iterator++;

            _ID_number = patient_iterator;
            _current_date = current_date;
            _year = 1992;
            _PESEL = 92081511870;
            _full_name = "Janina Szczupła";
            _weight = 60;
            _height = 160;
            _activity = 4;
            _sex = 1;
            patient_base.Add(new Patient(_ID_number, _current_date, _year, _PESEL, _full_name, _weight, _height, _activity, _sex));//Stworzenie nowego obiektu.
            patient_iterator++;

            _ID_number = patient_iterator;
            _current_date = current_date;
            _year = 1997;
            _PESEL = 97081511870;
            _full_name = "Karolina Paluch";
            _weight = 75;
            _height = 170;
            _activity = 3;
            _sex = 1;
            patient_base.Add(new Patient(_ID_number, _current_date, _year, _PESEL, _full_name, _weight, _height, _activity, _sex));//Stworzenie nowego obiektu.
            patient_iterator++;
        }

        //Tworzenie małej bazy produktów na potrzeby testów
        static public void New_Product_Test(ref List <Product> product_base,ref int product_iterator, ref int meal_iterator)
        {
            int _product_id = product_iterator;
            int _meal_id = meal_iterator;
            string _product_name = "Jabłko";
            int _caloricity = 50;
            int _carbohydrate = 10;
            int _protein = 1;
            int _fat = 0;
            product_base.Add(new Vegetable(_product_id, _product_name, _caloricity, _carbohydrate, _protein, _fat));//Stworzenie nowego obiektu.
            product_iterator++;

            _product_id = product_iterator;
            _meal_id = meal_iterator;
            _product_name = "Mleko";
            _caloricity = 50;
            _carbohydrate = 10;
            _protein = 1;
            _fat = 0;
            product_base.Add(new Dairy(_product_id, _product_name, _caloricity, _carbohydrate, _protein, _fat));//Stworzenie nowego obiektu.
            product_iterator++;

            _product_id = product_iterator;
            _meal_id = meal_iterator;
            _product_name = "Ziemniaki";
            _caloricity = 50;
            _carbohydrate = 10;
            _protein = 1;
            _fat = 0;
            product_base.Add(new Vegetable(_product_id, _product_name, _caloricity, _carbohydrate, _protein, _fat));//Stworzenie nowego obiektu.
            product_iterator++;

            _product_id = product_iterator;
            _meal_id = meal_iterator;
            _product_name = "Chleb";
            _caloricity = 50;
            _carbohydrate = 10;
            _protein = 1;
            _fat = 0;
            product_base.Add(new Grain(_product_id, _product_name, _caloricity, _carbohydrate, _protein, _fat));//Stworzenie nowego obiektu.
            product_iterator++;

            _product_id = product_iterator;
            _meal_id = meal_iterator;
            _product_name = "Cebula";
            _caloricity = 50;
            _carbohydrate = 10;
            _protein = 1;
            _fat = 0;
            product_base.Add(new Vegetable(_product_id, _product_name, _caloricity, _carbohydrate, _protein, _fat));//Stworzenie nowego obiektu.
            product_iterator++;

            _product_id = product_iterator;
            _meal_id = meal_iterator;
            _product_name = "Pierś z kurczaka";
            _caloricity = 200;
            _carbohydrate = 20;
            _protein = 15;
            _fat = 30;
            product_base.Add(new Meat(_product_id, _product_name, _caloricity, _carbohydrate, _protein, _fat));//Stworzenie nowego obiektu.
            product_iterator++;

            _product_id = product_iterator;
            _meal_id = meal_iterator;
            _product_name = "Frytki";
            _caloricity = 250;
            _carbohydrate = 80;
            _protein = 3;
            _fat = 0;
            product_base.Add(new Vegetable(_product_id, _product_name, _caloricity, _carbohydrate, _protein, _fat));//Stworzenie nowego obiektu.
            product_iterator++;

            _product_id = product_iterator;
            _meal_id = meal_iterator;
            _product_name = "Czekolada";
            _caloricity = 300;
            _carbohydrate = 150;
            _protein = 10;
            _fat = 10;
            product_base.Add(new Sweet(_product_id, _product_name, _caloricity, _carbohydrate, _protein, _fat));//Stworzenie nowego obiektu.
            product_iterator++;
        }

        //tworzenie małej bazy posiłków na potrzeby testów
        static public void New_Meal_Test(ref int meal_iterator, List<Meal>meal_base, List<Product>product_base)
        {
            string _meal_name = "Obiad";
            meal_base.Add(new Meal(_meal_name, meal_iterator));
            foreach (var item in product_base)
            {
                if(item.Product_name == "Ziemniaki")
                {
                    meal_base[meal_iterator].Add_Ingredient(item, 100);
                }
                if (item.Product_name == "Pierś z kurczaka")
                {
                    meal_base[meal_iterator].Add_Ingredient(item, 100);
                }
            }
            meal_base[meal_iterator].Calculate();
            meal_iterator++;

            _meal_name = "Śniadanie";
            meal_base.Add(new Meal(_meal_name, meal_iterator));
            foreach (var item in product_base)
            {
                if (item.Product_name == "Mleko")
                {
                    meal_base[meal_iterator].Add_Ingredient(item, 100);
                }
                if (item.Product_name == "Chleb")
                {
                    meal_base[meal_iterator].Add_Ingredient(item, 100);
                }
            }
            meal_base[meal_iterator].Calculate();
            meal_iterator++;

            _meal_name = "II Śniadanie";
            meal_base.Add(new Meal(_meal_name, meal_iterator));
            foreach (var item in product_base)
            {
                if (item.Product_name == "Jabłko")
                {
                    meal_base[meal_iterator].Add_Ingredient(item, 100);
                }
                if (item.Product_name == "Czekolada")
                {
                    meal_base[meal_iterator].Add_Ingredient(item, 100);
                }
            }
            meal_base[meal_iterator].Calculate();
            meal_iterator++;

            _meal_name = "Podwieczorek";
            meal_base.Add(new Meal(_meal_name, meal_iterator));
            foreach (var item in product_base)
            {
                if (item.Product_name == "Mleko")
                {
                    meal_base[meal_iterator].Add_Ingredient(item, 100);
                }
                if (item.Product_name == "Czekolada")
                {
                    meal_base[meal_iterator].Add_Ingredient(item, 100);
                }
            }
            meal_base[meal_iterator].Calculate();
            meal_iterator++;

            _meal_name = "Kolacja";
            meal_base.Add(new Meal(_meal_name, meal_iterator));
            foreach (var item in product_base)
            {
                if (item.Product_name == "Frytki")
                {
                    meal_base[meal_iterator].Add_Ingredient(item, 100);
                }
            }
            meal_base[meal_iterator].Calculate();
            meal_iterator++;
        }
    }
}
