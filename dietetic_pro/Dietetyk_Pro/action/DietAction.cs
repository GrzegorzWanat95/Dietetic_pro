using System;
using System.Collections.Generic;
using System.Text;

namespace DietetykPro
{
    public static class DietAction
    {
        //Tworzenie nowej diety
        public static void New_diet(ref int diet_iterator, List<Meal> meal_base, int patient_iterator, List<Patient>patient_base, List<Diet>diet_base)
        {
            Menu.Header();
            int ID = Check_patient(patient_iterator);
            Menu.Header();
            Console.WriteLine("Załadowano pacjenta: {0}", patient_base[ID].Name);
            Console.ReadKey();
            Menu.Header();
            Menu.Menu_12();
            int meal_number = Check.Get_Int(1, 3);
            Menu.Header();
            Menu.Menu_13();
            int diet_type = Check.Get_Int(1, 5);
            Menu.Header();
            Diet diet = (Diet)Create_Diet_Obj(diet_type, diet_iterator, meal_number, ID);
            Add_meal(meal_base, diet, meal_number, ID, patient_base);
            diet_base.Add(diet);
            diet_iterator++;
        }

        //Tworzenie obiektu dieta
        public static object Create_Diet_Obj(int diet_type, int diet_iterator, int meal_number, int ID)
        {
            if (diet_type == 1)
            {
               Diet diet = new CommonDiet(diet_iterator, meal_number, ID);
                return diet;
            }
            if (diet_type == 2)
            {
                Diet diet = new LactoseFreeDiet(diet_iterator, meal_number, ID);
                return diet;
            }
            if (diet_type == 3)
            {
                Diet diet = new GlutenFreeDiet(diet_iterator, meal_number, ID);
                return diet;
            }
            if (diet_type == 4)
            {
                Diet diet = new WegeDiet(diet_iterator, meal_number, ID);
                return diet;
            }
            if (diet_type == 5)
            {
                Diet diet = new DiabeticDiet(diet_iterator, meal_number, ID);
                return diet;
            }
            return null;
        }

        //Sprawdzanie czy prawidłowo wprowadzono numer ID pacjenta
        public static int Check_patient(int patient_iterator)
        {
            while (true)
            {
                Console.WriteLine("Wprowadź numer ID pacjenta dla którego chcesz ułożyć jadłospis:");
                int ID = Check.Get_Int(0, patient_iterator);
                if (ID < patient_iterator)
                {
                    return ID;
                }
                Menu.Header();
                Console.WriteLine("Nie istnieje pacjent o podanym numerze ID");
            }
        }

        //Wybór typu diety
       public static int Choose_diet_type(int meal_number, Diet diet)
        {
            if (meal_number == 1)
            {
                Menu.Menu_9a();
                int choose = Check.Get_Int(0, 3);
                return choose;
            }
            if (meal_number == 2)
            {
                Menu.Menu_9b();
                int choose = Check.Get_Int(0, 4);
                return choose;
            }
            else
            {
                Menu.Menu_9c();
                int choose = Check.Get_Int(0, 5);
                return choose;
            }
        }

        //Funckja sprawdzająca czy w posiłku znajdują się alergeny/wykluczone produkty
        public static bool Eliminate_restriction(Meal meal, Diet diet)
        {
            Menu.Header();
            foreach (var item in meal.Ingredient)
            {
                if ((item is Dairy) && (diet is LactoseFreeDiet) || ((item is Grain) && (diet is GlutenFreeDiet) || ((item is Sweet) && (diet is DiabeticDiet) || ((item is Meat) && (diet is WegeDiet)))))
                {
                    item.Product_Restriction();
                    Console.WriteLine("Nie dodano posiłku");
                    Console.ReadKey();
                    return true;
                }
            }
            return false;
        }

