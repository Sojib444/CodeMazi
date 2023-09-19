namespace Entities.LinkModels
{
    public class LinkCollectionWrapper<T> : LinkResourseBase
    {
        public List<T> value { get; set; } = new List<T>();

        public LinkCollectionWrapper()
        {
            
        }

        public LinkCollectionWrapper(List<T> value)
        {
            this.value = value;
        }
    }
}
