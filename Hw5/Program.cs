using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Hw5
{
    internal class Program
    {

        static void Main(string[] args)
        {


            User[] basicUsers = new User[]
            {
                new User("123456789", "David", "Levi", "Dave", "050-1234567", new DateTime(1995, 4, 23)),
                new User("987654321", "Sara", "Cohen", "Sari", "052-7654321", new DateTime(1998, 9, 15))
            };

            // מערך משתמשים רשומים
            RegisteredUser[] registeredUserAccounts = new RegisteredUser[]
            {
                new RegisteredUser("456123789", "michael@example.com","MikeSecure1", "Michael", "Rosen", "Mike", "054-9876543", new DateTime(2000, 1, 5)),
                new RegisteredUser("321789654", "rachel@example.com", "RachG1234","Rachel", "Gold", "Rachi", "053-5678910", new DateTime(1993, 7, 10))
            };

            // מערך משתמשים עסקיים
            BusinessUser[] businessClients = new BusinessUser[]
            {
                new BusinessUser("112233445", "fashionguru@example.com","FashionPass!", "Eli", "Adams", "EliA", "050-8765432", new DateTime(1987, 12, 1),"https://instagram.com/eliadams"),
                new BusinessUser("556677889", "trendsetter@example.com","Trend1234", "Noa", "Shalev", "NoaS", "052-3344556", new DateTime(1992, 6, 21),"https://instagram.com/noastyle")
            };

            basicUsers[0].AddItem( UserClothingItem(basicUsers[0].UserId));
            basicUsers[0].AddItem( UserClothingItem(basicUsers[0].UserId));
            registeredUserAccounts[0].AddItem( UserClothingItem(registeredUserAccounts[0].UserId));
            registeredUserAccounts[0].AddItem( UserClothingItem(registeredUserAccounts[0].UserId));
            registeredUserAccounts[0].Adding(delivery("456123789", registeredUserAccounts[0].item[0].Uint));
            registeredUserAccounts[0].Adding(delivery("456123789", registeredUserAccounts[0].item[1].Uint));
            businessClients[0].AddItem(UserClothingItem(businessClients[0].UserId));
            businessClients[0].AddItem(UserClothingItem(businessClients[0].UserId));
            businessClients[0].Adding(NewPop("112233445"));


            int item_index = 0;
            string index = null, user_id = "temp";

            do
            {
                Console.WriteLine("Hey what do you want to do?\n\na - Add a new Clothing Item\nb - See all your wardrobe\nc - Exit\n");
                Console.Write("Please enter your pick: ");
                index = Console.ReadLine();

                switch (index.ToLower())
                {
                    case "a":
                        foreach (User user in basicUsers)
                        {
                            user.Print();
                        }
                        foreach (RegisteredUser user in registeredUserAccounts)
                        {
                            user.Print();
                        }
                        foreach (BusinessUser user in businessClients)
                        {
                            user.Print();
                        }
                        break;
                    case "b":
                        
                        break;
                    case "c":
                        break;

                    default:
                        break;
                }

            } while (index.ToLower() != "c");
        }

        static ClothingItem UserClothingItem(string user_id)
        {
            ClothingItem item = new ClothingItem(user_id, "shon", "yes", "Shirt", "Gucci", "no");
            item.Color = "#123123";
            item.Size = (Sizes)1;
            item.Usage = (Usage)1;
            item.Cost = 140;
            item.SetSeassons(new int[] { 1, 2 });
            return item;

        }

        static ClothingAd delivery(string user_id, uint _uint)
        {
            Console.WriteLine("please enter the adress u wish to deliver to");
            ClothingAd ad = new ClothingAd(_uint, user_id, Console.ReadLine());
            Console.WriteLine("Your item was delivered!");
            return ad;
        }
        static PopupEvent NewPop(string user_id)
        {
            Console.Write("please enter a name for the event: ");
            string name = Console.ReadLine();
            Console.Write("please enter the adrees of the event: ");
            string adress = Console.ReadLine();
            Console.Write("Enter start time (e.g., dd/MM/yyyy): ");
            DateTime start_event = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter end time (e.g., dd/mm/yyyy): ");
            DateTime end_event = DateTime.Parse(Console.ReadLine());
            PopupEvent po = new PopupEvent(user_id, name, adress, start_event, end_event);
            return po;
        }


        static ClothingItem initCloathingItem(string user_id)
        {


            Console.Write("Please enter the name of the item: ");
            string name = Console.ReadLine();

            Console.Write("\nPlease enter Yes/no for wether the item is favorite or not: ");
            string is_favorite = (Console.ReadLine());

            Console.Write("\nPlease enter the type of your item: ");
            string type = (Console.ReadLine());

            Console.Write("\nPlease enter the brand name: ");
            string brand = (Console.ReadLine());

            Console.Write("\nIs the item Casual? yes/no: ");
            string is_casual = (Console.ReadLine());

            ClothingItem item = new ClothingItem(user_id, name, is_favorite, type, brand, is_casual);

            while (true)
            {
                try
                {
                    Console.Write("\nPlease enter the color code of the item: ");
                    item.Color = Console.ReadLine();
                    break;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }
            }
            while (true)
            {
                try
                {
                    Console.Write("\n1) none\n2) average\n3) high\nPlease enter the amout of usage the item has: ");
                    item.Usage = (Usage)int.Parse(Console.ReadLine());
                    break;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }
            }
            while (true)
            {
                try
                {
                    Console.Write("\nPlease enter the cost of the item: ");
                    item.Cost = int.Parse(Console.ReadLine());
                    break;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }
            }
            while (true)
            {
                try
                {
                    Console.WriteLine("please enter seassons you wish to associate it to\n");
                    Console.WriteLine("1) Summer ,2)Spring, 3)Fall , 4)Winter\n");
                    Console.WriteLine("Enter from 1 up untill 4 numbers with spaces inbetween\n");
                    string[] num_to_seasson = (Console.ReadLine()).Split(' ');
                    int[] seasons_to_pass = new int[num_to_seasson.Length];
                    for (int i = 0; i < num_to_seasson.Length; i++)
                    {
                        seasons_to_pass[i] = int.Parse(num_to_seasson[i]);
                    }
                    item.SetSeassons(seasons_to_pass);
                    break;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }
            }
            while (true)
            {
                try
                {
                    Console.Write("\nPlease enter the size (S,M,L,etc..): ");
                    item.Size = (Sizes)int.Parse((Console.ReadLine()));
                    break;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }
            }

            return item;
        }
    }
}
