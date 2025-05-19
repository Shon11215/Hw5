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

            RegisteredUser[] registeredUserAccounts = new RegisteredUser[]
            {
                new RegisteredUser("456123789", "michael@example.com","MikeSecure1", "Michael", "Rosen", "Mike", "054-9876543", new DateTime(2000, 1, 5)),
                new RegisteredUser("321789654", "rachel@example.com", "RachG1234","Rachel", "Gold", "Rachi", "053-5678910", new DateTime(1993, 7, 10))
            };

            BusinessUser[] businessClients = new BusinessUser[]
            {
                new BusinessUser("112233445", "fashionguru@example.com","FashionPass!", "Eli", "Adams", "EliA", "050-8765432", new DateTime(1987, 12, 1),"https://instagram.com/eliadams"),
                new BusinessUser("556677889", "trendsetter@example.com","Trend1234", "Noa", "Shalev", "NoaS", "052-3344556", new DateTime(1992, 6, 21),"https://instagram.com/noastyle")
            };

            string index = null;

            do
            {
                Console.WriteLine("Hey what do you want to do?\n\na - Add a new Clothing Item For a Certin user" +
                    "\nb - Add Popup or Clothingad\nc - Print all\nd - leave :)");
                Console.Write("Please enter your pick: ");
                index = Console.ReadLine();

                switch (index.ToLower())
                {
                    case "a":
                        AddItemToAccount(basicUsers, registeredUserAccounts, businessClients);
                        break;

                    case "b":
                        HandleAdOrPopup(registeredUserAccounts, businessClients);
                        break;

                    case "c":
                        PrintAllUsers(basicUsers, registeredUserAccounts, businessClients);
                        break;

                    default:
                        break;
                }



            } while (index.ToLower() != "d");
        }

        private static void PrintAllUsers(User[] basicUsers, RegisteredUser[] registeredUserAccounts, BusinessUser[] businessClients)
        {
            Console.Clear();
            foreach (User user in basicUsers)
                user.Print();
            foreach (RegisteredUser user in registeredUserAccounts)
                user.Print();
            foreach (BusinessUser user in businessClients)
                user.Print();
        }

        private static void HandleAdOrPopup(RegisteredUser[] registeredUserAccounts, BusinessUser[] businessClients)
        {
            Console.Clear();
            Console.WriteLine("Choose action:");
            Console.WriteLine("1 - Add popup event (BusinessUser)");
            Console.WriteLine("2 - Add clothing ad (RegisteredUser)");
            string subAction = Console.ReadLine();

            if (subAction == "1")
            {
                foreach (BusinessUser busUser in businessClients)
                    Console.WriteLine($"{busUser.FirstName} {busUser.LastName} - {busUser.UserId}");

                Console.Write("Enter user ID: ");
                string id = Console.ReadLine();
                bool found = false;
                for (int i = 0; i < businessClients.Length; i++)
                {
                    if (businessClients[i].UserId == id)
                    {
                        businessClients[i].Adding(NewPop(businessClients[i].UserId));
                        Console.WriteLine("Popup event added successfully!");
                        found = true;
                        break;
                    }
                }

                if (!found)
                    Console.WriteLine("User ID not found in business accounts.");
            }
            else if (subAction == "2")
            {
                foreach (RegisteredUser regUser in registeredUserAccounts)
                    Console.WriteLine($"{regUser.FirstName} {regUser.LastName} - {regUser.UserId}");

                Console.Write("Enter user ID: ");
                string id = Console.ReadLine();
                bool found = false;
                for (int i = 0; i < registeredUserAccounts.Length; i++)
                {
                    if (registeredUserAccounts[i].UserId == id)
                    {
                        RegisteredUser selectedUser = registeredUserAccounts[i];
                        found = true;

                        if (selectedUser.item.Length == 0)
                        {
                            Console.WriteLine("This user has no clothing items to create an ad for.");
                            break;
                        }

                        for (int j = 0; j < selectedUser.item.Length; j++)
                            Console.WriteLine($"{j + 1} - {selectedUser.item[j].Uint}: {selectedUser.item[j].Name}");

                        Console.Write("Choose item index: ");
                        int indexItem = int.Parse(Console.ReadLine());
                        if (indexItem >= 1 && indexItem <= selectedUser.item.Length)
                        {
                            selectedUser.Adding(delivery(selectedUser.UserId, selectedUser.item[indexItem - 1].Uint));
                            Console.WriteLine("Clothing ad created successfully!");
                        }
                        else
                        {
                            Console.WriteLine("Invalid item index.");
                        }
                        break;
                    }
                }

                if (!found)
                    Console.WriteLine("User ID not found in registered accounts.");
            }
            else
            {
                Console.WriteLine("Invalid action selected.");
            }
        }


        private static void AddItemToAccount(User[] basicUsers, RegisteredUser[] registeredUserAccounts, BusinessUser[] businessClients)
        {
            Console.Clear();
            Console.WriteLine("Select user type:");
            Console.WriteLine("1 - Basic User");
            Console.WriteLine("2 - Registered User");
            Console.WriteLine("3 - Business User");
            string userTypeChoice = Console.ReadLine();
            bool is_found = false;
            if (userTypeChoice == "1")
            {
                foreach (User basicUser in basicUsers)
                    Console.WriteLine($"{basicUser.FirstName} {basicUser.LastName} - {basicUser.UserId}");

                Console.Write("Enter user ID: ");
                string userId = Console.ReadLine();
                for (int i = 0; i < basicUsers.Length; i++)
                {
                    if (basicUsers[i].UserId == userId)
                    {
                        basicUsers[i].AddItem(initCloathingItem(basicUsers[i].UserId));
                        is_found = true;
                        break;
                    }
                }
            }
            else if (userTypeChoice == "2")
            {
                foreach (RegisteredUser regUser in registeredUserAccounts)
                    Console.WriteLine($"{regUser.FirstName} {regUser.LastName} - {regUser.UserId}");

                Console.Write("Enter user ID: ");
                string userId = Console.ReadLine();
                for (int i = 0; i < registeredUserAccounts.Length; i++)
                {
                    if (registeredUserAccounts[i].UserId == userId)
                    {
                        registeredUserAccounts[i].AddItem(initCloathingItem(registeredUserAccounts[i].UserId));
                        is_found = true;
                        break;
                    }
                }
            }
            else if (userTypeChoice == "3")
            {
                foreach (BusinessUser busUser in businessClients)
                    Console.WriteLine($"{busUser.FirstName} {busUser.LastName} - {busUser.UserId}");

                Console.Write("Enter user ID: ");
                string userId = Console.ReadLine();
                for (int i = 0; i < businessClients.Length; i++)
                {
                    if (businessClients[i].UserId == userId)
                    {
                        businessClients[i].AddItem(initCloathingItem(businessClients[i].UserId));
                        is_found = true;
                        break;
                    }

                }
            }
            if (!is_found)
                Console.WriteLine("invalid user ID\n");

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
