using System.Dynamic;

namespace Contracts.Data_Shaper
{
    public interface IDataShaper<T>
    {
        IEnumerable<ExpandoObject> ShapeData(IEnumerable<T> entities, string fieldString);
        ExpandoObject ShapeData(T entities, string fieldString);
    }
}
