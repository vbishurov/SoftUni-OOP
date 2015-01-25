namespace HTMLDispatcher
{
    using System.Text;

    internal static class HTMLDispatcher
    {
        public static string CreateImage(string source, string alt, string title)
        {
            StringBuilder b = new StringBuilder();
            ElementBuilder img = new ElementBuilder("img");
            img.AddAttribute("src", source);
            img.AddAttribute("alt", alt);
            img.AddAttribute("title", title);
            b.AppendFormat(img.ToString());
            return b.ToString();
        }

        public static string CreateURL(string url, string title, string text)
        {
            StringBuilder b = new StringBuilder();
            ElementBuilder link = new ElementBuilder("a");
            link.AddAttribute("href", url);
            link.AddAttribute("title", title);
            link.AddContent(text);
            b.AppendFormat(link.ToString());
            return b.ToString();
        }

        public static string CreateInput(string type, string name, string value)
        {
            StringBuilder b = new StringBuilder();
            ElementBuilder input = new ElementBuilder("input");
            input.AddAttribute("type", type);
            input.AddAttribute("name", name);
            input.AddAttribute("value", value);
            b.AppendFormat(input.ToString());
            return b.ToString();
        }
    }
}
