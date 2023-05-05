using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prac16zad4
{
    public class Country
    {
        public string Name { get; set; }
        public int Population { get; set; }

        public Country(string name, int population)
        {
            Name = name;
            Population = population;
        }

        public override string ToString()
        {
            return string.Format("{0,-15} {1,12:#,##0}", Name, Population);
        }
    }
}
