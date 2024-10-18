using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace rku_system
{
    public class enc
    {
        //String Password;
        //enc(string password)
        //{
        //    Password = password;
        //}

        public string Enc(String Password)
        {
            byte[] storePass = ASCIIEncoding.ASCII.GetBytes(Password);
            String encPass = Convert.ToBase64String(storePass);
            return encPass; 
        }
        //public String Dec(String Password)
        //{
           
        //    byte[] encpass = Convert.FromBase64String(Password);
        //    String dec  = ASCIIEncoding.ASCII.GetString(encpass);
        //    return dec;
        //}
    }
}