using System.Data;
using System.IO;
using System.Windows.Controls;
using System.Windows.Input;
using TelephoneCompanyApp.Model.Data;

namespace TelephoneCompanyApp.Model
{
    class DataWorker
    {
        //получить всех абонентов
        public static List<Abonent> GetAllAbonents()
        {
            using(ApplicationContext db = new ApplicationContext())
            {
                var result = db.Abonents.ToList();
                return result;
            }
        }
        //получить список абонентов по номеру
        public static List<Abonent> GetAbonentsByNumber(string number)
        {
            using(ApplicationContext db = new ApplicationContext())
            {
                List<Abonent> result = new List<Abonent>();
                foreach(Abonent ab in GetAllAbonents())
                {
                    bool res = ab.PhoneNumber.Contains(number);
                    if (res)
                    {
                        result.Add(ab);
                    }
                }
                return result;
            }
        }
        //создать абонента
        public static string CreateAbonent(string fullName, string address, string number)
        {
            string result = "Абонент уже существует!";
            using(ApplicationContext db = new ApplicationContext())
            {
                bool checkIsExist = db.Abonents.Any(ab => ab.FullName == fullName && ab.Address == address && ab.PhoneNumber == number);
                if (!checkIsExist)
                {
                    Abonent abonent = new Abonent 
                    { 
                        FullName = fullName, 
                        PhoneNumber = number, 
                        Address = address
                    };
                    db.Abonents.Add(abonent);
                    db.SaveChanges();
                    result = "Абонент добавлен!";
                }
                return result;
            }
        }
        //создать адрес
        public static string CreateAddress(string street, string houseNumber, Abonent abonent)
        {
            string result = "Адрес уже существует!";
            using (ApplicationContext db = new ApplicationContext())
            {
                bool checkIsExist = db.Addresses.Any(ad => ad.Street == street 
                && ad.HouseNumber == houseNumber);
                if (!checkIsExist)
                {
                    Address address = new Address 
                    { 
                        Street = street, 
                        HouseNumber = houseNumber, 
                        AbonentId = abonent.Id 
                    };
                    db.Addresses.Add(address);
                    db.SaveChanges();
                    result = "Адрес добавлен!";
                }
                return result;
            }
        }

        //создать телефонный номер
        public static string CreatePhoneNumber(string number, Abonent abonent)
        {
            string result = "Номер уже существует!";
            using (ApplicationContext db = new ApplicationContext())
            {
                bool checkIsExist = db.PhoneNumbers.Any(pN => pN.Number == number);
                if (!checkIsExist)
                {
                    PhoneNumber phoneNumber = new PhoneNumber 
                    { 
                        Number = number, 
                        AbonentId = abonent.Id
                    };
                    db.PhoneNumbers.Add(phoneNumber);
                    db.SaveChanges();
                    result = "Телефонный номер добавлен!";
                }
                return result;
            }
        }
        //создать улицу
        public static string CreateStreet(string name)
        {
            string result = "Улица уже существует!";
            using (ApplicationContext db = new ApplicationContext())
            {
                bool checkIsExist = db.Streets.Any(ab => ab.Name == name);
                if (!checkIsExist)
                {
                    Streets streets = new Streets { Name = name };
                    db.Streets.Add(streets);
                    db.SaveChanges();
                    result = "Абонент добавлен!";
                }
                return result;
            }
        }

        //удалить абонента

        //удалить адрес

        //удалить телефонный номер

        //удалить улицу

        //редактировать абонента

        //редактировать адрес

        //редактировать телефонный номер

        //редактировать улицу
    }
}
