using System.Text;

namespace Cerdinho
{
    internal class HtmlGenerator
    {

        public static void GenerateReport(List<Apartment> apartments)
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("<!DOCTYPE html><html><body>");

            stringBuilder.AppendLine("<h1>Report</h1>");
            
            foreach (var apartment in apartments.OrderByDescending(a => a.PublishDate))
            {
                stringBuilder.AppendLine($"<p><a href=\"{apartment.Url}\">{apartment.Agency} - {apartment.PublishDate} - {apartment.PublishDate}</a></p>");
            }

            stringBuilder.AppendLine("\r\n</body></html>");

            File.WriteAllText(@"..\..\..\Report.html", stringBuilder.ToString());
        }

    }
}
