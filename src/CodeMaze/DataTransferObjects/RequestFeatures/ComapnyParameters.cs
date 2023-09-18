namespace DataTransferObjects.RequestFeatures
{
    public  class ComapnyParameters : RequestParameters
    {
        public ComapnyParameters()
        {
            Orderby = "name";
        }
        public string Name { get; set; } 
        public string Country { get; set; } 
    }
}
