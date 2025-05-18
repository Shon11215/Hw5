using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hw5
{
    internal class BusinessUser : RegisteredUser
    {
        string instgram_link;
        PopupEvent[] pop= new PopupEvent[0];

        public BusinessUser(string userId, string email, string password,  string firstName, string lastName, string nickName,
        string phoneNumber, DateTime birthDate, string instegram_link) : base(userId,email, password, firstName, lastName, nickName,phoneNumber, birthDate) {
            this.instgram_link = instegram_link;
        }

        public void Adding(PopupEvent pop) {
            Array.Resize(ref this.pop, this.pop.Length + 1);
            this.pop[this.pop.Length - 1] = pop;
        }
        public void PrintPop() {
            if (pop == null) {
                Console.WriteLine("Pops are empty");
                return;
            }
            foreach (PopupEvent pop in this.pop) {
                pop.PrintEventDetails();
            }
        }
        public new void Print() {
            base.Print();
            PrintPop();
            Console.WriteLine(instgram_link+"\n");
        }

    }
}
