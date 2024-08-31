using System;
using System.Globalization;

namespace ConsoleParse
{
   internal class Program
   {
      static void Main()
      {
         string inputString = "777";
         ParseMethods(inputString);
         ParseMethods(null);
         ConvertMethods(inputString);
         ConvertMethods(null);
         TryParseMethod(inputString);
         TryParseMethod(null);
         Console.ReadKey();
      }

      private static void ParseMethods(string inputString)
      {
         int a = int.Parse("10");
         double b = double.Parse("23,56");
         decimal c = decimal.Parse("12,45");
         byte d = byte.Parse("4");
         Console.WriteLine($"a={a}  b={b}  c={c}  d={d}");

         // Чтобы не зависеть от культурных различий устанавливаем четкий формат
         // с помощью класса NumberFormatInfo и его свойства NumberDecimalSeparator
         IFormatProvider formatter = new NumberFormatInfo { NumberDecimalSeparator = "." };
         double number = double.Parse("23.56", formatter);
         Console.WriteLine(number);

         try
         {
            int outputInteger = int.Parse(inputString);
            Console.WriteLine(outputInteger);
         }
         catch (ArgumentNullException)
         {
            Console.WriteLine("Метод int.Parse() выдает исключение ArgumentNullException");
         }
      }

      public static void ConvertMethods(string inputString)
      {
         int n = Convert.ToInt32("23");
         double d = Convert.ToDouble(true);
         Console.WriteLine($"n={n}  d={d}");

         int outputInteger = Convert.ToInt32(inputString);
         Console.WriteLine(outputInteger);
      }

      public static void TryParseMethod(string inputString)
      {
         if (int.TryParse(inputString, out int outputInteger))
            Console.WriteLine($"Выходное значение: {outputInteger}");
         else
            Console.WriteLine("Преобразование завершилось неудачей");

         Console.WriteLine("Введите строку:");
         string input = Console.ReadLine();
         bool result = int.TryParse(input, out int number);
         if (result)
            Console.WriteLine($"Преобразование прошло успешно. Число: {number}");
         else
            Console.WriteLine("Преобразование завершилось неудачно");
      }
   }
}