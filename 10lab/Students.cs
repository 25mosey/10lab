using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10lab
{
    internal class Students
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public int BornDate { get; set; }
        public int Marks { get; set; }
        public int Passmark { get; set; }

        public override string? ToString()
        {
            return Name + "\n" + Surname + "\n" + Patronymic + "\n" + Address + "\n" +
                BornDate.ToString() + "\n" + Marks + "\n" + Passmark + "\n";
        }
    }
}
