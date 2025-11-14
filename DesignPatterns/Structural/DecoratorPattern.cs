namespace DesignPatterns.Structural.Decorator
{
    /*
     * Decorator предназначен для динамического подключения объекту дополнительного поведения.
     * Предоставляет гибкую альтернативу практике создания подклассов с целью расширения функциональности.
    */

    file interface IProcessor
    {
        void Process();
    }

    file class Transmitter : IProcessor
    {
        private string data;
        public Transmitter(string data) => this.data = data;
        public void Process() => Console.WriteLine($"Данные {data} переданы по каналу связи");
    }

    // Сам декоратор
    file abstract class Shell : IProcessor
    {
        protected IProcessor processor;
        public Shell(IProcessor processor) => this.processor = processor;
        public virtual void Process() => processor.Process();
    }

    file class HammingCoder : Shell
    {
        public HammingCoder(IProcessor processor) : base(processor) { }
        public override void Process()
        {
            Console.Write($"Наложен помехоустойчивый код Хамминга --> ");
            processor.Process();
        }
    }

    file class Encryptor : Shell
    {
        public Encryptor(IProcessor processor) : base(processor) { }
        public override void Process()
        {
            Console.Write($"Шифрование данных --> ");
            processor.Process();
        }
    }

    public class Example
    {
        public static void Run()
        {
            Console.ForegroundColor = ConsoleColor.White;

            IProcessor transmitter = new Transmitter("12345");
            transmitter.Process();
            Console.WriteLine();

            Shell hammingCoder = new HammingCoder(transmitter);
            hammingCoder.Process();
            Console.WriteLine();

            Shell encoder = new Encryptor(hammingCoder);
            encoder.Process();
        }
    }
}
