namespace DesignPatterns.Creational.Builder
{
    /*
     * Builder предоставляет способ создания составного объекта.
     * 
     * Отделяет конструирование сложного объекта от его представления так, что в результате одного и того же процесса конструирования могут получаться разные представления.
     * 
     * Преимущества паттерна:
     * 1) Позволяет изменять внутреннее представление продукта
     * 2) Изолирует код, реализующий конструирование и представление
     * 3) Дает более тонкий контроль над процессом конструирования
     * 
    */
    file class Phone
    {
        private string data;

        public Phone() => data = "";

        public string AboutPhone() => data;

        public void AppendData(string str) => data += str;
    }

    file interface IDeveloper
    {
        void CreateDisplay();
        void CreateBox();
        void SystemInstall();
        Phone GetPhone();
    }

    file class AndroidDeveloper : IDeveloper
    {
        private Phone phone;

        public AndroidDeveloper() => phone = new Phone();

        public void CreateBox() => phone.AppendData("Произведен корпус Samsung; ");

        public void CreateDisplay() => phone.AppendData("Произведен дисплей Samsung; ");

        public Phone GetPhone() => phone;

        public void SystemInstall() => phone.AppendData("Установлена ОС Android; ");
    }

    file class IphoneDeveloper : IDeveloper
    {
        private Phone phone;

        public IphoneDeveloper() => phone = new Phone();

        public void CreateBox() => phone.AppendData("Произведен корпус Iphone; ");

        public void CreateDisplay() => phone.AppendData("Произведен дисплей Iphone; ");

        public Phone GetPhone() => phone;

        public void SystemInstall() => phone.AppendData("Установлена IOS; ");
    }

    file class Director
    {
        private IDeveloper developer;

        public Director(IDeveloper developer) => this.developer = developer;

        public void SetDeveloper(IDeveloper developer) => this.developer = developer;

        public Phone MountOnlyPhone()
        {
            developer.CreateBox();
            developer.CreateDisplay();
            return developer.GetPhone();
        }

        public Phone MountFullPhone()
        {
            developer.CreateBox();
            developer.CreateDisplay();
            developer.SystemInstall();
            return developer.GetPhone();
        }
    }

    public class Example
    {
        public static void Run()
        {
            Console.ForegroundColor = ConsoleColor.White;

            IDeveloper androidDeveloper = new AndroidDeveloper();
            Director director = new Director(androidDeveloper);
            Phone samsung = director.MountFullPhone();
            Console.WriteLine(samsung.AboutPhone());

            IDeveloper iphoneDeveloper = new AndroidDeveloper();
            director.SetDeveloper(iphoneDeveloper);
            Phone iphone = director.MountOnlyPhone();
            Console.WriteLine(iphone.AboutPhone());
        }
    }
}
