/*Используя Visual Studio, создайте проект по шаблону Console Application.  
Создайте анонимный метод, который принимает в качестве аргумента массив делегатов и возвращает среднее арифметическое возвращаемых значений методов сообщенных с делегатами в массиве. 
Методы, сообщенные с делегатами из массива, возвращают случайное значение типа int. 
*/
using System;

namespace Task3
{
    class Program
    {
        delegate int MyDelegateMas(MyDelegate[] myDel);
        delegate int MyDelegate();

        static void Main(string[] args)
        {
            MyDelegate[] myDel;
            MyDelegateMas myDelMas;
            int amountOfElement;

            Console.Write("Количество элементов: ");
            amountOfElement = Int32.Parse(Console.ReadLine());

            myDel = new MyDelegate[amountOfElement];
            int result = 0;

            for (int i = 0; i < myDel.Length; i++)
            {                
                myDel[i] = () => ReturnRandomIntDigit();
            }

            myDelMas = myDel =>
            {
                for (int i = 0; i < myDel.Length; i++)
                {
                    result = myDel[i]();
                }
                return result / myDel.Length;
            };

            int ReturnRandomIntDigit()
            {
                return new Random().Next(200);
            }

            Console.ReadKey();
        }
    }
}
