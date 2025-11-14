namespace DesignPatterns.Creational.Singleton
{
    /*
     * Singleton гарантирует, что на всю программу создастся лишь один экземпляр определенного класса.
     * 
     * Предоставляет глобальную точку доступа к этому экземпляру.
    */

    file class DatabaseHelper
    {
        private string data;
        private static DatabaseHelper databaseConnection;

        private DatabaseHelper() => Console.WriteLine("Подключение к БД");

        public static DatabaseHelper GetConnection()
        {
            if (databaseConnection == null)
            {
                databaseConnection = new DatabaseHelper();
            }
            return databaseConnection;
        }

        public string SelectData() => data;

        public void InsertData(string data)
        {
            Console.WriteLine($"Новые данные: {data}, внесены в БД");
            this.data = data;
        }
    }

    public class Example
    {
        public static void Run()
        {
            Console.ForegroundColor = ConsoleColor.White;

            DatabaseHelper.GetConnection().InsertData("123");
            DatabaseHelper.GetConnection().SelectData();
        }
    }
}
