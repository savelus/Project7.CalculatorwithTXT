using System;
using System.Data;
using System.Globalization;
using System.IO;

namespace Project7.CalculatorwithTXT
{
    class Program
    {
        static double Convert (string numberStr)
        {
            double number;
            bool check = double.TryParse(numberStr, out number);
            if (check)
            {
                return number;
            }
           else
            {
                Console.WriteLine("Вы ввели неправильно числа, проверьте ваш ввод и перезапустите программу");
                return 0;
            }
        }

        static string[] SplitText (string inputData)
        {
            
            string[] symbols = new string[3];
            for (int i = 1; i < inputData.Length - 1; i++)
            {
                if (inputData[i] != ' ' && inputData[i - 1] == ' ' && inputData[i + 1] == ' ')
                {
                    symbols[1] = inputData[i].ToString();
                    symbols[0] = inputData.Substring(0, i);
                    symbols[2] = inputData.Substring(i + 1);
                }
            }
            
            return symbols;
        }

        static string Calculate(double firstNum, double secondNum, string sign)
        {

            if (sign == "*")
            { 
                return (firstNum * secondNum).ToString();
            }
            if (sign == "-")
            {
                return (firstNum - secondNum).ToString(); 
            }
            if (sign == "+")
            {
                return (firstNum + secondNum).ToString();
            }
            if (sign == "/")
            {
                if (secondNum == 0)
                {
                    return "Неверная операция";
                }
                else
                {
                    return (firstNum / secondNum).ToString();
                }
            }
            return "Неверная операция";

        }
        static void Main(string[] args)
        {
            string pathInput = "Input.txt";
            string pathOutput = "Output.txt";
            string inputData = File.ReadAllText(pathInput);
            string[] symbols = SplitText(inputData); 
            double firstNum = Convert(symbols[0]);
            double secondNum = Convert(symbols[2]);
            string sign = symbols[1];
            string outputNum = Calculate(firstNum, secondNum, sign);
            File.WriteAllText(pathOutput, outputNum);
        }
    }
}
