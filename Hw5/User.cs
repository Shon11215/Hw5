using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hw5
{
    internal class User
    {
        string userId, firstName, lastName, nickName, phoneNumber;
        DateTime birthDate;
        ClothingItem[] item = new ClothingItem[0];

        public User() { }
        public User(string userId, string firstName, string lastName, string nickName,
        string phoneNumber, DateTime birthDate) {
            this.userId = userId;
            this.firstName = firstName;
            this.lastName = lastName;
            this.nickName = nickName;
            this.phoneNumber = phoneNumber;
            this.birthDate = birthDate;
        }
        public string FirstName { get { return firstName; } }
        public string LastName { get { return lastName; } }
        public string UserId { get { return userId; } }
        public void AddItem(ClothingItem item) {
            Array.Resize(ref this.item, this.item.Length + 1);

            this.item[this.item.Length - 1] = item;
        }
        public void Print() {
            Console.WriteLine($"Details User {firstName} {lastName} -{userId}:");
            Console.WriteLine($"nickName: {nickName}\nPhone: {phoneNumber}\nbirth date: {birthDate}");
            if (item == null) {
                Console.WriteLine($"{userId} has no items in the cloathset yet.\n");
                return;
            }
            foreach (ClothingItem item in this.item) {
                item.Print();
            }
        }

    }

}

