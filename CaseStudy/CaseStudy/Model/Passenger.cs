namespace CaseStudy.Model
{
    public class Passenger
    {
        public int PassengerID { get; set; }
        public string? FirstName { get; set; }
        public string? Gender { get; set; }
        public int? Age { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public Passenger() { }
        public Passenger(int passengerID,string? firstName, string? gender, int? age, string? email, string? phoneNumber)
        {
            PassengerID = passengerID;
            FirstName = firstName;
            Gender = gender;
            Age = age;
            Email = email;
            PhoneNumber = phoneNumber;
        }

        public override string ToString()
        {
            return $"PassengerID: {PassengerID}\t Name: {FirstName}\t Gender: {Gender}\t Age: {Age}\t Email: {Email} \t Phone Number: {PhoneNumber}";
        }
    }
}
