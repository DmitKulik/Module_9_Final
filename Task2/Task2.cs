namespace Task2 {
    internal class Program {
        static void Main(string[] args) {

            // Создаем список строк для сортировки
            List<string> _names = new List<string>() {
                "Ворчун",
                "Весельчак",
                "Соня",
                "Скромник",
                "Чихуня",
                "Простачек",
                "Умник" };

            // Создаем экземпляр класса SortEvent, который содержит событие SortEventForThisClass типа SortDelegate
            var _sortEventClass = new SortEvent();

            while (true) {

                try{
                    // Запрашиваем у пользователя вариант сортировки
                    Console.WriteLine("Ваш вариант сортировки? 1 или 2 ?");
                    if (!int.TryParse(Console.ReadLine(), out int i) || (i != 1 && i != 2)) {

                        // Если введеное число не равно 1 или 2, исключение
                        throw new Exception("Есть только два варианта 1 или 2");
                    } 
                    else {
                        // Если число равно 1, добавляем метод SortAsc в список обработчиков события SortEventForThisClass
                        // Если число - 2, добавляем метод SortDec
                        if (i == 1){
                            _sortEventClass.SortEventForThisClass += _sortEventClass.SortAsc;
                        }

                        else{_sortEventClass.SortEventForThisClass += _sortEventClass.SortDec;}

                        // Вызываем метод SortEventMethod на экземпляре класса SortEvent, передавая список строк _namesList
                        // Это вызывает событие SortEventForThisClass, которое запускает список обработчиков события, содержащий методы SortAsc или SortDesc
                        _sortEventClass.SortEventMethod(_names);

                        // Вывод отсортированного списка на консоль
                        foreach (var _name in _names) { Console.WriteLine(_name); }

                        break;
                    }
                }
                // Если пользователь ввел символ вместо цифры, генерируем исключение и выводим сообщение об этом
                catch (FormatException){Console.WriteLine("Некорректное значение."); }
                // Если пользователь ввел число, отличное от 1 или 2, генерируем исключение и выводим сообщение об этом
                catch (Exception ex) { Console.WriteLine(ex.Message); }
            }
        }
    }

    // Класс SortEvent содержает делегат SortDelegate, событие SortEventForThisClass типа SortDelegate
    // Методы SortAsc и SortDec сортируют переданный список строк по возрастанию и убыванию соответственно
    class SortEvent {
        public delegate void SortDelegate(List<string> _namesList);
        public event SortDelegate? SortEventForThisClass;

        public void SortEventMethod(List<string> _namesList) {
            // Вызываем событие SortEventForThisClass, передавая ему список строк _namesList
            SortEventForThisClass?.Invoke(_namesList);
        }

        public void SortAsc(List<string> _namesList) {
            // Сортируем переданный список строк по возрастанию
            _namesList.Sort();
        }

        public void SortDec(List<string> _namesList) {
            // Сортируем переданный список строк по возрастанию, а затем разворачиваем его
            _namesList.Sort();
            _namesList.Reverse();
        }
    }
}