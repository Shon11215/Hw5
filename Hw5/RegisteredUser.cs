using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Hw5
{
    internal class RegisteredUser : User
    {
        string email, password;
        public ClothingAd[] ad = new ClothingAd[0];

        public RegisteredUser() { }


        public RegisteredUser(string userId, string email, string password, string firstName, string lastName, string nickName,
        string phoneNumber, DateTime birthDate) : base(userId, firstName, lastName, nickName, phoneNumber, birthDate) {
            Email = email;
            Password = password;

        }
        public string Email
        {
            get { return email; }
            set => email = value;
        }
        public string Password
        {
            get { return password; }
            set => password = value;
        }

        public void Adding(ClothingAd ad) {
            Array.Resize(ref this.ad, this.ad.Length + 1);
            this.ad[this.ad.Length - 1] = ad;
        }
        public new void Print() {
            base.Print();
            if (ad == null) {
                Console.WriteLine($"{UserId} has no items in the cloathset yet.\n\n");
                return;
            }
            foreach (ClothingAd ad in this.ad) {
                ad.PrintAdDetails();
            }
        }


    }
}

