using HtmlAgilityPack;

namespace Cerdinho.Vincle
{
    internal class HabitacliaParser
    {
        public static List<Apartment> Parse()
        {
            var apartments = new List<Apartment>();

            // From disk
            var path = @"Habitaclia\Sample.html";
            var docApartaments = new HtmlDocument();
            docApartaments.Load(path);

            // From Web
            //const string urlApartaments = "https://www.vinclecerdanya.com/venda-apartaments/";
            //var web = new HtmlWeb();
            //var docApartaments = web.Load(urlApartaments);

            var htmlNodesApartaments = docApartaments.DocumentNode.SelectNodes("//article");

            foreach (var htmlNode in htmlNodesApartaments)
            {
                var href = htmlNode.Attributes["data-href"];
                
                if (href == null) continue;

                var apartment = new Apartment
                {
                    Agency = "Habitaclia",
                    Url = href.Value,
                    Price = "0"
                };
                apartments.Add(apartment);
            }
            
            return apartments;
        }

    }
}
