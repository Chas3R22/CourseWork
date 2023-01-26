using CourseWork.Domain.Models;
using CsvHelper;
using System.Globalization;

namespace CourseWork.Persistence.Data
{
    public static class DbSeeder
    {
        public static void SeedDb(AppDbContext context)
        {
            SeedCountries(context);
            SeedIndustries(context);
            SeedOrganizations(context);
        }

        private static void SeedCountries(AppDbContext context)
        {
            if (context.Countries.Any())
            {
                return;
            }

            using var reader = new StreamReader("organizations.csv");
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

            csv.Read();
            csv.ReadHeader();

            while (csv.Read())
            {
                var countryName = csv.GetField("Country");

                if (context.Countries.Any(c => c.Name == countryName))
                {
                    continue;
                }

                var country = new Country(countryName);

                context.Countries.Add(country);
                context.SaveChanges();
            }
        }

        private static void SeedIndustries(AppDbContext context)
        {
            if (context.Industries.Any())
            {
                return;
            }

            using var reader = new StreamReader("organizations.csv");
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

            csv.Read();
            csv.ReadHeader();

            while (csv.Read())
            {
                var industryName = csv.GetField("Industry");

                if (context.Industries.Any(c => c.Name == industryName))
                {
                    continue;
                }

                var industry = new Industry(industryName);

                context.Industries.Add(industry);
                context.SaveChanges();
            }
        }
        private static void SeedOrganizations(AppDbContext context)
        {
            if (context.Organizations.Any())
            {
                return;
            }

            using var reader = new StreamReader("organizations.csv");
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

            csv.Read();
            csv.ReadHeader();

            while (csv.Read())
            {
                var organization = new Organization(csv.GetField("Name"))
                {
                    Website = csv.GetField("Website"),
                    Country = GetRandomCountry(context.Countries.ToList()),
                    Description = csv.GetField("Description"),
                    Founded = csv.GetField<int>("Founded"),
                    Industry = GetRandomIndustry(context.Industries.ToList()),
                    EmployeeAmounts = csv.GetField<int>("Number of employees"),
                };

                context.Organizations.Add(organization);
            }

            context.SaveChanges();
        }

        private static Country GetRandomCountry(List<Country> countries)
        {
            int randomIndex = new Random().Next(0, countries.Count);

            return countries[randomIndex];
        }
        private static Industry GetRandomIndustry(List<Industry> industries)
        {
            int randomIndex = new Random().Next(0, industries.Count);

            return industries[randomIndex];
        }
    }
}
