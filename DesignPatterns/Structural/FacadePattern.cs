namespace DesignPatterns.Structural.Facade
{
    /*
     * Facade позволяет скрыть сложность системы путем сведения всех возможных внешних вызовов к одному объекту, делегирующему их соответствующим объектам системы.
     * Применяется для установки некоторого рода политики по отношению к другой группе объектов.
    */

    file class ProviderCommunication
    {
        public void Receive() => Console.WriteLine("Получение продукции от производителя");
        public void Payment() => Console.WriteLine("Оплата поставщику с удержанием комиссии за продажу продукции");
    }

    file class Site
    {
        public void Placement() => Console.WriteLine("Размещение на сайте");
        public void Delete() => Console.WriteLine("Удаление с сайта");
    }

    file class Database
    {
        public void Insert() => Console.WriteLine("Запись в базу данных");
        public void Delete() => Console.WriteLine("Удаление из базы данных");
    }

    file class Marketplace
    {
        private ProviderCommunication providerCommunication;
        private Site site;
        private Database database;

        public Marketplace()
        {
            providerCommunication = new ProviderCommunication();
            site = new Site();
            database = new Database();
        }

        public void ProductReceipt()
        {
            providerCommunication.Receive();
            site.Placement();
            database.Insert();
        }

        public void ProductRelease()
        {
            providerCommunication.Payment();
            site.Delete();
            database.Delete();
        }
    }

    public class Example
    {
        public static void Run()
        {
            Console.ForegroundColor = ConsoleColor.White;

            Marketplace marketplace = new Marketplace();

            marketplace.ProductReceipt();

            Console.WriteLine(new string('-', 20));

            marketplace.ProductRelease();
        }
    }
}
