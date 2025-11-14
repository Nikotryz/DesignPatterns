namespace DesignPatterns.Creational.FactoryMethod
{
    /*
     * Factory Method предоставляет дочерним классам интерфейс для создания экземпляров некоторого класса.
     * 
     * В момент создания наследники могут определить, какой класс создавать.
     * 
     * Иными словами, данный шаблон делегирует создание объектов наследникам родительского класса.
     * 
     * Позволяет использовать в программе неспецифический классы, а манипуляровать абстрактными объектами на более высоком уровне.
     * 
     * Недостатком является необходимость создания наследника для каждого нового типа.
    */

    file interface IProduction
    {
        void Release();
    }

    file class Car : IProduction
    {
        public void Release() => Console.WriteLine("Выпущен новый легковой автомобиль");
}

    file class Truck : IProduction
    {
        public void Release() => Console.WriteLine("Выпущен новый грузовой автомобиль");
    }

    file interface IWorkShop
    {
        IProduction Create();
    }

    file class CarWorkShop : IWorkShop
    {
        public IProduction Create() => new Car();
    }

    file class TruckWorkShop : IWorkShop
    {
        public IProduction Create() => new Truck();
    }

    public class Example
    {
        public static void Run()
        {
            Console.ForegroundColor = ConsoleColor.White;

            IWorkShop creator = new CarWorkShop();
            
            IProduction car = creator.Create();

            car.Release();
            
            creator = new TruckWorkShop();

            car = creator.Create();

            car.Release();
        }
    }
}
