using Entities.Model;
using System.Text;
using System.Linq.Dynamic.Core;

namespace Repository.Extension
{
    public static class RepositoryCompanyExtension
    {
        public static IQueryable<Company> FilterCompany(this IQueryable<Company> companies, string country)
        {
            return companies.Where(c => c.Country == country);
        }

        public static IQueryable<Company> SearchCompany(this IQueryable<Company> companies, string serachTerm)
        {
            if (string.IsNullOrEmpty(serachTerm))
            {
                return companies;
            }

            var lowerCas = serachTerm.Trim().ToLower();

            return companies.Where(c => c.Name.ToLower().Contains(serachTerm));
        }

        public static IQueryable<Company> Sort(this IQueryable<Company> companies, string orderQueryString)
        {
            if (string.IsNullOrEmpty(orderQueryString))
            {
                return companies.OrderBy(c => c.Name);
            }

            var orderparams = orderQueryString.Trim().Split(',');

            var propertyInfo = typeof(Company).GetProperties(System.Reflection.BindingFlags.Public |
                            System.Reflection.BindingFlags.Instance);

            var queryBuilder = new StringBuilder();

            foreach (var item in orderparams)
            { 
                if (string.IsNullOrEmpty(item))
                    continue;

                var propetyFromQuery = item.Split(" ")[0];

                var objectProperty = propertyInfo.FirstOrDefault(pi => pi.Name.Equals(propetyFromQuery, StringComparison.CurrentCultureIgnoreCase));

                if (objectProperty == null)
                    continue;

                var direction = item.EndsWith(" desc") ? "descending" : "ascending";

                queryBuilder.Append($"{objectProperty.Name.ToString()} {direction}");

            }

            var orderQuery = queryBuilder.ToString().TrimEnd(',', ' ');

            if (string.IsNullOrEmpty(orderQuery))
                return companies.OrderBy(c => c.Name);

            return companies.OrderBy(orderQuery);

        }
    }
}
