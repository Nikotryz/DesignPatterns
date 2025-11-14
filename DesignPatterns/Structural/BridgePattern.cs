namespace DesignPatterns.Structural.Bridge
{
    /*
     * Bridge разделяет абстракцию и реализацию так, чтобы они не могли изменяться независимо.
     * Шаблон использует инкапсуляцию, агрегирование и может использовать наследование для того, чтобы разделить ответственность между классами.
    */

    file interface IDataReader
    {
        void Read();
    }

    file class DatabaseReader : IDataReader
    {
        public void Read() => Console.WriteLine("Данные из БД");
    }

    file class FileReader : IDataReader
    {
        public void Read() => Console.WriteLine("Данные из файла...");
    }

    file abstract class Sender
    {
        protected IDataReader reader;

        public Sender(IDataReader reader) => this.reader = reader;

        public void SetDataReader(IDataReader reader) => this.reader = reader;

        public abstract void Send();

    }

    file class EmailSender : Sender
    {
        public EmailSender(IDataReader reader) : base(reader) {}

        public override void Send()
        {
            reader.Read();
            Console.WriteLine("Отправлены с помощью Email");
        }
    }

    file class TelegramBotSender : Sender
    {
        public TelegramBotSender(IDataReader reader) : base(reader) { }

        public override void Send()
        {
            reader.Read();
            Console.WriteLine("Отправлены с помощью Telegram bot");
        }
    }

    public class Example
    {
        public static void Run()
        {
            Console.ForegroundColor = ConsoleColor.White;

            Sender sender = new EmailSender(new DatabaseReader());
            sender.Send();

            sender.SetDataReader(new FileReader());
            sender.Send();

            sender = new TelegramBotSender(new DatabaseReader());
            sender.Send();
        }
    }
}
