namespace DesignPatterns.Creational.Prototype
{
    /*
     * Prototype позволяет копировать объекты, не вдаваясь в подрбности их реализации.
     * 
     * Преимущество паттерна:
     * Позволяет копировать объекты, не привязываясь к их конкретным классам.
     * 
     * Однако составные объекты, имеющие ссылки на другие классы, клонировать сложнее.
    */
    file interface IAnimal
    {
        void SetName(string name);

        string GetName();

        IAnimal Clone();
    }

    file class Sheep : IAnimal
    {
        private string name;

        public Sheep() { }
        public Sheep(Sheep donor) => this.name = donor.name;

        public void SetName(string name) => this.name = name;

        public string GetName() => this.name;

        public IAnimal Clone() => new Sheep(this);
    }

    public class Example 
    {
        public static void Run()
        {
            Console.ForegroundColor = ConsoleColor.White;

            IAnimal sheepDonor = new Sheep();
            sheepDonor.SetName("Долли");

            IAnimal sheepClone = sheepDonor.Clone();

            Console.WriteLine(sheepDonor.GetName());
            Console.WriteLine(sheepClone.GetName());
        }
    }
}
