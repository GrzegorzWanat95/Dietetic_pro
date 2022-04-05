using System;
using System.Collections.Generic;
using System.Text;

namespace DietetykPro
{
    static class Check
    {
        public static string Get_String()
        {
            string result;
            while (true)
            {
                result = Console.ReadLine();
                if (!string.IsNullOrEmpty(result))
                {
                    break;
                }
                Console.WriteLine("Wartość nie może być pusta.");
                Console.ReadKey();
            }
            return result;
        }

        public static int Get_Int(int lower, int upper)
        {
            bool check = false;
            int result=0;
            while (check != true)
            {
                check = int.TryParse(Console.ReadLine(), out result);
                if ((result < lower || result > upper) || (check == false))
                {
                    check = false;
                    Console.WriteLine("Wprowadzono błędną wartość.");
                }
                else
                {
                    break;
                }

            }
            return result;
        }

        public static long Get_Long(long lower, long upper)
        {
            bool check = false;
            long result = 0;
            while (check != true)
            {
                check = long.TryParse(Console.ReadLine(), out result);
                if ((result < lower || result > upper))
                {
                    check = false;
                    Console.WriteLine("Wprowadzono błędną wartość.");
                }
                else
                {
                    break;
                }

            }
            return result;
        }

        public static double Get_Double(double lower, double upper)
        {
            bool check = false;
            double result = 0;
            while (check != true)
            {
                check = double.TryParse(Console.ReadLine(), out result);
                if ((result < lower || result > upper))
                {
                    check = false;
                    Console.WriteLine("Wprowadzono błędną wartość.");
                }
                else
                {
                    break;
                }

            }
            return result;
        }
    }
}
