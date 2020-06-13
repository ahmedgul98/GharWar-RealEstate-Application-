using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RealEstateAPIS1.Repositories;
namespace RealEstateAPIS1.Processors
{
    public class Usersecurity
    {

        public static bool Login(string username, string password)
        {

            return UserRepository.Login(username, password);

        }
        public static bool signup(string username, string password, string email, string ph)
        {
            //string uid = string.Format("{0:HH:mm:ss tt}", DateTime.Now);
            string uid = email;
            return UserRepository.signup(username, password,uid, email,  ph);

        }
        public static List<string> GetEmails()
        {
            return UserRepository.GetEmails();
        }

        public static string getIdByName(string uname)
        {
            return UserRepository.getIdByName(uname);
        }
    }
}