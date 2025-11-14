namespace DesignPatterns.Structural.Adapter
{
    /*
     * Adapter предназначен для организации использования функций объекта, недоступного для модификации, через специально созданный интерфейс.
     * Позволяет объектам с несовместимыми интерфейсами работать вместе.
    */

    file interface IScales
    {
        float GetWeight();
    }

    file class RussianScales : IScales
    {
        private float currentWeight;

        public RussianScales(float currentWeight) => this.currentWeight = currentWeight;

        public float GetWeight() => currentWeight;
    }

    file class BritishScales : IScales
    {
        private float currentWeight;

        public BritishScales(float currentWeight) => this.currentWeight = currentWeight;

        public float GetWeight() => currentWeight;
    }

    file class AdapterForBritishScales : IScales
    {
        private BritishScales britishScales;

        public AdapterForBritishScales(BritishScales britishScales) => this.britishScales = britishScales;

        public float GetWeight() => britishScales.GetWeight() * 0.453f;
    }

    public class Example
    {
        public static void Run()
        {
            Console.ForegroundColor = ConsoleColor.White;

            float kg = 55.0f;
            float lb = 55.0f;

            IScales rScales = new RussianScales(kg);
            IScales bScales = new AdapterForBritishScales(new BritishScales(lb));

            Console.WriteLine(rScales.GetWeight());
            Console.WriteLine(bScales.GetWeight());
        }
    }
}
