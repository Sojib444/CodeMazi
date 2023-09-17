using Entities.Model;
using System.Runtime.CompilerServices;

namespace Repository.Extension
{
    public static class RepositoryCompanyExtension
    {
        public static IEnumerable<Company> FilterCompany(this IEnumerable<Company> companies, string country)
        {
           return companies.Where(c => c.Country == country).ToList();
        }

        public static IEnumerable<Company> SearchCompany(this IEnumerable<Company> companies, string serachTerm)
        {
            if(string.IsNullOrEmpty(serachTerm))
            {
                return companies;
            }

            var lowerCas = serachTerm.Trim().ToLower();

            return companies.Where(c => c.Name.ToLower().Contains(serachTerm)).ToList();
        }
    }
}
