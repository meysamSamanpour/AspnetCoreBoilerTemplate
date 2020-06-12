using System;

namespace Meys.Common
{
    public class AddNewUserDto
    {
        public string name { get; set; }
        public string surname { get; set; }
        public string password { get; set; }
        public string confirmPassword { get; set; }        
    }
}
