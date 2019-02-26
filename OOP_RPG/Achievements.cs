using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_RPG
{
    public class Achievements
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        public bool Achieved { get; set; }

        public Achievements(string id, string name, string date)
        {
            ID = id;
            Name = name;
            Date = date;
            Achieved = false;
        }

        public string ShowInfo()
        {
            return ($"Achivement Name: {Name} Date achieved: {Date}");
        }
    }
}
