using System;
using System.Collections.Generic;
namespace Culculetor
{
    internal class Program
    {
        //Перечисление возможных операций
        enum Operation
        {
            PlusOrMinus = 0,
            MultiplyOrDevide = 1,
            Exponention = 2,
            Logarithm = 3,
            Root = 4
        }
        //Возвращает значение вычисления двух чисел с передаваемой операцией
        static double CalculateTwoNumbers(double number1, double number2, char operation)
        {
            if (operation == '/' && number2 != 0)
            {
                return number1 / number2;
            }
            else if (operation == '*')
            {
                return number1 * number2;
            }
            else if (operation == '+')
            {
                return number1 + number2;
            }
            else if (operation == '-')
            {
                return number1 - number2;
            }
            else if (operation == '^')
            {
                return Math.Pow(number1, number2);
            }
            return 0;
        }
        //Проверяет на правильность расставленных скобок
        static bool CheckBreacket(string expression)
        {
            Stack<char> stackWithBreakets = new Stack<char>();
            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == '(')
                {
                    stackWithBreakets.Push(expression[i]);
                }
                if (expression[i] == ')' && stackWithBreakets.Count > 0)
                {
                    stackWithBreakets.Pop();
                }
                else if (expression[i] == ')' && stackWithBreakets.Count == 0)
                {
                    return false;
                }
            }
            if (stackWithBreakets.Count == 0)
            {
                return true;
            }
            else return false;
        }
        //Преводит строчное выражение, в список с числами и операциями 
        static List<string> ParseStringToList(string expression)
        {
            int posReading = 0;
            List<string> temp = new List<string>();
            int RealLengthAns = expression.Length;
            string tempToNotOutOfRange = "~";
            expression += tempToNotOutOfRange;
            while (true)
            {
                if (posReading >= RealLengthAns)
                {
                    break;
                }
                //
                if ((expression[posReading] == '-') && (expression[posReading - 1] == '(' || expression[posReading - 1] == '*' || expression[posReading - 1] == '/' || expression[posReading - 1] == '+' || expression[posReading - 1] == '-' || expression[posReading - 1] == '^'))
                {
                    string fullNumber = "-";
                    posReading++;
                    while (expression[posReading] >= '0' && expression[posReading] <= '9' || expression[posReading] == '.' || expression[posReading] == ',')
                    {
                        fullNumber += expression[posReading];
                        posReading++;
                        if (posReading >= expression.Length)
                        {
                            break;
                        }
                    }
                    temp.Add(fullNumber.Replace('.', ','));
                }
                //
                else if (expression[posReading] == '(' || expression[posReading] == ')' || expression[posReading] == '*' || expression[posReading] == '/' || expression[posReading] == '+' || expression[posReading] == '-' || expression[posReading] == '^')
                {
                    temp.Add(expression[posReading].ToString());
                    posReading++;
                }
                else if (expression[posReading] >= '0' && expression[posReading] <= '9' || expression[posReading] == '.' || expression[posReading] == ',')
                {
                    string fullNumber = "";
                    while (expression[posReading] >= '0' && expression[posReading] <= '9' || expression[posReading] == '.' || expression[posReading] == ',')
                    {
                        fullNumber += expression[posReading];
                        posReading++;
                        if (posReading >= expression.Length)
                        {
                            break;
                        }
                    }
                    temp.Add(fullNumber.Replace('.', ','));
                }
                else
                {
                    //Чтобы избежать ошибок, список очищается в случае, если появились посторонние символы
                    Console.WriteLine("Выражение записано с посторонними символами!");
                    temp.RemoveRange(0, temp.Count);
                    break;
                }
            }
            return temp;
        }
        //Вычисляет все вхождения какой либо операции
        static List<string> CalculateAllCases(List<string> fullNumber, Operation ModeOfOperation)
        {
            int posReading = 0;
            int countOfPovtorReading = 0;
            double result;
            if (ModeOfOperation == Operation.PlusOrMinus)
            {
                do
                {
                    countOfPovtorReading++;
                    if (countOfPovtorReading >= fullNumber.Count * 3)
                    {
                        break;
                    }
                    if (posReading >= fullNumber.Count)
                    {
                        posReading = 0;
                    }
                    if (fullNumber[posReading] == "+" && fullNumber[posReading - 1] != ")" && fullNumber[posReading + 1] != "(")
                    {
                        result = CalculateTwoNumbers(double.Parse(fullNumber[posReading - 1]), double.Parse(fullNumber[posReading + 1]), char.Parse(fullNumber[posReading]));
                        int posFixation = posReading;
                        fullNumber.RemoveAt(posFixation);
                        fullNumber.RemoveAt(posFixation);
                        fullNumber[posFixation - 1] = result.ToString();
                        countOfPovtorReading = 0;
                        posReading = 0;
                    }
                    if (fullNumber[posReading] == "-" && fullNumber[posReading - 1] != ")" && fullNumber[posReading + 1] != "(")
                    {
                        result = CalculateTwoNumbers(double.Parse(fullNumber[posReading - 1]), double.Parse(fullNumber[posReading + 1]), char.Parse(fullNumber[posReading]));
                        int posFixation = posReading;
                        fullNumber.RemoveAt(posFixation);
                        fullNumber.RemoveAt(posFixation);
                        fullNumber[posFixation - 1] = result.ToString();
                        countOfPovtorReading = 0;
                        posReading = 0;
                    }
                    posReading++;
                } while (true);
            }
            if (ModeOfOperation == Operation.MultiplyOrDevide)
            {
                do
                {
                    countOfPovtorReading++;
                    if (countOfPovtorReading >= fullNumber.Count * 3)
                    {
                        break;
                    }
                    if (posReading >= fullNumber.Count)
                    {
                        posReading = 0;
                    }
                    if (fullNumber[posReading] == "*" && fullNumber[posReading - 1] != ")" && fullNumber[posReading + 1] != "(")
                    {
                        result = CalculateTwoNumbers(double.Parse(fullNumber[posReading - 1]), double.Parse(fullNumber[posReading + 1]), char.Parse(fullNumber[posReading]));
                        int posFixation = posReading;
                        fullNumber.RemoveAt(posFixation);
                        fullNumber.RemoveAt(posFixation);
                        fullNumber[posFixation - 1] = result.ToString();
                        countOfPovtorReading = 0;
                        posReading = 0;
                    }
                    if (fullNumber[posReading] == "/" && fullNumber[posReading - 1] != ")" && fullNumber[posReading + 1] != "(")
                    {
                        result = CalculateTwoNumbers(double.Parse(fullNumber[posReading - 1]), double.Parse(fullNumber[posReading + 1]), char.Parse(fullNumber[posReading]));
                        int posFixation = posReading;
                        fullNumber.RemoveAt(posFixation);
                        fullNumber.RemoveAt(posFixation);
                        fullNumber[posFixation - 1] = result.ToString();
                        countOfPovtorReading = 0;
                        posReading = 0;
                    }
                    posReading++;
                } while (true);
            }
            if (ModeOfOperation == Operation.Exponention)
            {
                do
                {
                    countOfPovtorReading++;
                    if (countOfPovtorReading >= fullNumber.Count * 3)
                    {
                        break;
                    }
                    if (posReading >= fullNumber.Count)
                    {
                        posReading = 0;
                    }
                    if (fullNumber[posReading] == "^" && fullNumber[posReading - 1] != ")" && fullNumber[posReading + 1] != "(")
                    {
                        result = CalculateTwoNumbers(double.Parse(fullNumber[posReading - 1]), double.Parse(fullNumber[posReading + 1]), char.Parse(fullNumber[posReading]));
                        int posFixation = posReading;
                        fullNumber.RemoveAt(posFixation);
                        fullNumber.RemoveAt(posFixation);
                        fullNumber[posFixation - 1] = result.ToString();
                        countOfPovtorReading = 0;
                        posReading = 0;
                    }
                    posReading++;
                } while (true);
            }
            return fullNumber;
        }
        //Удаляет скобки, в котором осталось одно число в результате каких-либо вычислений
        static List<string> RemoveBreacketsWithOneNumberInside(List<string> exprassion)
        {
            int posReading = 1;
            int countOfPovtorReading = 0;
            do
            {
                countOfPovtorReading++;
                if (countOfPovtorReading >= exprassion.Count * 3)
                {
                    break;
                }
                if (posReading > exprassion.Count)
                {
                    posReading = 1;
                }
                if (exprassion[posReading - 1] == "(" && exprassion[posReading + 1] == ")")
                {
                    exprassion.RemoveAt(posReading - 1);
                    exprassion.RemoveAt(posReading);
                }
                posReading++;
            } while (true);
            return exprassion;
        }
        //Удаляет выражение внутри скобок вместе со скобками, в также заменяет на передаваемую строку
        static List<string> RemoveBreacketsAndArifInside(List<string> exprassion, int prevIndexBreaket, int lastIndexBreaket, string forReplacement)
        {
            for (int i = prevIndexBreaket; i < lastIndexBreaket; i++)
            {
                exprassion.RemoveAt(prevIndexBreaket);
            }
            exprassion[prevIndexBreaket] = forReplacement;
            return exprassion;
        }
        //Главное место действий
        static void Main()
        {
            bool calculationCapability = true;
            string arif = Console.ReadLine();
            List<string> expression;
            //Для удобства вычислений программы, всё выражение будет в скобках
            arif = "(" + arif.Replace(" ", "") + ")";
            if (!CheckBreacket(arif))
            {
                Console.WriteLine("Скобки расставлены неверно!");
                calculationCapability = false;
            }
            expression = new List<string>(ParseStringToList(arif));
            foreach (var item in expression)
            {
                Console.Write(item + " ");
            }
            if (calculationCapability && expression.Count >= 3)
            {
                //Если выражение записно не по правилам математики, или содержит посторонние символы
                //Праграмма это предусматривает
                try
                {
                    //Счётчик перечитывания выражения
                    int countOfPovtorReading = 0;
                    //Позиция в списке
                    int posReading = 0;
                    //Индекс открывающейся скобки
                    int indexOpenBreaket = 0;
                    //Индекс закрывающеся скобки
                    int indexCloseBreaket;
                    //Вспомогательная переменная для высчитывания выражения внутри скобок
                    List<string> temp = new List<string>();
                    //Цикл, вычисляющий выражение, пока скобок не останется
                    do
                    {
                        countOfPovtorReading++;
                        //Чтобы вычислить выражение, программа перечитывает его несколько раз
                        if (countOfPovtorReading >= expression.Count * expression.Count)
                        {
                            break;
                        }
                        if (posReading >= expression.Count)
                        {
                            posReading = 0;
                        }
                        if (expression[posReading] == "(")
                        {
                            indexOpenBreaket = posReading;
                        }
                        //Вычисляет выражение внутри "дальних" скбок, и дальше по порядку
                        else if (expression[posReading] == ")" && expression[indexOpenBreaket] == "(")
                        {
                            indexCloseBreaket = posReading;
                            temp = new List<string>();
                            for (int j = indexOpenBreaket; j <= indexCloseBreaket; j++)
                            {
                                temp.Add(expression[j]);
                            }
                            Console.Write("\n1)Temp: ");
                            foreach (var item in temp)
                            {
                                Console.Write(item + "");
                            }
                            temp = new List<string>(CalculateAllCases(temp, Operation.Exponention));
                            temp = new List<string>(CalculateAllCases(temp, Operation.MultiplyOrDevide));
                            temp = new List<string>(CalculateAllCases(temp, Operation.PlusOrMinus));
                            temp = new List<string>(RemoveBreacketsWithOneNumberInside(temp));
                            expression = new List<string>(RemoveBreacketsAndArifInside(expression, indexOpenBreaket, indexCloseBreaket, temp[0]));
                            Console.Write("\n2)Temp: ");
                            foreach (var item in temp)
                            {
                                Console.Write(item + "");
                            }
                            posReading = 0;
                        }
                        posReading++;
                    } while (true);
                    Console.Write("\nans: ");
                    foreach (var item in expression)
                    {
                        Console.Write(item + "");
                    }
                    //Последний вычисленный элемент в temp - это ответ
                    Console.WriteLine("\nОтвет: " + temp[0]);
                }
                //Если программа увидела, что что-то не так
                catch
                {
                    Console.WriteLine("\nВыражение записано с ошибками");
                }
                Console.WriteLine();
            }
            //Различные выражения для теста
            //(12+5*2)*10-(40/10)
            //3*(12,5*6)-10,4/(5-(7-4))
            //10*7-5*(12-4*9)
            //238*25-((575*2+(578/2)))+257*12
            //238*25*2-((575*2^3+(578/2)))+257*9^(1/2)
            //((((6+9)+(7*4))-12)^0,5/2)+15*7+576^0,5*2^2
            Console.ReadLine();
        }
    }
}
//expression = new List<string>(CalculateAllCases(expression, Operation.Exponention));
//expression = new List<string>(CalculateAllCases(expression, Operation.MultiplyOrDevide));
//expression = new List<string>(CalculateAllCases(expression, Operation.PlusOrMinus));
//expression = new List<string>(RemoveBreacketsWithOneNumberInside(expression));
