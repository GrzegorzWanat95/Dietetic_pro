using System;
using System.Collections.Generic;
using System.Text;

namespace DietetykPro
{
    static class MealAction
    {
        //Tworzenie nowego dania
        public static void New_Meal(List<Meal> meal_base, ref int meal_iterator, List<Product> product_base)
        {
            int meal_id = meal_iterator;
            string meal_name = Return_Name("Wprowadź nazwę dania:", meal_base);
            if (Meal_Exist(meal_base, meal_name) == -1)
            {
                Console.Clear();
                Meal meal = new Meal(meal_name, meal_id);
                meal_base.Add(meal);
                MealAction.Add_Product(meal, product_base, meal_base);
                meal_iterator++;
            }
            else
            {
                Console.WriteLine("Istnieje już posiłek o podanej nazwie");
            }

        }

        //Dodawanie składników dania (jeśli nie zakończy się powodzeniem to danie zostaje usunięte z bazy)
        public static void Add_Product(Meal meal, List<Product>product_base, List<Meal> meal_base)
        {
            int choose;
            bool exit = false;
            while (exit != true)
            {
                Menu.Header();
                int ID;
                double weight;
                Console.WriteLine("Dodaj składnik produktu oraz jego wagę:");
                Console.WriteLine("Wprowadź nazwę dodawanego produktu lub naciśnij 0, by wrócić do menu:");
                string name = Check.Get_String();
                Console.Clear();
                ID = ProductAction.Product_Exist(product_base, name);
                if (name == "0") 
                {
                    meal_base.Remove(meal);
                    Console.WriteLine("Nie utworzono posiłku");
                    break; 
                }
                else if (ID == -1)
                {
                    Console.WriteLine("Nie istnieje produkt o podanej nazwie w bazie produktów");
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("Wprowadź jego wagę w gramach:");
                    weight = Check.Get_Double(0, double.MaxValue);
                    meal.Add_Ingredient(product_base[ID], weight);
                    Menu.Menu_7();
                    choose = Check.Get_Int(1, 2);
                    if (choose == 2)
                    {
                        meal.Calculate();
                        exit = true;
                    }
                    Console.Clear();
                }
            }
        }

        //Edycja posiłku
        public static void Edit_Meal(List<Meal> meal_base)
        {
            bool end = false;
            int iterator = 0;
            string name = Return_Name("Wprowadź nazwę posiłku:", meal_base);
            int ID = Meal_Exist(meal_base, name);
            if (ID != -1)
            {
                while (end!=true)
                {
                    Menu.Header();
                    Quick_Print("Składniki posiłku:", name, ID, meal_base);
                    Console.WriteLine("Wprowadź nazwę składnika, który chcesz zmienić lub naciśnij zero by zakończyć edycję:");
                    string choose = Check.Get_String();
                    if(choose == "0") { break; }
                    Menu.Header();
                    double weight;
                    foreach (var item in meal_base[ID].Ingredient)
                    {
                        if (item.Product_name == choose)
                        {
                            Menu.Menu_11();
                            int choose2 = Check.Get_Int(0, 2);
                            if (choose2 == 1)
                            {
                                meal_base[ID].Remove_ingredient(choose);
                                break;
                            }
                            if(choose2==2)
                            {
                                Menu.Header();
                                Console.WriteLine("Wprowadź nową wagę produktu:");
                                meal_base[ID].Edit_ingredient(iterator, weight = Check.Get_Double(0, Double.MaxValue));
                                break;
                            }
                            if(choose2 ==0)
                            {
                                end = true;
                                break;
                            }
                        }
                        iterator++;
                    }
                    iterator = 0;
                    Console.Clear();
                    Console.WriteLine("Zmieniono posiłek:");
                    foreach (var product in meal_base[ID].Ingredient)
                    {
                        Console.WriteLine("{0}. {1} {2}g", iterator, product.Product_name, meal_base[ID].Weight[iterator]);
                        iterator++;
                    }
                }
            }
        }

        //Pobieranie nazwy dania od użytkownika
        public static string Return_Name(string msg, List<Meal> meal_base)
        {
            Console.WriteLine(msg);
            string name = Check.Get_String();
            return name;
        }

        //Sprawdzenie czy dany posiłek istnieje w bazie
        static public int Meal_Exist(List<Meal> meal_base, string name)
        {
            int iterator = 0;
            foreach (var item in meal_base)
            {
                if (item.Meal_name == name)
                {
                    return iterator;
                }
                iterator++;
            }
            return -1;
        }

        //Wypisanie danych posiłku z poziomu klasy
        public static void Quick_Print(string msg, string name, int ID, List<Meal> meal_base)
        {
            if (ID != -1) { meal_base[ID].Print_Meal(); }
            else { Console.WriteLine("Nie istnieje posiłek o podanej nazwie"); }
        }

        //Wypisanie danych posiłku z poziomu menu głównego
        public static void Print_Meal(List<Meal> meal_base)
        {
            string name = Return_Name("Wprowadź nazwę dania", meal_base);
            int ID = Meal_Exist(meal_base, name);
            if (ID != -1) { meal_base[ID].Print_Meal(); }
            else { Console.WriteLine("Nie istnieje posiłek o podanej nazwie"); }
        }

        //Funkcja wyświetlająca wszystkie posiłki z aktualnej bazy działającego programu
        static public void Return_Meal_Base(List<Meal> meal_base)
        {
            int i = 1;//iterator
            foreach (var meal in meal_base)
            {
                Console.WriteLine("{0}. {1}", i, meal.Meal_name);
                i++;
            }
        }

        //Funkcja usuwajaca posiłek z bazy
        static public void Remove_Meal(List<Meal> meal_base)
        {
            Console.WriteLine("Wprowadź nazwę posiłku, który chcesz usunąć:");
            string name = Check.Get_String();
            int ID = Meal_Exist(meal_base, name);
            if (ID != -1)
            {
                Console.WriteLine("Usunięto posiłek {0}", meal_base[ID].Meal_name);
                Console.ReadKey();
                meal_base.Remove(meal_base[ID]);
            }
            else
            {
                Console.WriteLine("Nie istnieje posiłek o podanej nazwie");
            }

        }
    }
}
