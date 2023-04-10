using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store2
{
    internal class Store
    {

        private LinkedList<Load> load = new LinkedList<Load>();
        private LinkedList<Load> load2 = new LinkedList<Load>();


        public LinkedList<Load> get_list()
        {
            return load;
        }

        public LinkedList<Load> get_list2()
        {
            return load2;
        }

        public void add_load(Load t, int id)
        {  
          load.AddLast(t);           
        }

        public void delete_load(int id)
        {
            foreach (Load l in load)
            {
                if (l.GetId == id)
                {
                    load.Remove(l);
                    break;
                }
            }
        }

        public void find_loads(int id)
        {
            foreach (Load l in load)
            {
                if (l.GetId == id)
                {
                    load2.AddLast(l);
                }

            }
        }

        public void clear_list2()
        {
            load2.Clear();
        }

        public int MoneyCount(int id)
        {
            int sum = 0;
            DateTime date = new DateTime();
            TimeSpan date1 = new TimeSpan();
            foreach (Load l in load)
            {
                if (l.GetId == id)
                {
                    
                    date = Convert.ToDateTime(l.GetDate);
                    date1 = DateTime.Today.Subtract(date);

                    if( l.GetSquare < 2)
                    {
                        sum += 50 * Convert.ToInt32(date1.Days);
                    }else
                    {
                        sum += 100 * Convert.ToInt32(date1.Days);
                    }
                }
            }

            return sum;
        }
    }
}
