using HtmlAgilityPack;

namespace Cerdinho.Vincle
{
    internal class VincleParser
    {
        public static List<Apartment> Parse()
        {
            var apartments = new List<Apartment>();

            // From disk
            //var path = @"Vincle\Sample.html";
            //var doc = new HtmlDocument();
            //doc.Load(path);

            // From Web
            const string urlApartaments = "https://www.vinclecerdanya.com/venda-apartaments/";
            var web = new HtmlWeb();
            var docApartaments = web.Load(urlApartaments);

            var htmlNodesApartaments = docApartaments.DocumentNode.SelectNodes("//li[contains(@class,'destacadito')]");

            foreach (var htmlNode in htmlNodesApartaments)
            {
                var href = htmlNode.FirstChild.Attributes["href"];
                var apartment = new Apartment
                {
                    Agency = "Vincle-Apartaments",
                    Url = href.Value,
                    Price = htmlNode.FirstChild.FirstChild.FirstChild.ParentNode.LastChild.InnerHtml
                };
                apartments.Add(apartment);
            }

            const string urlAdosades = "https://www.vinclecerdanya.com/venda-adossades/";
            var docAdosades = web.Load(urlAdosades);

            var htmlNodesAdosades = docAdosades.DocumentNode.SelectNodes("//li[contains(@class,'destacadito')]");

            foreach (var htmlNode in htmlNodesAdosades)
            {
                var href = htmlNode.FirstChild.Attributes["href"];
                var apartment = new Apartment
                {
                    Agency = "Vincle-Adosades",
                    Url = href.Value,
                    Price = htmlNode.FirstChild.FirstChild.FirstChild.ParentNode.LastChild.InnerHtml
                };
                apartments.Add(apartment);
            }
            
            return apartments;
        }

    }
}
