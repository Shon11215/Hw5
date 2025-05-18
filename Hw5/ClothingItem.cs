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
        static uint _idCounter = 1000;

        public ClothingItem(string user_id,  string name, string is_favorite, string type, string brand, string is_casual) : this(name, is_casual)
        {
            Uint = IdCounter++;
            this.user_id = user_id;
            if (is_favorite.ToLower() == "yes" || is_favorite.ToLower() == "true" || is_favorite == "1")
            {
                this.is_favorite = true;
            }
            this.brand = brand;
            this.type = type;
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
            Console.WriteLine($"• Item ID:         {this.Uint}");
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
                if (value <= 0)
                    throw new FormatException("Price has to be 0 or higher.");
                cost = value;
            }
        }
        public string Color
        {
            get => color;
            set
            {
                if (value[0] != '#' || value.Length != 7 || !IsValidColor((string)value))
                {
                    throw new ArgumentException("Invalid Color");
                }
                else
                {
                    color = value;
                }
            }
        }


        internal Usage Usage
        {
            get => usage;
            set
            {
                int num_value = (int)value;
                if (num_value < 1 || num_value > 3)
                    throw new FormatException("Usage value needs to be between 1 and 3.");
                usage = (Usage)value;
            }
        }

        internal Sizes Size
        {
            get => _size;
            set
            {
                if ((int)value < 1 || (int)value > 6)
                {
                    throw new FormatException("Size value has to be between 1 and 6");
                }
                _size = value;
            }
        }
        public string User_id
        {
            get => user_id;
            set => user_id = value;
        }
        public static uint IdCounter { get => _idCounter; set => _idCounter = value; }
        public uint Uint { get => _uint; set => _uint = value; }

        static bool IsValidColor(string color)
        {
            for (int i = 1; i < color.Length; i++)
            {
                if (!char.IsDigit(color[i]) && (color[i] < 'a' || color[i] > 'f') && (color[i] < 'A' || color[i] > 'F'))
                    return false;
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
        public void SetSeassons(int[] season_num)
        {
            string[] seasons = new string[] { "summer", "spring", "fall", "winter" };
            if (season_num.Length < 1 & season_num.Length > 4)
                throw new ArgumentException("seassons should be filled up to 4 seassons at most or 1 at least");
            string[] selected = new string[season_num.Length];
            for (int i = 0; i < season_num.Length; i++)
            {
                if (season_num[i] < 1 || season_num[i] > 4)
                    throw new ArgumentException("seassons are repsented in numbers between 1 and 4");
                for (int j = 0; j < i; j++)
                {
                    if (season_num[i] == season_num[j])
                        throw new ArgumentException("only one seasson need to be repsented or else no kabab");
                }
                selected[i] = seasons[season_num[i] - 1];
            }
            this.seasons = selected;
        }
       
    }

}
