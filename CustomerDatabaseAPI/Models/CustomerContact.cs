namespace CustomerDatabaseAPI.Models
{
    public class CustomerContact
    {
        public int CustomerContactId { get; set; }
        public string CustomerPhoneNumber { get; set; }
        public string CustomerPhoneType { get; set; }

        public int CustomerID { get; set; }
    }
}
