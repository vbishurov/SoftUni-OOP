namespace HTMLDispatcher
{
    using System;

    public class HTMLDispatcherTest
    {
        public static void Main(string[] args)
        {
            ElementBuilder div = new ElementBuilder("div");
            div.AddAttribute("id", "page");
            div.AddAttribute("class", "big");
            div.AddContent("<p>Hello</p>");

            // ElementBuilder invalid = new ElementBuilder("invalid"); // Invalid HTML tag exception
            Console.WriteLine(div * 2);

            Console.WriteLine(HTMLDispatcher.CreateImage("vav C-to", "qka kartinka", "Pesho"));

            Console.WriteLine(HTMLDispatcher.CreateURL("https://www.facebook.com", "Facebook", "Facebook"));

            Console.WriteLine(HTMLDispatcher.CreateInput("submit", "submit", "submit"));
        }
    }
}
