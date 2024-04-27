using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelephoneCompanyApp.Model
{
    public class Abonent
    {
        public int Id {  get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public List<PhoneNumber> PhoneNumbers { get; set; }
        public string Address { get; set; }
    }
}
