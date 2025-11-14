namespace DesignPatterns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Выберите тип паттернов\n1. Порождающие\n2. Структурные\n3. Поведенческие");
                var type = Console.ReadKey();
                Console.Clear();
                switch (type.Key)
                {
                    case ConsoleKey.D1:
                        Console.WriteLine("Выберите паттерн\n1. Абстрактная фабрика\n2. Строитель\n3. Фабричный метод\n4. Прототип\n5. Синглтон");
                        var pattern1 = Console.ReadKey();
                        Console.Clear();
                        switch (pattern1.Key)
                        {
                            case ConsoleKey.D1:
                                Creational.AbstractFactory.Example.Run();
                                break;
                            case ConsoleKey.D2:
                                Creational.Builder.Example.Run();
                                break;
                            case ConsoleKey.D3:
                                Creational.FactoryMethod.Example.Run();
                                break;
                            case ConsoleKey.D4:
                                Creational.Prototype.Example.Run();
                                break;
                            case ConsoleKey.D5:
                                Creational.Singleton.Example.Run();
                                break;
                        }
                        Console.WriteLine("\n");
                        break;
                    case ConsoleKey.D2:
                        Console.WriteLine("Выберите паттерн\n1. Адаптер\n2. Мост\n3. Компоновщик\n4. Декоратор\n5. Фасад\n6. Легковес\n7. Заместитель");
                        var pattern2 = Console.ReadKey();
                        Console.Clear();
                        switch (pattern2.Key)
                        {
                            case ConsoleKey.D1:
                                Structural.Adapter.Example.Run();
                                break;
                            case ConsoleKey.D2:
                                Structural.Bridge.Example.Run();
                                break;
                            case ConsoleKey.D3:
                                Structural.Composite.Example.Run();
                                break;
                            case ConsoleKey.D4:
                                Structural.Decorator.Example.Run();
                                break;
                            case ConsoleKey.D5:
                                Structural.Facade.Example.Run();
                                break;
                            case ConsoleKey.D6:
                                Structural.Flyweight.Example.Run();
                                break;
                            case ConsoleKey.D7:
                                Structural.Proxy.Example.Run();
                                break;
                        }
                        Console.WriteLine("\n");
                        break;
                    case ConsoleKey.D3:
                        //Console.WriteLine("Выберите паттерн\n1. Порождающие\n2. Структурные\n3. Поведенческие");
                        var pattern3 = Console.ReadKey();
                        Console.Clear();
                        break;
                }
            }
        }
    }
}