        //Dodawanie dań do jadłospisu i eliminacja posiłków zawierających składniki wykluczone z diety
        public static void Filtr_Meal(int number, Meal meal, Diet diet)
        {
            bool restriction = Eliminate_restriction(meal, diet);
            if (diet.Meal_number == 1)
            {
                if ((number == 1) && (restriction == false))
                {
                    diet.m1.Add(meal);//Śniadanie
                }
                if ((number == 2) && (restriction == false))
                {
                    diet.m3.Add(meal);//Obiad
                }
                if ((number == 3) && (restriction == false))
                {
                    diet.m5.Add(meal);//Kolacja
                }
            }
            if (diet.Meal_number == 2)
            {
                if ((number == 1) && (restriction == false))
                {
                    diet.m1.Add(meal);//Śniadanie
                }
                if ((number == 2) && (restriction == false))
                {
                    diet.m2.Add(meal);//II Śniadanie
                }
                if ((number == 3) && (restriction == false))
                {
                    diet.m3.Add(meal);//Obiad
                }
                if ((number == 4) && (restriction == false))
                {
                    diet.m5.Add(meal);//Kolacja
                }
            }
            if (diet.Meal_number == 3)
            {
                if ((number == 1) && (restriction == false))
                {
                    diet.m1.Add(meal);//Śniadanie
                }
                if ((number == 2) && (restriction == false))
                {
                    diet.m2.Add(meal);//II Śniadanie
                }
                if ((number == 3) && (restriction == false))
                {
                    diet.m3.Add(meal);//Obiad
                }
                if ((number == 4) && (restriction == false))
                {
                    diet.m4.Add(meal);//Podwieczorek
                }
                if ((number == 5) && (restriction == false))
                {
                    diet.m5.Add(meal);//Kolacja
                }
            }

        }

        //Dodawanie posiłków do jadłospisu
        public static void Add_meal(List<Meal> meal_base, Diet diet, int meal_number, int patient_id, List<Patient> patient_base)
        {
            Console.Clear();
            bool exit = false;
            while(exit != true)
            {
                Menu.Header();
                Common_Action(5, diet, patient_id, patient_base, meal_number, meal_base);//Wyświetlenie obecnego stanu diety
                Menu.Menu_14();
                Console.WriteLine();
                int choose2 = Check.Get_Int(0, 4);
                exit = Common_Action(choose2, diet, patient_id, patient_base, meal_number, meal_base);
                if (choose2 == 1)
                {
                    Menu.Header();
                    Console.WriteLine("Dodaj produkty do jadłospisu:");
                    int choose = Choose_diet_type(meal_number, diet);
                    if (choose != 0)
                    {
                        Add(meal_base, choose, diet);
                        choose = 0;
                    }
                }
            }
        }

        static void Add(List<Meal>meal_base, int choose, Diet diet)
        {
            string name = null;
            int ID;
            Menu.Header();
            Console.Write("Wprowadź nazwę dania, które chcesz dodać: ");
            name = Check.Get_String();
            ID = MealAction.Meal_Exist(meal_base, name);
            if (choose != 0)
            {
                if (ID != -1)
                {
                    Filtr_Meal(choose, meal_base[ID], diet);
                }
                else
                {
                    Menu.Header();
                    Console.WriteLine("Nie istnieje posiłek o wprowadzonej nazwie");
                    Console.ReadKey();
                }
            }
        }

        //Funkcja pomocnicza (wybór liczby posiłków)
        public static bool Common_Action(int choose, Diet diet, int ID, List<Patient> patient_base, int number, List<Meal> meal_base)
        {
            if (choose == 1)
            {
                Console.Clear();
                return false;
            }
            if (choose == 2)
            {
                Menu.Header();
                Console.WriteLine("Lista posiłków jadłospisu:");
                diet.Print_Day(number, diet);
                Console.WriteLine();
                Console.WriteLine("Wybierz posiłek, który chcesz zmodyfikwoać:");
                int edit_meal = Choose_diet_type(number, diet);
                Edit_Diet(meal_base, edit_meal, diet);
                return false;
            }
            if(choose == 3)
            {
                Menu.Header();
                Print_Products(diet);
                Console.WriteLine();
                Console.WriteLine("Naciśnij przycisk, by wrócić do generatora jadłospisów");
                Console.ReadKey();
                return false;
            }
            if(choose == 4)
            {
                Menu.Header();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Posiłki do wykorzystania w jadłospisie:");
                Console.ResetColor();
                MealAction.Return_Meal_Base(meal_base);
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Naciśnij przycisk, by wrócić do generatora jadłospisów");
                Console.ResetColor();
                Console.ReadKey();
                return false;
            }
            if (choose == 5)
            {
                Menu.Header();
                Console.WriteLine("---Jadłospis---");
                diet.Print_Day(number, diet);
                diet.Diet_Report(diet, ID, patient_base);
                return false;
            }
            return true;
        }

