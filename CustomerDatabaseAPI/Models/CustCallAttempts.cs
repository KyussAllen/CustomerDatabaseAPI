namespace CustomerDatabaseAPI.Models
{
    public class CustCallAttempts
    {
        public int CallAttemptID { get; set; }
        public DateTime TimeOfAttempt {  get; set; }
        public string notes { get; set; }

        public int CustomerID { get; set; }
    }
}
