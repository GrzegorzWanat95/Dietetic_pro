using System;
using System.Collections.Generic;
using System.Text;

namespace DietetykPro
{
    static class PatientAction
    {
        //Tworzenie pacjenta.
        static public void New_Patient(ref int patient_iterator, List<Patient>patient_base)
        {
            int _ID_number = patient_iterator;
            int _current_date = DateTime.Now.Year;
            Menu.Adding_Patient();
            Console.Write("Podaj imię i nazwisko pacjenta: ");
            string _full_name = Check.Get_String();
            Menu.Adding_Patient();
            Menu.Menu_Patient_Sex();
            int _sex = Check.Get_Int(1, 2);
            Menu.Adding_Patient();
            Console.Write("Wprowadź rok urodzenia pacjenta: ");
            int _year = Check.Get_Int(_current_date - 100, _current_date);
            Menu.Adding_Patient();
            Console.Write("Wprowadź numer PESEL pacjenta:");
            long _PESEL = Check.Get_Long(10000000000, 99999999999);
            Menu.Adding_Patient();
            Console.Write("Wprowadź wagę pacjenta w kilogramach: ");
            double _weight = Check.Get_Double(70, 220);
            Menu.Adding_Patient();
            Console.Write("Wprowadź wzrost pacjenta w centymetrach: ");
            double _height = Check.Get_Double(30, 300);
            Menu.Adding_Patient();
            Menu.Menu_3();
            Console.Write("Wprowadź poziom aktywności fizycznej pacjenta: ");
            double _activity = Activity(Check.Get_Int(1, 5));
            bool check = Eliminate_Duplicate(patient_base, _PESEL);
            if(check == false)
            {
                Patient patient = new Patient(_ID_number, _current_date, _year, _PESEL, _full_name, _weight, _height, _activity, _sex);
                patient_base.Add(patient);
                Console.Clear();
                Menu.Header();
                Console.WriteLine("Pomyślnie dodano pacjenta o numerze ID {0}", patient_iterator);
                patient_iterator++;
            }
            else
            {
                Console.Clear();
                Menu.Header();
                Console.WriteLine("Pacjent o wprowadzonych danych istnieje w bazie. Nie dodano pacjenta");
            }

        }

        //Edycja danych pacjenta
        static public void Edit_Patient(List<Patient> patient_base, int patient_iterator, int current_date)
        {
            Menu.Header();
            int ID = Get_Patient(patient_base, patient_iterator);
            int choose = 0;
            if (ID < patient_iterator)
            {
                foreach (var patient in patient_base)
                {
                    if (patient.Name == patient_base[ID].Name)
                    {
                        Menu.Header();
                        Console.WriteLine("Edycja danych pacjenta: {0}", patient_base[ID].Name);
                        Menu.Menu_5();
                        choose = Check.Get_Int(0, 3);
                        switch (choose)
                        {
                            case 1://Zmiana wagi
                                Menu.Header();
                                Console.Write("Wprowadź aktualną wagę [kg]: "); patient_base[ID].Weight = Check.Get_Double(70, 220);
                                break;
                            case 2://Zmiana wzrostu
                                Menu.Header();
                                Console.Write("Wprowadź aktualny wzrost [cm]: "); patient_base[ID].Height = Check.Get_Double(30, 300);
                                break;
                            case 3://Zmiana poziomu aktywności
                                Menu.Header();
                                Menu.Menu_3();
                                Console.Write("Wprowadź aktualny poziom aktywności fizycznej: "); patient_base[ID].Activity = Activity(Check.Get_Int(1, 5));
                                break;
                            case 0:
                                Menu.Header();
                                Console.WriteLine("Powrót do menu");
                                break;
                        }
                    }
                }
                if (choose != 0)
                {
                    Menu.Header();
                    Console.WriteLine("Zaktualizowane dane pacjenta:");
                    patient_base[ID].Print_Patient();
                }
            }
            else
            {
                Menu.Header();
                Console.WriteLine("W bazie nie istnieje pacjent o podanym numerze ID");
            }
        }

        //Funkcja zarządzająca obliczeniami. 
        static public void Calculate_Patient(List<Patient> patient_base, int patient_iterator)
        {
            Menu.Header();
            int ID = Get_Patient(patient_base, patient_iterator);
            if (ID < patient_base.Count)
            {
                Menu.Header();
                Menu.Calculate_Patient(patient_base[ID].Name);
                bool cont = true;
                while (cont != false)
                {
                    Menu.Header();
                    Menu.Menu_2();
                    int choose = Check.Get_Int(0, 6);
                    switch (choose)
                    {
                        case 1://Oblicz BMI
                            Print_BMI(ID, patient_base);
                            break;
                        case 2://Oblicz prawidłową masę ciała
                            Print_Ideal_W(ID, patient_base);
                            break;
                        case 3://Oblicz podstawową przemianę materii
                            Print_B_C(ID, patient_base);
                            break;
                        case 4://Oblicz sugerowaną kaloryczność 
                            Print_Suggested_C(ID, patient_base);
                            break;
                        case 5://Oblicz sugerowaną kalorycznośc posiłku
                            Print_Suggested_Meal_C(ID, patient_base);
                            break;
                        case 6://Wygenerowanie raportu na temat stanu zdrowia pacjenta
                            Print_Report(ID, patient_base);
                            break;
                        case 0://Powrót do menu
                            Console.Clear();
                            cont = false;
                            break;
                    }
                }
                Console.Clear();
            }
        }

