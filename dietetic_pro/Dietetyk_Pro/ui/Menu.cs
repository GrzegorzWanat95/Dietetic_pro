using System;
using System.Collections.Generic;
using System.Text;

namespace DietetykPro
{
    class Menu
    {
        public static void Header()
        {
            Console.Clear();
            Console.WriteLine("- DietetykPro 2021 -");
            Console.WriteLine();
        }

        //Menu główne programu. 
        public static void Menu_0()
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Pacjenci");
            Console.WriteLine("2. Produkty");
            Console.WriteLine("3. Posiłki");
            Console.WriteLine("4. Bazy");
            Console.WriteLine("0. Wyjdź z programu");
            Console.WriteLine("Wprowadź wartość aby wybrać opcję:");
        }

        public static void Menu_Patient()
        {
            Console.WriteLine("1. Dodaj pacjenta");
            Console.WriteLine("2. Zmień dane pacjenta");
            Console.WriteLine("3. Wyświetl dane pacjenta");
            Console.WriteLine("4. Wykonaj obliczenia");
            Console.WriteLine("5. Stwórz jadłospis");
            Console.WriteLine("6. Wyświetl jadłospisy pacjenta");
            Console.WriteLine("7. Usuń pacjenta i jego jadłospisy");
            Console.WriteLine("0. Powrót do menu głównego");
            Console.WriteLine("Wprowadź wartość aby wybrać opcję:");

        }

        public static void Menu_Patient_Sex()
        {
            Console.WriteLine("Podaj płeć pacjenta:");
            Console.WriteLine("1 Kobieta");
            Console.WriteLine("2 Mężczyzna");
            Console.Write("Wprowadź wartość: ");
        }

        public static void Adding_Patient()
        {
            Header();
            Console.WriteLine("Dodawanie pacjenta:");
        }

        public static void Calculate_Patient(string msg)
        {
            Header();
            Console.WriteLine("Obliczenia dla pacjenta: {0}", msg);
        }

        public static void Menu_Product()
        {
            Console.WriteLine("1. Dodaj produkt");
            Console.WriteLine("2. Zmień dane produktu");
            Console.WriteLine("3. Wyświetl dane produktu");
            Console.WriteLine("4. Usuń produkt");
            Console.WriteLine("0. Powrót do menu głównego");
            Console.WriteLine("Wprowadź wartość aby wybrać opcję:");

        }

        public static void Menu_Meal()
        {
            Console.WriteLine("1. Dodaj posiłek:");
            Console.WriteLine("2. Zmień dane posiłku:");
            Console.WriteLine("3. Wyświetl dane posiłku:");
            Console.WriteLine("4. Usuń posiłek");
            Console.WriteLine("0. Powrót do menu głównego");
        }

        public static void Menu_Base()
        {
            Console.WriteLine("1. Wyświetl listę pacjentów");
            Console.WriteLine("2. Wyświetl listę produktów");
            Console.WriteLine("3. Wyświetl listę posiłków");
            Console.WriteLine("0. Powrót do menu głównego");
            Console.WriteLine("Wprowadź wartość aby wybrać opcję:");
        }

        public static void Menu_2()
        {
            Console.WriteLine("1. Oblicz BMI");
            Console.WriteLine("2. Oblicz prawidłową masę ciała");
            Console.WriteLine("3. Oblicz podstawową przemianę materii");
            Console.WriteLine("4. Oblicz sugerowaną kaloryczność");
            Console.WriteLine("5. Oblicz sugerowaną kaloryczność posiłków");
            Console.WriteLine("6. Wygeneruj raport stanu zdrowia pacjenta");
            Console.WriteLine("0. Powrót do menu głównego");
        }

        public static void Menu_3()
        {
            Console.WriteLine("1. - brak aktywności fizycznej np. osoba obłożnie chora");
            Console.WriteLine("2. - umiarkowana aktywność fizyczna do 140 minut lub intensywna do 100 minut tygodniowo");
            Console.WriteLine("3. - umiarkowana aktywność fizyczna do 280 minut lub intensywna do 200 minut tygodniowo");
            Console.WriteLine("4. - umirakowana aktywność fizyczna do 420 minut lub intensywna do 300 minut tygodniowo");
            Console.WriteLine("5. - umiarkowana aktywność fizyczna do 560 minut lub intensywna do 400 minut tygodniowo");
        }

