using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hw5
{
    internal class Program
    {

        static void Main(string[] args) {
            User[] users = new User[]{
             new User("123456789", "user1@example.com", "Pass123", "John",
             "Doe", "Johnny", "123-456-7890", new DateTime(1990, 5, 12)),

             new User("987654321", "user2@example.com", "Secure456", "Jane",
             "Smith", "Janie", "987-654-3210", new DateTime(1985, 8, 25)),

             new User("951753852", "user3@example.com", "Strong789", "Alex",
             "Brown", "Al", "555-666-7777", new DateTime(1998, 12, 3))};

            ClothingItem[] clothes = new ClothingItem[0];
            int item_index = 0, item_counter = 0;
            string index = null, user_id = Login(users);

            do {
                Console.WriteLine("Hey what do you want to do?\n\na - Add a new Clothing Item\nb - See all your wardrobe\nc - Exit\n");
                Console.Write("Please enter your pick: ");
                index = Console.ReadLine();

                switch (index.ToLower()) {
                    case "a":
                        Array.Resize(ref clothes, item_index + 1);
                        clothes[item_index++] = initCloathingItem();
                        break;
                    case "b":
                        for (int i = 0; i < item_index; i++) {
                            if (user_id == clothes[i].User_id) {
                                clothes[i].Print();
                                item_counter++;
                            }
                        }
                        if (item_counter == 0) {
                            Console.WriteLine("The user does not have items.. please enter items to the closet :)\n");
                        }
                        break;
                    case "c":
                        break;

                    default:
                        break;
                }

            } while (index.ToLower() != "c");
        }
        static string Login(User[] users) {
            while (true) {
                Console.Write("Please enter your email: ");
                string email = Console.ReadLine();
                Console.Write("Enter your password: ");
                string password = Console.ReadLine();

                for (int i = 0; i < users.Length; i++) {
                    if (users[i].Email == email && users[i].Password == password) {
                        Console.WriteLine($"Welcome {users[i].FirstName}");
                        return users[i].UserId;
                    }
                }
                Console.WriteLine("Incorrect Username or Password, Please enter again\n");
            }
        }
        static ClothingItem initCloathingItem() {
            string[] season_list = new string[4] { "summer", "spring", "winter", "fall" };
            int season_counter;
            Console.Write("\nPlease enter the user ID: ");
            string user_id = Console.ReadLine();

            Console.Write("Please enter the name of the item: ");
            string name = Console.ReadLine();

            Console.Write("\nPlease enter the color code of the item: ");
            string color = Console.ReadLine();

            Console.Write("\n1) none\n2) average\n3) high\nPlease enter the amout of usage the item has: ");
            int usage_status = int.Parse(Console.ReadLine());

            Console.Write("\nPlease enter the cost of the item: ");
            int cost = int.Parse(Console.ReadLine());

            //Checking amount of seasons
            do {
                Console.Write("\nPlease enter the amount of seasons your item fits between 1-4: ");
                season_counter = int.Parse(Console.ReadLine());
            } while (season_counter < 1 || season_counter > 4);

            string[] seasons_to_pass = new string[season_counter];
            int[] season_index = new int[season_counter];

            Console.Write("\n1) summer\n2) spring\n3) winter\n4) fall\nPlease enter the number for the following seassons this cloathing is attenable for:");
            //We check if the entered inputs for the seasons alredy exists if it does we enter again if not we enter to the array
            for (int i = 0; i < season_counter; i++) {
                int curr_season = int.Parse(Console.ReadLine());
                if (season_index.Contains(curr_season)) {
                    Console.WriteLine($"{season_list[curr_season - 1]} Is already in please enter a diff season");
                    i--;
                    continue;
                }
                season_index[i] = curr_season;
                seasons_to_pass[i] = season_list[curr_season - 1];
            }

            Console.Write("\nPlease enter Yes/no for wether the item is favorite or not: ");
            string is_favorite = (Console.ReadLine());

            Console.Write("\nPlease enter the type of your item: ");
            string type = (Console.ReadLine());

            Console.Write("\nPlease enter the brand name: ");
            string brand = (Console.ReadLine());

            Console.Write("\nIs the item Casual? yes/no: ");
            string is_casual = (Console.ReadLine());

            Console.Write("\nPlease enter the size (S,M,L,etc..): ");
            int size = int.Parse((Console.ReadLine()));

            ClothingItem item = new ClothingItem(user_id, color, name, seasons_to_pass, is_favorite, usage_status, type, brand, cost, size, is_casual);
            return item;
        }
    }
}
