namespace DesignPatterns.Structural.Proxy
{
    /*
     * Proxy представляет объект, который контролирует доступ к другому объекту, перехватывая все вызовы к нему.
     * Применяется кэширование ранее полученных данных и тем самым снижается количество запросов к серверу.
    */

    file interface ISite 
    {
        string GetPage(int num);
    }

    file class Site : ISite
    {
        public string GetPage(int num) => $"Это страница {num}";
    }

    file class SiteProxy : ISite
    {
        private ISite site;
        private Dictionary<int, string> cache;
        public SiteProxy(ISite site)
        {
            this.site = site;
            cache = new Dictionary<int, string>();
        }
        public string GetPage(int num)
        {
            string page;
            if (cache.ContainsKey(num))
            {
                page = cache[num];
                page = $"Из кэша: {page}";
            } 
            else
            {
                page = site.GetPage(num);
                cache.Add(num, page);
            }
            return page;
        }
    }

    public class Example
    {
        public static void Run()
        {
            ISite mySite = new SiteProxy(new Site());

            Console.WriteLine(mySite.GetPage(1));
            Console.WriteLine(mySite.GetPage(2));
            Console.WriteLine(mySite.GetPage(3));

            Console.WriteLine(mySite.GetPage(2));
        }
    }
}
