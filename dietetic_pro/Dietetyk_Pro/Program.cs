using DietetykPro.serialization;
using DietetykPro.serialization.impl;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;

namespace DietetykPro
{
    class Program
    {
        //Zmienne globalne na potrzeby programu
        static List<Patient> patient_base = new List<Patient>();//Baza pacjentów typu lista. 
        static List<Meal> meal_base = new List<Meal>();//Baza posiłków typu lista.
        static List<Product> product_base = new List<Product>();//Baza produktów typu lista.
        static List<Diet> diet_base = new List<Diet>();//Baza produktów typu lista.
        static int patient_iterator = 0;//Generator numerów ID pacjentów.
        static int product_iterator = 0;//Generator numerów ID produktów.
        static int meal_iterator = 0;//Generator numerów ID posiłków.
        static int diet_iterator = 0;//Generator numerów ID diet.
        static int current_date = DateTime.Now.Year;//Aktualna data na potrzeby walidacji wieku pacjenta. 
        static bool end = false;//Zmienna odpowiedzialna za wyłączenie programu.

        static void Main(string[] args)
        {

            //Pętla w której działa program. 
            while (end != true)
            {
                //Wyświetlenie menu głównego.
                Load_All();//Wczytanie danych demonstracyjnych
                Menu.Header();
                Menu.Menu_0();
                int choose = Check.Get_Int(0, 4);
                {
                    switch (choose)
                    {
                        case 1://Pacjenci
                            Console.Clear();
                            Menu.Header();
                            Menu.Menu_Patient();
                            int choose_1 = Check.Get_Int(0, 7);
                            switch (choose_1)
                            {
                                case 1://Dodaj pacjenta
                                    Menu.Header();
                                    PatientAction.New_Patient(ref patient_iterator, patient_base);
                                    SerializeAction.Save_Patient_List(patient_base);
                                    Menu.Back();
                                    break;
                                case 2://Zmień dane pacjenta
                                    Menu.Header();
                                    PatientAction.Edit_Patient(patient_base, patient_iterator, current_date);
                                    SerializeAction.Save_Patient_List(patient_base);
                                    Menu.Back();
                                    break;
                                case 3://Wyświetl dane pacjenta
                                    Menu.Header();
                                    PatientAction.Print_Patient(patient_base, patient_iterator);
                                    Menu.Back();
                                    break;
                                case 4://Wykonaj obliczenia
                                    Menu.Header();
                                    PatientAction.Calculate_Patient(patient_base, patient_iterator);
                                    Menu.Back();
                                    break;
                                case 5://Stwórz jadłospis
                                    DietAction.New_diet(ref diet_iterator, meal_base, patient_iterator, patient_base, diet_base);
                                    SerializeAction.Save_Diet_List(diet_base);
                                    Menu.Header();
                                    Menu.Back();
                                    break;
                                case 6://Wyświetl jadłospisy
                                    Menu.Header();
                                    DietAction.Print_Patient_Diet(patient_base, diet_base, patient_iterator);
                                    Menu.Header();
                                    Menu.Back();
                                    break;
                                case 7://Usuwanie pacjenta z bazy
                                    Menu.Header();
                                    PatientAction.Remove_Patient(patient_base, ref diet_base, patient_iterator);
                                    SerializeAction.Save_Patient_List(patient_base);
                                    SerializeAction.Save_Diet_List(diet_base);
                                    Menu.Header();
                                    Menu.Back();
                                    break;
                                case 0://Powrót do menu
                                    Menu.Header();
                                    Menu.Back();
                                    break;
                            }
                            break;

                        case 2://Produkty
                            Menu.Header();
                            Menu.Menu_Product();
                            int choose_2 = Check.Get_Int(0, 4);
                            switch (choose_2)
                            {
                                case 1://Dodaj produkt
                                    Menu.Header();
                                    ProductAction.New_Product(product_base, ref product_iterator);
                                    SerializeAction.Save_Product_List(product_base);
                                    Menu.Back();
                                    break;
                                case 2://Zmień dane produktu
                                    Menu.Header();
                                    ProductAction.Edit_Product(product_base);
                                    SerializeAction.Save_Product_List(product_base);
                                    Menu.Back();
                                    break;
                                case 3://Wyświetl dane produktu
                                    Menu.Header();
                                    ProductAction.Print_Product(product_base);
                                    Menu.Back();
                                    break;
                                case 4://Usuń produkt z bazy
                                    Menu.Header();
                                    ProductAction.Remove_Product(product_base);
                                    SerializeAction.Save_Product_List(product_base);
                                    Menu.Back();
                                    break;
                                case 0://Powrót do menu
                                    Menu.Header();
                                    Menu.Back();
                                    break;
                            }
                            break;

                        case 3://Posiłki
                            Menu.Header();
                            Menu.Menu_Meal();
                            int choose_3 = Check.Get_Int(0, 4);
                            switch (choose_3)
                            {
                                case 1://Dodaj posiłek
                                    Menu.Header();
                                    MealAction.New_Meal(meal_base, ref meal_iterator, product_base);
                                    SerializeAction.Save_MealList(meal_base);
                                    Menu.Back();
                                    break;
                                case 2://Zmień dane posiłku
                                    Menu.Header();
                                    MealAction.Edit_Meal(meal_base);
                                    SerializeAction.Save_MealList(meal_base);
                                    Menu.Back();
                                    break;
                                case 3://Wyświetl dane posiłku
                                    Menu.Header();
                                    MealAction.Print_Meal(meal_base);
                                    Menu.Back();
                                    break;
                                case 4://Usuń posiłek z bazy
                                    Menu.Header();
                                    MealAction.Remove_Meal(meal_base);
                                    SerializeAction.Save_MealList(meal_base);
                                    Menu.Back();
                                    break;
                                case 0://Powrót do menu
                                    Menu.Header();
                                    Menu.Back();
                                    break;
                            }
                            break;

                        case 4://Bazy
                            Menu.Header();
                            Menu.Menu_Base();
                            int choose_4 = Check.Get_Int(0, 3);
                            switch (choose_4)
                            {
                                case 1://Wyświetl listę pacjentów
                                    Menu.Header();
                                    PatientAction.Return_Patient_Base(patient_base);
                                    Menu.Back();
                                    break;
                                case 2://Wyświetl listę produktów
                                    Menu.Header();
                                    ProductAction.Return_Product_Base(product_base);
                                    Menu.Back();
                                    break;
                                case 3://Wyświetl listę posiłków
                                    Menu.Header();
                                    MealAction.Return_Meal_Base(meal_base);
                                    Menu.Back();
                                    break;                             
                                case 0://Powrót do menu
                                    Menu.Header();
                                    Menu.Back();
                                    break;  
                            }
                            break;
                        case 0://Wyjście z programu. 
                            Save_All();
                            Console.WriteLine("Autorzy: Grzegorz Wanat, Konrad Wojtyra, grupa K63");
                            end = true;
                            break;
                        default:
                            Console.Clear();
                            Menu.Header();
                            Console.WriteLine("Podaj poprawną wartość");
                            break;
                    }
                }
            }

            //Zapis danych do plików
            static void Save_All()
            {
                SerializeAction.Save_Patient_List(patient_base);
                SerializeAction.Save_Product_List(product_base);
                SerializeAction.Save_MealList(meal_base);
                SerializeAction.Save_Diet_List(diet_base);
            }

            //Odczyt zapisanych danych z plików xml
            static void Load_All()
            {
                try
                {
                    patient_base = SerializeAction.Load_Patient_List(patient_base, ref patient_iterator);
                    product_base = SerializeAction.Load_Product_List(product_base, ref product_iterator);
                    meal_base = SerializeAction.Load_Meal_List(meal_base, ref meal_iterator);
                    diet_base = SerializeAction.Load_Diet_List(diet_base, ref diet_iterator);
                }
                catch (Exception)
                {
                    Console.WriteLine("Nie istnieje plik z zapisanymi danymi");
                }

            }
        }
    }
}
