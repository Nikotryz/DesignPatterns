namespace DesignPatterns.Creational.AbstractFactory
{
    /*
     * Abtract Factory предоставляет интерфейс для создания семейств взаимосвязанных или взаимозависимых объектов, не специфицируя их конкретных классов.
     * 
     * Шаблон применяется в случаях, когда программа должна быть независимой от процесса и типов создаваемых новых объектов.
     * 
     * Преимущества паттерна:
     * 1) Изолирует конкретные классы
     * 2) Упрощает замену семейств продуктов
     * 3) Гарантирует сочетаемость продуктов
     * 
     * Недостаток:
     * Сложность добавления и поддержки новых видов продуктов.
    */

    file interface IEngine
    {
        void ReleaseEngine();
    }

    file class JapaneseEngine : IEngine
    {
        public void ReleaseEngine() => Console.WriteLine("Японский двигатель");
    }

    file class RussianEngine : IEngine
    {
        public void ReleaseEngine() => Console.WriteLine("Русский двигатель");
    }

    file interface ICar
    {
        void ReleaseCar(IEngine engine);
    }

    file class JapaneseCar : ICar
    {
        public void ReleaseCar(IEngine engine)
        {
            Console.Write("Собрали японский автомобиль: ");
            engine.ReleaseEngine();
        }
    }

    file class RussianCar : ICar
    {
        public void ReleaseCar(IEngine engine)
        {
            Console.Write("Собрали русский автомобиль: ");
            engine.ReleaseEngine();
        }
    }

    file interface IFactory
    {
        IEngine CreateEngine();
        ICar CreateCar();
    }

    file class JapaneseFactory : IFactory
    {
        public ICar CreateCar() => new JapaneseCar();

        public IEngine CreateEngine() => new JapaneseEngine();
    }

    file class RussianFactory : IFactory
    {
        public ICar CreateCar() => new RussianCar();

        public IEngine CreateEngine() => new RussianEngine();
    }

    public class Example
    {
        public static void Run()
        {
            Console.ForegroundColor = ConsoleColor.White;

            IFactory jFactory = new JapaneseFactory();

            IEngine jEngine = jFactory.CreateEngine();
            ICar jCar = jFactory.CreateCar();

            jCar.ReleaseCar(jEngine);

            IFactory rFactory = new RussianFactory();

            IEngine rEngine = rFactory.CreateEngine();
            ICar rCar = rFactory.CreateCar();

            rCar.ReleaseCar(rEngine);
        }
    }
}
