/*Используя Visual Studio, создайте проект по шаблону Console Application.  
Создайте анонимный метод, который принимает в качестве аргумента массив делегатов и возвращает среднее арифметическое возвращаемых значений методов сообщенных с делегатами в массиве. 
Методы, сообщенные с делегатами из массива, возвращают случайное значение типа int. 
*/
using System;

namespace Task3
{
    class Program
    {
        delegate string MyDelegateMas(MyDelegate[] myDel);
        delegate int MyDelegate();

        static void Main(string[] args)
        {
            MyDelegate[] myDel;
            MyDelegateMas myDelMas;
            int amountOfElement = 0, result = 0;

            Console.Write("Количество элементов: ");
            amountOfElement = Int32.Parse(Console.ReadLine());

            myDel = new MyDelegate[amountOfElement];

            for (int i = 0; i < myDel.Length; i++)
            {
                myDel[i] = () => ReturnRandomIntDigit();
            }

            myDelMas = myDel =>
            {
                int temporaryVariable = 0;
                for (int i = 0; i < myDel.Length; i++)
                {
                    temporaryVariable = 0;
                    temporaryVariable = myDel[i]();                

                    if (i == 0) Console.Write($"({temporaryVariable} + ");

                    else if (i == myDel.Length - 1) Console.Write($"{temporaryVariable}) / {myDel.Length} = ");

                    else Console.Write($"{temporaryVariable} + ");

                    result += temporaryVariable;
                }
                return $"{result / myDel.Length}.{result%myDel.Length}";
            };

            Console.Write($"{myDelMas(myDel)}");
            Console.ReadKey();

            int ReturnRandomIntDigit()
            {
                return new Random().Next(200);
            }
        }
    }
}
