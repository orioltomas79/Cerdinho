using Cerdinho.Vincle;
using Newtonsoft.Json;

namespace Cerdinho
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string apartmentsPath = @"..\..\..\Apartments.json";

            // Read the current list of apartments
            var readText = File.ReadAllText(apartmentsPath);
            var listApartments = JsonConvert.DeserializeObject<List<Apartment>>(readText);

            // Vincle
            //var listVincle = Vincle.VincleParser.Parse();
            //MergeApartmentsList(listVincle, listApartments);

            // Idealista
            // Habitaclia
            var listHabitaclia = HabitacliaParser.Parse();
            MergeApartmentsList(listHabitaclia, listApartments);

            // FotoCasa
            // GlobalLlar
            // FinquesCadiMoixero

            // Write the new list of apartments
            var output = JsonConvert.SerializeObject(listApartments);
            File.WriteAllText(apartmentsPath, output);
        }

        private static void MergeApartmentsList(List<Apartment> fromList, ICollection<Apartment> toList)
        {
            foreach (var fromApartment in fromList)
            {
                var existingApartment = toList.FirstOrDefault(x => x.Url == fromApartment.Url);

                if (existingApartment != null) continue;
                
                fromApartment.PublishDate = DateTime.Now;
                toList.Add(fromApartment);
            }
        }
    }
}