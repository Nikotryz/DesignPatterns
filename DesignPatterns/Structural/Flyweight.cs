using System.Collections;

namespace DesignPatterns.Structural.Flyweight
{
    /*
     * Flyweight позволяет вместить большее количество объектов в отведенную оперативную память.
     * Экономит память, выделяя и сохраняя общие параметры объектов, однако расходует процессорное время на поиск и из-за введения доп. классов усложняет код программы.
    */

    file struct Shared
    {
        private string company;
        private string position;
        public Shared(string company, string position)
        {
            this.company = company;
            this.position = position;
        }
        public string Company { get => company; }
        public string Position { get => position; }
    }

    file struct Unique
    {
        private string name;
        private string passport;
        public Unique(string name, string passport)
        {
            this.name = name;
            this.passport = passport;
        }
        public string Name { get => name; }
        public string Passport { get => passport; }
    }

    file class Flyweight
    {
        private Shared shared;
        public Flyweight(Shared shared) => this.shared = shared;
        public void Process(Unique unique)
        {
            Console.WriteLine($"Отображаем новые данные: общее - {shared.Company}_{shared.Position} и уникальное - {unique.Name}_{unique.Passport}.");
        }
        public string GetData() => $"{shared.Company}_{shared.Position}";
    }

    file class FlyweightFactory
    {
        private Hashtable flyweights;
        private string GetKey(Shared shared) => $"{shared.Company}_{shared.Position}";
        public FlyweightFactory(List<Shared> shareds)
        {
            flyweights = new Hashtable();
            foreach (Shared shared in shareds)
                flyweights.Add(GetKey(shared), new Flyweight(shared));
        }
        public Flyweight GetFlyweight(Shared shared)
        {
            string key = GetKey(shared);
            if (!flyweights.ContainsKey(key))
            {
                Console.WriteLine($"Фабрика легковесов: Общий объект по ключу {key} не найден. Создаем новый.");
                flyweights.Add(GetKey(shared), new Flyweight(shared));
            }
            else
            {
                Console.WriteLine($"Фабрика легковесов: Извлекаем данные из имеющихся записей по ключу {key}.");
            }
            return (Flyweight)flyweights[key];
        }
        public void ListFlyweights()
        {
            int count = flyweights.Count;
            Console.WriteLine($"Фабрика легковесов: Всего {count} записей:");
            foreach (Flyweight pair in flyweights.Values)
            {
                Console.WriteLine(pair.GetData());
            }
        }
    }

    file static class Database 
    {
        public static void AddSpecialsDatabase(FlyweightFactory ff, string company, string position, string name, string passport)
        {
            Console.WriteLine();
            Flyweight flyweight = ff.GetFlyweight(new Shared(company, position));
            flyweight.Process(new Unique(name, passport));
        }
    }

    public class Example
    {
        
        public static void Run()
        {
            Console.ForegroundColor = ConsoleColor.White;

            FlyweightFactory factory = new FlyweightFactory(new List<Shared>()
            {
                new Shared("Microsoft", "Управляющий"),
                new Shared("Google", "Android-разработчик"),
                new Shared("Google", "Web-разработчик"),
                new Shared("Apple", "IPhone-разработчик")
            });
            factory.ListFlyweights();

            Database.AddSpecialsDatabase(factory, "Google", "Web-разработчик", "Борис", "AM-12314523");
            Database.AddSpecialsDatabase(factory, "Apple", "Управляющий", "Александр", "DE-12312563");

            Console.WriteLine();
            factory.ListFlyweights();
        }
    }
}
