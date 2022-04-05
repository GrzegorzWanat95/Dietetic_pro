using DietetykPro.serialization;
using DietetykPro.serialization.impl;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;

namespace DietetykPro
{
    static class SerializeAction
    {
        public static void Save_Patient_List(List<Patient>patient_base)
        {
            List<Patient> patient = patient_base;
            XmlSerializer xmlSer = new XmlSerializer(typeof(List<Patient>));
            using (Stream fstr = new FileStream(@"./datafiles/patient.xml", FileMode.Create, FileAccess.Write))
            //Dla pewności likalizacji mozna podać pełną lokalizacje pliku np. @"C:datafiles/patient.xml" jednak należy wtedy utworzyć w podanej loklalizacji folder datafiles
            {
                xmlSer.Serialize(fstr, patient);
            }
        }
        public static void Save_Product_List(List<Product>product_base)
        {
            List<Product> product = product_base;
            XmlSerializer xmlSer = new XmlSerializer(typeof(List<Product>), new Type[] { typeof(Vegetable), typeof(Fruit), typeof(Meat), typeof(Dairy), typeof(Grain), typeof(Drink), typeof(Sweet) }
);
            using (Stream fstr = new FileStream(@"./datafiles/product.xml", FileMode.Create, FileAccess.Write))
            {
                xmlSer.Serialize(fstr, product);
            }
        }
        public static void Save_MealList(List<Meal> meal_base)
        {
            List<Meal> meal = meal_base;
            XmlSerializer xmlSer = new XmlSerializer(typeof(List<Meal>), new Type[] { typeof(Vegetable), typeof(Fruit), typeof(Meat), typeof(Dairy), typeof(Grain), typeof(Drink), typeof(Sweet) });
            using (Stream fstr = new FileStream(@"./datafiles/meal.xml", FileMode.Create, FileAccess.Write))
            {
                xmlSer.Serialize(fstr, meal);
            }
        }
        public static void Save_Diet_List(List<Diet> diet_base)
        {
            List<Diet> diet = diet_base;
            XmlSerializer xmlSer = new XmlSerializer(typeof(List<Diet>), new Type[] { typeof(CommonDiet), typeof(DiabeticDiet), typeof(GlutenFreeDiet), typeof(LactoseFreeDiet), typeof(WegeDiet), typeof(Vegetable), typeof(Fruit), typeof(Meat), typeof(Dairy), typeof(Grain), typeof(Drink), typeof(Sweet) });
            using (Stream fstr = new FileStream(@"./datafiles/diet.xml", FileMode.Create, FileAccess.Write))
            {
                xmlSer.Serialize(fstr, diet);
            }
        }

        public static List<Patient> Load_Patient_List(List<Patient>patient_base, ref int patient_iterator)
        {
            List<Patient> patient = patient_base;
            XmlSerializer xmlSer = new XmlSerializer(typeof(List<Patient>));
            using (Stream fstr = new FileStream(@"./datafiles/patient.xml", FileMode.Open, FileAccess.Read))
            {
                patient = (List<Patient>)xmlSer.Deserialize(fstr);
                patient_base = patient;
                patient_iterator = 0;
                foreach (var item in patient_base)
                {
                    if (item.ID > patient_iterator)
                    {
                        patient_iterator = item.ID;
                    }
                }
                patient_iterator++;
                return patient_base;
            }
        }
        public static List<Product> Load_Product_List(List<Product>product_base, ref int product_iterator)
        {
            List<Product> product = product_base;
            XmlSerializer xmlSer = new XmlSerializer(typeof(List<Product>), new Type[] { typeof(Vegetable), typeof(Fruit), typeof(Meat), typeof(Dairy), typeof(Grain), typeof(Drink), typeof(Sweet) }
            );
            using (Stream fstr = new FileStream(@"./datafiles/product.xml", FileMode.Open, FileAccess.Read))
            {
                product = (List<Product>)xmlSer.Deserialize(fstr);
                product_base = product;
                product_iterator = 0;
                foreach (var item in product_base)
                {
                    if (item.Product_id > product_iterator)
                    {
                        product_iterator = item.Product_id;
                    }
                }
                product_iterator++;
                return product_base;
            }
        }
        public static List<Meal> Load_Meal_List(List<Meal>meal_base, ref int meal_iterator)
        {
            List<Meal> meal = meal_base;
            XmlSerializer xmlSer = new XmlSerializer(typeof(List<Meal>), new Type[] { typeof(Vegetable), typeof(Fruit), typeof(Meat), typeof(Dairy), typeof(Grain), typeof(Drink), typeof(Sweet) });
            using (Stream fstr = new FileStream(@"./datafiles/meal.xml", FileMode.Open, FileAccess.Read))
            {
                meal = (List<Meal>)xmlSer.Deserialize(fstr);
                meal_base = meal;
                meal_iterator = 0;
                foreach (var item in meal_base)
                {
                    if (item.Meal_id > meal_iterator)
                    {
                        meal_iterator = item.Meal_id;
                    }
                }
                meal_iterator++;
                return meal_base;
            }
        }
        public static List<Diet> Load_Diet_List(List<Diet>diet_base, ref int diet_iterator)
        {
            List<Diet> diet = diet_base;
            XmlSerializer xmlSer = new XmlSerializer(typeof(List<Diet>), new Type[] { typeof(CommonDiet), typeof(DiabeticDiet), typeof(GlutenFreeDiet), typeof(LactoseFreeDiet), typeof(WegeDiet), typeof(Vegetable), typeof(Fruit), typeof(Meat), typeof(Dairy), typeof(Grain), typeof(Drink), typeof(Sweet) });
            using (Stream fstr = new FileStream(@"./datafiles/diet.xml", FileMode.Open, FileAccess.Read))
            {
                diet = (List<Diet>)xmlSer.Deserialize(fstr);
                diet_base = diet;
                diet_iterator = diet_base.Count;
                return diet_base;
            }
        }
    }
}
