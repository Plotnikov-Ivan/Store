using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store2
{
    internal class Load
    {


        string Name, Date;

        int Id, Square, Cost = 0;

        public Load(string new_name, string new_date, int new_id, int new_square, int new_cost)
        {
            Id = new_id;
            Date = new_date;
            Name = new_name;
            Square = new_square;
            Cost = new_cost;            
        }

        public string GetName { get { return Name; } /*set { Name = value; }*/ }

        public string GetDate { get { return Date; } }

        public int GetId { get { return Id; } }

        public int GetSquare { get { return Square; } } 

        public int GetCost { get { return Cost; } }

    }
}
