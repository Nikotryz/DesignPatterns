namespace DesignPatterns.Structural.Composite
{
    /*
     * Composite объединяет объекты в древовидную структуру для представления иерархии.
     * Позволяет клиентам обращаться к отдельным объектам и группам объектов одинаково.
    */

    file abstract class Item
    {
        protected string itemName;
        protected string ownerName;
        public void SetOwner(string ownerName) => this.ownerName = ownerName;
        public Item(string itemName) => this.itemName = itemName;
        public virtual void Add(Item subItem) { }
        public virtual void Remove(Item subItem) { }
        public abstract void Display();
    }

    file class ClickableItem : Item
    {
        public ClickableItem(string itemName) : base(itemName) { }
        public override void Add(Item subItem)
        {
            throw new Exception();
        }
        public override void Remove(Item subItem)
        {
            throw new Exception();
        }
        public override void Display()
        {
            Console.WriteLine(itemName);
        }
    }

    file class DropDownItem : Item
    {
        private List<Item> children;
        public DropDownItem(string itemName) : base(itemName) 
        {
            children = new List<Item>();
        }
        public override void Add(Item subItem)
        {
            subItem.SetOwner(this.itemName);
            children.Add(subItem);
        }
        public override void Remove(Item subItem)
        {
            children.Remove(subItem);
        }
        public override void Display()
        {
            foreach (var item in children)
            {
                if (ownerName != null)
                {
                    Console.Write(ownerName + itemName);
                }
                item.Display();
            }
        }
    }

    public class Example
    {
        public static void Run()
        {
            Console.ForegroundColor = ConsoleColor.White;

            Item file = new DropDownItem("Файл --> ");
            Item create = new DropDownItem("Создать --> ");
            Item open = new DropDownItem("Открыть --> ");
            Item exit = new ClickableItem("Выход");

            file.Add(create);
            file.Add(open);
            file.Add(exit);

            Item project = new ClickableItem("Проект...");
            Item repository = new ClickableItem("Репозиторий...");

            create.Add(project);
            create.Add(repository);

            Item solution = new ClickableItem("Решение...");
            Item folder = new ClickableItem("Папку...");

            open.Add(solution);
            open.Add(folder);

            file.Display();
            Console.WriteLine();

            file.Remove(create);

            file.Display();
        }
    }
}
