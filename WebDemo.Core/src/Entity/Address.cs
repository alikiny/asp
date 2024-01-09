namespace WebDemo.Core.src.Entity
{
    public class Address : OwnerContainer
    {
        public int HouseNumber { get; set; }
        public string Street { get; set; }
        public int PostCode { get; set; }
    }
}