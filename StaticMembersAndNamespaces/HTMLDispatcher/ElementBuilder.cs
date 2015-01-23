using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace HTMLDispatcher
{
    class ElementBuilder
    {
        private string element;
        private readonly string[] validTags = new string[122] {"doctype", "a", "abbr", "acronym", "address", "applet", "area", "article", "aside", "audio", "b","base", "basefont", 
            "bdi", "bdo", "big", "blockquote", "body", "br", "button", "canvas", "caption","center", "cite", "code", "col", "colgroup", "datalist", "dd", "del", "details", "dfn", 
            "dialog", "dir","div", "dl", "dt", "em", "embed", "fieldset", "figcaption", "figure", "font", "footer", "form", "frame","frameset", "h1", "h2", "h3", "h4", "h5", "h6", 
            "head", "header", "hgroup", "hr", "html", "i", "iframe", "img", "input", "ins", "kbd", "keygen", "label", "legend", "li", "link", "main", "map", "mark", "menu", "menuitem",
            "meta", "meter", "nav", "noframes", "noscript", "object", "ol", "optgroup", "option", "putput", "p", "param","pre", "progress", "q", "rp", "rt", "ruby", "s", "samp", "script", 
            "section", "select", "small", "source", "span","strike", "strong", "style", "sub", "sup", "table", "tbody", "td", "textarea", "tfoot", "th", "thead", "time","title", "tr", "track", 
            "tt", "u", "ul", "var", "video", "wbr"};

        public ElementBuilder(string element)
        {
            this.Element = element;
        }

        public string Element
        {
            get { return this.element; }
            set
            {
                if (!validTags.Contains(value))
                {
                    throw new ArgumentException("Invalid HTML tag.");
                }
                StringBuilder b = new StringBuilder();
                b.AppendFormat("<{0}></{0}>", value);
                this.element = b.ToString();
            }
        }

        public void AddAttribute(string attribute, string value)
        {
            StringBuilder attr = new StringBuilder();
            attr.AppendFormat(@"{0}=""{1}""", attribute, value);
            Regex re = new Regex(@"(.*?)>(.*)");
            Match match = re.Match(this.Element);
            StringBuilder b = new StringBuilder();
            b.AppendFormat("{0} {1}>{2}", match.Groups[1].Value, attr, match.Groups[2].Value);
            this.element = b.ToString();
        }

        public void AddContent(string content)
        {
            Regex re = new Regex(@"(.*)><(.*)");
            Match match = re.Match(this.Element);
            StringBuilder b = new StringBuilder();
            b.AppendFormat("{0}>{1}<{2}", match.Groups[1].Value, content, match.Groups[2].Value);
            this.element = b.ToString();
        }

        public static string operator *(ElementBuilder element, int n)
        {
            StringBuilder b = new StringBuilder();
            for (int i = 0; i < n; i++)
            {
                b.AppendFormat(element.ToString());
            }
            return b.ToString();
        }

        public override string ToString()
        {
            return this.Element;
        }
    }
}
