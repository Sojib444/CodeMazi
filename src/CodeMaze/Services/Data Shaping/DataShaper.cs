using Contracts.Data_Shaper;
using System.Dynamic;
using System.Reflection;

namespace Services.Data_Shaping
{
    public class DataShaper<T> : IDataShaper<T> where T : class
    {
        public PropertyInfo[] properties { get; set; }

        public DataShaper()
        {
            properties = typeof(T).GetProperties();
        }
        public IEnumerable<ExpandoObject> ShapeData(IEnumerable<T> entities, string fieldString)
        {
            var requiredProperties = GetRequiredProperties(fieldString);

            return FetchData(entities, requiredProperties);
        }

        public ExpandoObject ShapeData(T entities, string fieldString)
        {
            var requiredProperties = GetRequiredProperties(fieldString);

            return FetchDataForEntity(entities, requiredProperties);
        }

        private IEnumerable<PropertyInfo> GetRequiredProperties(string fieldSrting)
        {
            var requiredProperties = new List<PropertyInfo>();

            if(!string.IsNullOrEmpty(fieldSrting))
            {
                var fields = fieldSrting.Split(',', StringSplitOptions.RemoveEmptyEntries);

                foreach (var item in fields)
                {
                    var property = properties.FirstOrDefault(pi => pi.Name.Equals(item.Trim()));

                    if(property == null)
                    {
                        continue;
                    }

                    requiredProperties.Add(property);
                }
            }
            else
            {
                requiredProperties = properties.ToList();
            }

            return requiredProperties;
        }

        private IEnumerable<ExpandoObject> FetchData(IEnumerable<T> entities,IEnumerable<PropertyInfo> requiredProperties)
        {
            var shapedData = new List<ExpandoObject>();

            foreach (var entity in entities)
            {
                var shapedObject = FetchDataForEntity(entity, requiredProperties);
                shapedData.Add(shapedObject);
            }
            return shapedData;
        }

        private ExpandoObject FetchDataForEntity(T entity, IEnumerable<PropertyInfo>requiredProperties)
        {
            var shapedObject = new ExpandoObject();

            foreach (var property in requiredProperties)
            {
                var objectPropertyValue = property.GetValue(entity);
                shapedObject.TryAdd(property.Name, objectPropertyValue);
            }
            return shapedObject;
        }
    }
}