        //Deklaracja aktywności fizycznej pacjenta
        static double Activity(int value)
        {
            if (value == 1) { return 1.2; }
            if (value == 2) { return 1.25; }
            if (value == 3) { return 1.5; }
            if (value == 4) { return 1.75; }
            if (value == 5) { return 2.0; }
            return 0;
        }

        //Sprawdzenie czy pacjent o podanych danych nie istnieje już w bazie
        static public bool Eliminate_Duplicate(List<Patient> patient_base, long PESEL)
        {
            foreach (var patient in patient_base)
            {
                if(patient.Pesel == PESEL)
                {
                    return true;
                }
            }
            return false;
        }


        //Wyświetlenie danych pacjenta
        static public void Print_Patient(List<Patient> patient_base, int patient_iterator)
        {
            Menu.Header();
            bool find = false;
            int ID = Get_Patient(patient_base, patient_iterator);
            Menu.Header();
            foreach (var patient in patient_base)
            {
                if (ID == patient.ID)
                {
                    patient.Print_Patient();
                    find = true;
                }
            }
            if (find == false)
            {
                Menu.Header();
                Console.WriteLine("Pacjent o podanych danych nie istnieje.");
            }
        }

        static public int Get_Patient(List<Patient> patient_base, int patient_iterator)
        {
            Console.WriteLine("Wprowadź numer ID pacjenta:");
            int patient_id = Check.Get_Int(0, patient_iterator);
            Console.Clear();
            return patient_id;
        }

        //Funkcja usuwajaca pacjenta z bazy
        static public void Remove_Patient(List<Patient> patient_base, ref List<Diet>diet_base, int patient_iterator)
        {
            try
            {
                int ID = Get_Patient(patient_base, patient_iterator);
                DietAction.Remove_Diet(ref diet_base, ID);
                foreach (var patient in patient_base)
                {
                    if(ID == patient.ID)
                    {
                        Console.WriteLine("Usunięto pacjenta {0}", patient.Name);
                        Console.ReadKey();
                        patient_base.Remove(patient);
                        break;
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Nie istnieje pacjent o podanym numerze ID");
                Console.ReadKey();
            }
        }

        //Funkcja wyświetlająca wszystkich pacjentów z aktualnej bazy działającego programu
        static public void Return_Patient_Base(List<Patient> patient_base)
        {
            Console.WriteLine("ID:\tDane:");
            foreach (var patient in patient_base)
            {
                Console.WriteLine("{0}.\t{1}", patient.ID, patient.Name);
            }
        }

        //Funkcje pomocnicze do wyświetlania obliczeń
        static public void Print_BMI(int ID, List<Patient> patient_base)
        {
            Menu.Calculate_Patient(patient_base[ID].Name);
            double BMI = patient_base[ID].Return_Bmi();
            Console.Write("BMI pacjenta wynosi: {0} ", BMI);
            Calculate.BMI_Interpretation(BMI);
            Console.ReadKey();
            Console.Clear();
        }

        static public void Print_Ideal_W(int ID, List<Patient> patient_base)
        {
            Menu.Calculate_Patient(patient_base[ID].Name);
            Console.Write("Prawidłowa masa ciała pacjenta wynosi: {0} kg", patient_base[ID].Return_Ideal_Weight());
            Console.ReadKey();
            Console.Clear();
        }

        static public void Print_B_C(int ID, List<Patient> patient_base)
        {
            Menu.Calculate_Patient(patient_base[ID].Name);
            Console.Write("Podstawowa przemiana dla pacjenta to {0} kcal", patient_base[ID].Return_Bmr());
            Console.ReadKey();
            Console.Clear();
        }

        static public void Print_Suggested_C(int ID, List<Patient> patient_base)
        {
            Menu.Calculate_Patient(patient_base[ID].Name);
            double caloricity = patient_base[ID].Return_Sugested_Caloricity();
            Console.WriteLine("Sugerowana kaloryczność dla pacjenta wynosi: {0} kcal", caloricity);
            Console.ReadKey();
            Console.Clear();
        }

        static public void Print_Suggested_Meal_C(int ID, List<Patient> patient_base)
        {
            Menu.Calculate_Patient(patient_base[ID].Name);
            patient_base[ID].Return_Caloricity_Meal();
            Console.ReadKey();
            Console.Clear();
        }

        static public void Print_Report(int ID, List<Patient> patient_base)
        {
            Menu.Calculate_Patient(patient_base[ID].Name);
            patient_base[ID].Return_Report();
            Console.ReadKey();
            Console.Clear();
        }


    }
}
