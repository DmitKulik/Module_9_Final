using System.ComponentModel;

namespace Task1{
    internal class Program{

        static void Main(string[] args){

            try{
                // Инициализация массива исключений _sixexceptions с различными типами исключений
                Exception[] _sixexceptions = { new DivideByZeroException(), new FormatException(), new OutOfMemoryException(), new NullReferenceException(), new RankException(), new MyException("test") };

                // Вывод на консоль строки "Exception"
                Console.WriteLine("RandomException");
                var Random = new Random();

                // Генерация случайного исключения по индексу в массиве
                throw _sixexceptions[Random.Next(0, 6)];
            }

            // Обработка исключений по типу
            catch (DivideByZeroException _ex) { Console.WriteLine(_ex.GetType()); }
            catch (FormatException _ex) { Console.WriteLine(_ex.GetType()); }
            catch (OutOfMemoryException _ex) { Console.WriteLine(_ex.GetType()); }
            catch (StackOverflowException _ex) { Console.WriteLine(_ex.GetType()); }
            catch (NullReferenceException _ex) { Console.WriteLine(_ex.GetType()); }
            catch (RankException _ex) { Console.WriteLine(_ex.GetType()); }
            catch (MyException) { Console.WriteLine("Test"); }
        }
    }
    // Класс MyException, производный от класса Exception
    public class MyException : Exception{
        // Конструктор класса с параметром _message типа string
        public MyException(string _message) : base(_message) { }
    }
}