    public static void Print_Breakfast(Diet diet)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("-Śniadanie-");
            Console.ResetColor();
            foreach (var item in diet.m1)
            {
                Console.WriteLine(item.Meal_name);
            }
            Console.WriteLine();
        }
        public static void Print_Lunch(Diet diet)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("-II Śniadanie-");
            Console.ResetColor();
            foreach (var item in diet.m2)
            {
                Console.WriteLine(item.Meal_name);
            }
            Console.WriteLine();
        }
        public static void Print_Dinner(Diet diet)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("-Obiad-");
            Console.ResetColor();
            foreach (var item in diet.m3)
            {
                Console.WriteLine(item.Meal_name);
            }
            Console.WriteLine();
        }
        public static void Print_Tea(Diet diet)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("-Podwieczorek-");
            Console.ResetColor();
            foreach (var item in diet.m4)
            {
                Console.WriteLine(item.Meal_name);
            }
            Console.WriteLine();
        }
        public static void Print_Supper(Diet diet)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("-Kolacja-");
            Console.ResetColor();
            foreach (var item in diet.m5)
            {
                Console.WriteLine(item.Meal_name);
            }
            Console.WriteLine();
        }

        public static void Edit_Diet(List<Meal>meal_base, int number, Diet diet)
        {
            Menu.Header();
            Console.WriteLine("Wprowadź nazwę dania, które chcesz usunąć:");
            string name = Check.Get_String();
            int check = MealAction.Meal_Exist(meal_base, name);
            Console.WriteLine(check);
            if (check!= (-1))
            {
                if(diet.Meal_number == 1)//Dieta 3 daniowa
                {
                    if (number == 1)
                    {
                        foreach (var meal in diet.m1)
                        {
                            if (name == meal.Meal_name)
                            {
                                diet.m1.Remove(meal);
                                diet.Remove(meal);
                                Console.WriteLine("Usunięto danie");
                                break;
                            }
                        }
                    }
                    if (number == 2)
                    {
                        foreach (var meal in diet.m3)
                        {
                            if (name == meal.Meal_name)
                            {
                                diet.m3.Remove(meal);
                                diet.Remove(meal);
                                Console.WriteLine("Usunięto danie");
                                break;
                            }
                        }
                    }
                    if (number == 3)
                    {
                        foreach (var meal in diet.m5)
                        {
                            if (name == meal.Meal_name)
                            {
                                diet.m5.Remove(meal);
                                diet.Remove(meal);
                                Console.WriteLine("Usunięto danie");
                                break;
                            }
                        }
                    }
                }
                if(diet.Meal_number == 2)//Dieta 4 daniowa
                {
                    if (number == 1)
                    {
                        foreach (var meal in diet.m1)
                        {
                            if (name == meal.Meal_name)
                            {
                                diet.m1.Remove(meal);
                                diet.Remove(meal);
                                Console.WriteLine("Usunięto danie");
                                break;
                            }
                        }
                    }
                    if (number == 2)
                    {
                        foreach (var meal in diet.m2)
                        {
                            if (name == meal.Meal_name)
                            {
                                diet.m2.Remove(meal);
                                diet.Remove(meal);
                                Console.WriteLine("Usunięto danie");
                                break;
                            }
                        }
                    }
                    if (number == 3)
                    {
                        foreach (var meal in diet.m3)
                        {
                            if (name == meal.Meal_name)
                            {
                                diet.m3.Remove(meal);
                                diet.Remove(meal);
                                Console.WriteLine("Usunięto danie");
                                break;
                            }
                        }
                    }
                    if (number == 4)
                    {
                        foreach (var meal in diet.m5)
                        {
                            if (name == meal.Meal_name)
                            {
                                diet.m5.Remove(meal);
                                diet.Remove(meal);
                                Console.WriteLine("Usunięto danie");
                                break;
                            }
                        }
                    }
                }
                if (diet.Meal_number == 3)//Dieta 5 daniowa
                {
                    if (number == 1)
                    {
                        foreach (var meal in diet.m1)
                        {
                            if (name == meal.Meal_name)
                            {
                                diet.m1.Remove(meal);
                                diet.Remove(meal);
                                Console.WriteLine("Usunięto danie");
                                break;
                            }
                        }
                    }
                    if (number == 2)
                    {
                        foreach (var meal in diet.m2)
                        {
                            if (name == meal.Meal_name)
                            {
                                diet.m2.Remove(meal);
                                diet.Remove(meal);
                                Console.WriteLine("Usunięto danie");
                                break;
                            }
                        }
                    }
                    if (number == 3)
                    {
                        foreach (var meal in diet.m3)
                        {
                            if (name == meal.Meal_name)
                            {
                                diet.m3.Remove(meal);
                                diet.Remove(meal);
                                Console.WriteLine("Usunięto danie");
                                break;
                            }
                        }
                    }
                    if (number == 4)
                    {
                        foreach (var meal in diet.m4)
                        {
                            if (name == meal.Meal_name)
                            {
                                diet.m4.Remove(meal);
                                diet.Remove(meal);
                                Console.WriteLine("Usunięto danie");
                                break;
                            }
                        }
                    }
                    if (number == 5)
                    {
                        foreach (var meal in diet.m5)
                        {
                            if (name == meal.Meal_name)
                            {
                                diet.m5.Remove(meal);
                                diet.Remove(meal);
                                Console.WriteLine("Usunięto danie");
                                break;
                            }
                        }
                    }
                }         
            }
            else
            {
                Console.WriteLine("Nie istnieje danie o podanej nazwie");
            }
            
        }

        public static void Print_Products(Diet diet)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine();
            Console.WriteLine("---Składniki diety---");
            Console.ResetColor();
            foreach (var item in diet.m1)
            {
                item.Print_Ingredients();
            }
            foreach (var item in diet.m2)
            {
                item.Print_Ingredients();
            }
            foreach (var item in diet.m3)
            {
                item.Print_Ingredients();
            }
            foreach (var item in diet.m4)
            {
                item.Print_Ingredients();
            }
            foreach (var item in diet.m5)
            {
                item.Print_Ingredients();
            }
        }

        public static void Print_Patient_Diet(List<Patient> patient_base, List<Diet> diet_base, int patient_iterator)
        {
            int ID = PatientAction.Get_Patient(patient_base, patient_iterator);
            int iterator = 1;
            bool find = false;
            Menu.Header();
            foreach (var diet in diet_base)
            {
                if(diet.Patient_id == ID)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Jadłospis {0}.", iterator);
                    Console.ResetColor();
                    diet.Diet_Report(diet, ID, patient_base);
                    Print_Products(diet);
                    iterator++;
                    Console.WriteLine();
                    find = true;
                }
            }
            if(find == false)
            {
                Console.WriteLine("Nie istnieją jadłospisy dla podanego pacjenta");
            }
            Console.ReadKey();
        }

        public static void Remove_Diet(ref List<Diet> diet_base, int patient)
        {
            int iterator = 0;
            bool delete = false;
            while (delete != true) 
            {
                //Usuwanie diety
                foreach (var diet in diet_base)
                {
                    if(diet.Patient_id == patient)
                    {
                        diet_base.Remove(diet);
                        break;
                    }
                }
                //Sprawdzenie czy baza diet tego pacjenta jest pusta
                foreach (var diet in diet_base)
                {
                    if (diet.Patient_id == patient)
                    {
                        delete = false;
                        break;
                    }
                    else
                    {
                        delete = true;
                    }
                    iterator++;
                }
                if(iterator == diet_base.Count)//W bazie nie ma jadłospisów pacjenta
                {
                    delete = true;
                }
            }

        }
    }
}

