using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationPracticePOM
{
    class EncodePassword
    {
        public void EncodingPassword()
        {
            string password = "abcd123";

            var passwordInBytes = Encoding.UTF8.GetBytes(password);
            string encodedPassword = Convert.ToBase64String(passwordInBytes);
        }
        
    }
}
