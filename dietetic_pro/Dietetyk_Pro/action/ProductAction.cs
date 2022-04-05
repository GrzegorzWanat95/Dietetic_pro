using System;
using System.Collections.Generic;
using System.Text;

namespace DietetykPro
{
    class ProductAction
    {
        //Tworzenie nowego produktu
        static public void New_Product(List<Product> product_base, ref int product_iterator)
        {
            int choose = 0;
            int product_id = product_iterator;
            Console.Write("Podaj nazwę produktu: ");
            string product_name = Check.Get_String();
            if (Product_Exist(product_base, product_name) == -1)
            {
                Menu.Header();
                Menu.Menu_10();
                choose = Check.Get_Int(1, 7);
                Menu.Header();
                Console.Write("Wprowadź kaloryczność produktu w 100 gramach: ");
                double caloricity = Check.Get_Double(0, double.MaxValue);
                Console.Write("Wprowadź zawartość węglowodanów w 100 gramach: ");
                double carbohydrate = Check.Get_Double(0, double.MaxValue);
                Console.Write("Wprowadź zawartość białka w 100 gramach: ");
                double protein = Check.Get_Double(0, double.MaxValue);
                Console.Write("Wprowadź zawartość tłuszczu w 100 gramach: ");
                double fat = Check.Get_Double(0, double.MaxValue);
                if (choose == 1)
                {
                    Product product = new Vegetable(product_id, product_name, caloricity, carbohydrate, protein, fat);
                    product_base.Add(product);
                    product_iterator++;
                }
                else if (choose == 2)
                {
                    Product product = new Fruit(product_id, product_name, caloricity, carbohydrate, protein, fat);
                    product_base.Add(product);
                    product_iterator++;
                }
                else if (choose == 3)
                {
                    Product product = new Meat(product_id, product_name, caloricity, carbohydrate, protein, fat);
                    product_base.Add(product);
                    product_iterator++;
                }
                else if (choose == 4)
                {
                    Product product = new Dairy(product_id, product_name, caloricity, carbohydrate, protein, fat);
                    product_base.Add(product);
                    product_iterator++;
                }
                else if (choose == 5)
                {
                    Product product = new Grain(product_id, product_name, caloricity, carbohydrate, protein, fat);
                    product_base.Add(product);
                    product_iterator++;
                }
                else if (choose == 6)
                {
                    Product product = new Drink(product_id, product_name, caloricity, carbohydrate, protein, fat);
                    product_base.Add(product);
                    product_iterator++;
                }
                else if (choose == 7)
                {
                    Product product = new Sweet(product_id, product_name, caloricity, carbohydrate, protein, fat);
                    product_base.Add(product);
                    product_iterator++;
                }
            }
            else
            {
                Console.WriteLine("Istnieje produkt o podanej nazwie.");
            }
        }

        //Sprawdzenie czy dany produkt istnieje w bazie
        static public int Product_Exist(List<Product> product_base, string name)
        {
            int iterator = 0;
            foreach (var item in product_base)
            {
                if(item.Product_name == name)
                {
                    return iterator;
                }
                iterator++;
            }
            return -1;
        }

        //Edycja danych produktu
        static public void Edit_Product(List<Product> product_base)
        {
            Console.WriteLine("Wprowadź nazwę produktu:");
            string name = Check.Get_String();
            Console.Clear();
            int ID = Product_Exist(product_base, name);
            if (ID != -1)
            {
                Console.WriteLine("Edycja danych produktu: {0}", product_base[ID].Product_name);
                Menu.Menu_6();
                int choose = Check.Get_Int(0, 4);
                switch (choose)
                {
                    case 1://Zmiana kaloryczności
                        Console.WriteLine("Wprowadź aktualną kaloryczność:"); product_base[ID].Caloricity = Check.Get_Double(0, double.MaxValue);
                        break;
                    case 2://Zmiana zawartości węglowodanów
                        Console.WriteLine("Wprowadź aktualną zawartość węglowodanów"); product_base[ID].Carbohydrate = Check.Get_Double(0, double.MaxValue);
                        break;
                    case 3://Zmiana zawartości białka
                        Console.WriteLine("Wprowadź aktualną zawartość białka:"); product_base[ID].Protein = Check.Get_Double(0, double.MaxValue);
                        break;
                    case 4://Zmiana zawartości tłuszczu
                        Console.WriteLine("Wprowadź aktualną zawartość tłuszczu:"); product_base[ID].Fat = Check.Get_Double(0, double.MaxValue);
                        break;
                    case 0://Powrót do menu
                        Menu.Header();
                        break;
                }
            }
            else
            {
                Console.WriteLine("Produkt o podanych danych nie istnieje.");
            }
        }

        //Wyświetlenie danych produktu
        static public void Print_Product(List<Product> product_base)
        {
            bool find = false;
            Console.WriteLine("Wprowadź nazwę produktu:");
            string name = Check.Get_String();
            Console.Clear();
            foreach (var item in product_base)
            {
                if(item.Product_name == name)
                {
                    item.Print_Product();
                    find = true;
                }
            }
            if (find != true) { Console.WriteLine("W bazie nie istnieje produkt o podanej nazwie"); }
            Console.WriteLine();
        }

        //Funkcja wyświetlająca wszystkie produkty z aktualnej bazy działającego programu
        static public void Return_Product_Base(List<Product> product_base)
        {
            int i = 1;//iterator
            foreach (var product in product_base)
            {
                Console.WriteLine("{0}. {1}", i, product.Product_name);
                i++;
            }
        }

        //Usuwanie produktu z bazy
        static public void Remove_Product(List<Product> product_base)
        {
            Console.WriteLine("Wprowadź nazwę produktu, który chcesz usunąć:");
            string name = Check.Get_String();
            int ID = Product_Exist(product_base, name);
            if (ID != -1)
            {
                Console.WriteLine("Usunięto produkt {0}", product_base[ID].Product_name);
                Console.ReadKey();
                product_base.Remove(product_base[ID]);
            }
            else
            {
                Console.WriteLine("Nie istnieje produkt o podanej nazwie");
            }

        }
    }
}
