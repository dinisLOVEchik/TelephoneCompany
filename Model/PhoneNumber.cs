using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelephoneCompanyApp.Model
{
    public class PhoneNumber
    {
        public int Id { get; set; }
        public int AbonentId { get; set; }
        public PhoneType Type { get; set; }
        public string Number { get; set; }
        public Abonent abonent { get; set; }
    }
    public enum PhoneType
    {
        Home,
        Work,
        Mobile
    }
}
