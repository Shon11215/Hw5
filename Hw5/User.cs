using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hw5
{
    internal class User
    {
        string userId, email, password, firstName, lastName, nickName,phoneNumber;
        DateTime birthDate;
        public User() { }
        public User(string userId, string email, string password,
        string firstName, string lastName, string nickName,
        string phoneNumber, DateTime birthDate)
        {
            this.userId = userId;
            this.email = email;
            this.password = password;
            this.firstName = firstName;
            this.lastName = lastName;
            this.nickName = nickName;
            this.phoneNumber = phoneNumber;
            this.birthDate = birthDate;
        }
        public string Email { get { return email; } }
        public string Password { get { return password; } }
        public string FirstName { get { return firstName; } }
        public string LastName { get { return lastName; } }
        public string UserId { get { return userId; } }
        public void Print()
        {
            Console.WriteLine($"Details User {firstName} {lastName} -{ userId}:");
            Console.WriteLine($"nickName: {nickName}\nPhone: {phoneNumber}\nbirth date: {birthDate}");
        }
    }
}
