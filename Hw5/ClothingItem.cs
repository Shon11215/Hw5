using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Hw5
{
    enum Sizes
    {
        S = 1, M, L, XL, XXL, OS
    }
    enum Usage
    {
        NotInUse = 1, InSomeUses, MostlyUsed
    }
    internal class ClothingItem
    {
        Usage usage;
        Sizes _size;
        int cost;
        uint _uint;
        string[] seasons;
        string user_id, name, color, type, brand;
        bool is_favorite, is_casual;
        static uint _idCounter= 1000;

        public ClothingItem(string user_id, string color, string name, string[] seasson, string is_favorite, int usage, string type, string brand, int cost, int _size, string is_casual) : this(name, is_casual)
        {
            _uint = IdCounter++;
            this.user_id = user_id;
            this.Cost = cost;
            this.Usage = (Usage)usage;
            this.Color = color;
            this.Size = (Sizes)_size;
            this.seasons = seasson;
            if (is_favorite.ToLower() == "yes" || is_favorite.ToLower() == "true" || is_favorite == "1")
            {
                this.is_favorite = true;
            }
            //this.name = name;
            this.brand = brand;
            this.type = type;
            //SetIsCasual(is_casual);

        }

        public ClothingItem() { }
        public ClothingItem(string name, string is_casual)
        {
            this.name = name;
            SetIsCasual(is_casual);
        }
        public void Print()
        {
            Console.WriteLine("╔══════════════════════════════════════╗");
            Console.WriteLine($"║     Clothing Item Details ({this.name})       ║");
            Console.WriteLine("╚══════════════════════════════════════╝");
            Console.WriteLine($"• User ID:         {this.user_id}");
            Console.WriteLine($"• Item ID:         {this._uint}");
            Console.WriteLine($"• Name:            {this.name}");
            Console.WriteLine($"• Color:           {this.Color}");
            Console.WriteLine($"• Favorite:        {(this.is_favorite ? "Yes" : "No")}");
            Console.WriteLine($"• Usage:           {this.Usage}");
            Console.WriteLine($"• Type:            {this.type}");
            Console.WriteLine($"• Brand:           {this.brand}");
            Console.WriteLine($"• Cost:            {this.Cost}$");
            Console.WriteLine($"• Size:            {this.Size}");
            Console.WriteLine($"• Casual:          {(this.is_casual ? "Yes" : "No")}");
            Console.WriteLine($"• Seasons:         {string.Join(", ", seasons)}\n");
        }


        public int Cost
        {
            get => cost;
            set
            {
                while (value <= 0)
                {
                    Console.Write("Please enter a postive price tag: ");
                    value = int.Parse(Console.ReadLine());
                }
                cost = value;
            }
        }
        public string Color
        {
            get => color;
            set
            {
                while (true)
                {
                    if (value[0] != '#')
                    {
                        Console.WriteLine("Please start the color with # : ");
                    }
                    else if (value.Length != 7)
                    {
                        Console.WriteLine("For the color please enter a 7 digits : ");
                    }
                    else if (!IsValidColor((string)value))
                    {
                        Console.WriteLine("For the color Please enter only numbers or a-f chars");
                    }
                    else
                    {
                        color = value;
                        break;

                    }
                    value = Console.ReadLine();
                }
            }
        }

        internal Usage Usage
        {
            get => usage;
            set
            {
                int num_value = (int)value;
                while (num_value < 1 || num_value > 3)
                {
                    Console.Write("Please enter a number between 1-3 for the usage rate: ");
                    num_value = int.Parse(Console.ReadLine());
                }
                usage = (Usage)value;
            }
        }

        internal Sizes Size
        {
            get => _size;
            set => _size = value;
        }
        public string User_id
        {
            get => user_id;
            set => user_id = value;
        }
        public static uint IdCounter { get => _idCounter; set => _idCounter=value; }

        static bool IsValidColor(string color)
        {
            for (int i = 1; i < color.Length; i++)
            {
                if (!char.IsDigit(color[i]) && (color[i] < 'a' || color[i] > 'f') && (color[i] < 'A' || color[i] > 'F')) return false;
            }
            return true;
        }
        public void SetIsCasual(string is_casual)
        {
            if (is_casual.ToLower() == "yes" || is_casual.ToLower() == "true" || is_casual == "1")
            {
                this.is_casual = true;
            }
        }
        public bool GetIsCasual()
        {
            return is_casual;
        }

    }
}