        public static void Menu_4()
        {
            Console.WriteLine("1 Kobieta");
            Console.WriteLine("2 Mężczyzna");
        }

        public static void Menu_5()
        {
            Console.WriteLine("1. Zmień wagę pacjetna:");
            Console.WriteLine("2. Zmień wzrost pacjenta:");
            Console.WriteLine("3. Zmień poziom aktywności fizycznej pacjenta:");
            Console.WriteLine("0. Powrót do menu głównego");
        }

        public static void Menu_6()
        {
            Console.WriteLine("1. Zmień kaloryczność produktu:");
            Console.WriteLine("2. Zmień zawartość węglowodanów:");
            Console.WriteLine("3. Zmień zawartość białka:");
            Console.WriteLine("4. Zmień zawartość tłuszczu:");
            Console.WriteLine("0. Powrót do menu głównego");
        }
        public static void Menu_7()
        {
            Console.WriteLine("Czy chcesz dodać kolejny produkt?");
            Console.WriteLine("1. Tak");
            Console.WriteLine("2. Nie");
        }

        public static void Menu_8()
        {
            Console.WriteLine("Czy chcesz dodać kolejny produkt lub danie?");
            Console.WriteLine("1. Tak");
            Console.WriteLine("2. Nie");
        }

        public static void Menu_9a()
        {
            Console.WriteLine("1. Śniadanie");
            Console.WriteLine("2. Obiad");
            Console.WriteLine("3. Kolacja");
            Console.WriteLine("0. Powrót");
        }

        public static void Menu_9b()
        {
            Console.WriteLine("1. Śniadanie");
            Console.WriteLine("2. Drugie śniadanie");
            Console.WriteLine("3. Obiad");
            Console.WriteLine("4. Kolacja");
            Console.WriteLine("0. Powrót");
        }
        public static void Menu_9c()
        {
            Console.WriteLine("1. Śniadanie");
            Console.WriteLine("2. Drugie śniadanie");
            Console.WriteLine("3. Obiad");
            Console.WriteLine("4. Podwieczorek");
            Console.WriteLine("5. Kolacja");
            Console.WriteLine("0. Powrót");
        }

        public static void Menu_10()
        {
            Console.WriteLine("Podaj typ produktu:");
            Console.WriteLine("1. Warzywa");
            Console.WriteLine("2. Owoce");
            Console.WriteLine("3. Mięso");
            Console.WriteLine("4. Nabiał");
            Console.WriteLine("5. Produkty zbożowe");
            Console.WriteLine("6. Napoje");
            Console.WriteLine("7. Słodycze");
        }

        public static void Menu_11()
        {
            Console.WriteLine("Wybierz:");
            Console.WriteLine("1. Usuń wybrany produkt");
            Console.WriteLine("2. Zmień wagę produktu");
            Console.WriteLine("0. Zakończ zmiany");
        }

        public static void Menu_12()
        {
            Console.WriteLine("Wprowadź liczbę posiłków:");
            Console.WriteLine("1. 3 posiłki");
            Console.WriteLine("2. 4. posiłki");
            Console.WriteLine("3. 5 posiłków");
        }
        public static void Menu_13()
        {
            Console.WriteLine("Wybierz typ diety:");
            Console.WriteLine("1. Ogólna");
            Console.WriteLine("2. Bez laktozy");
            Console.WriteLine("3. Bezglutenowa");
            Console.WriteLine("4. Wegetariańska");
            Console.WriteLine("5. Cukrzycowa");
        }

        public static void Menu_14()
        {
            Console.WriteLine();
            Console.WriteLine("Wybierz:");
            Console.WriteLine("1. Dodaj posiłek do jadłospisu");
            Console.WriteLine("2. Usuń wybrany posiłek z jadłospisu");
            Console.WriteLine("3. Wyświetl składniki dań");
            Console.WriteLine("4. Wyświetl bazę posiłków");
            Console.WriteLine("0. Wyjdź");
        }

        public static void Back()
        {
            Console.WriteLine("Naciśnij przycisk, by wrócić do menu");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
