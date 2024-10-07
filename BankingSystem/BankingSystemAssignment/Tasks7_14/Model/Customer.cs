namespace BankingSystemAssignment.Tasks7_14.Model
{
    internal class Customer
    {
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        public Customer()
        {
        }

        public Customer(int customerId, string firstName, string lastName, DateTime dob, string email, string phone, string address)
        {
            CustomerID = customerId;
            FirstName = firstName;
            LastName = lastName;
            DOB = dob;
            Email = email;
            Phone = phone;
            Address = address;
        }

        public override string ToString()
        {
            return $"CustomerID = {CustomerID}, FirstName = {FirstName}, LastName = {LastName}, Email = {Email}, Phone = {Phone}, Address = {Address}";
        }

    }
}
