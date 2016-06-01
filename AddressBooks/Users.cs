using System;

namespace AddressBooks_Data
{
    public enum GenderEnum
    {
        Male,
        Female
    }

    public class Users
    {
        private string _lastName;
        private string _firstName;
        private DateTime _birthDate;
        private DateTime _timeAdded;
        private string _city;
        private string _address;
        private string _phoneNumber;
        private GenderEnum _gender;
        private string _email;

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }
        public DateTime BirthDate
        {
            get { return _birthDate; }
            set { _birthDate = value; }
        }
        public DateTime TimeAdded
        {
            get { return _timeAdded; }
            set { _timeAdded = value; }
        }
        public string City
        {
            get { return _city; }
            set { _city = value; }
        }
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { _phoneNumber = value; }
        }
        public GenderEnum Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        //Вивести дані на консоль
        public void ShowUsers()
        {
            Console.WriteLine("LastName: {0}\nFirstName: {1}\nBirthDate: {2:d}\nTimeAdded: {3:H:mm:ss}\nCity: {4}" +
                "\nAddress: {5}\nPhoneNumber: {6}\nGender: {7}\nEmail: {8}", LastName, FirstName,
                BirthDate, TimeAdded, City, Address, PhoneNumber, Gender, Email);
        }
    }
}
