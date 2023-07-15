using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopApplication
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string DateOfBirth { get; set; }
        public string GPA { get; set; }
        public string Image { get; set; }

        public string ImageURL
        {
            get { return $"/Images/{Image}"; }
        }

        public User(string firstName, string lastName, int age, string dateOfBirth, string gpa, string image)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            DateOfBirth = dateOfBirth;
            GPA = gpa;
            Image = image;
        }

        public User()
        {

        }
    }
}
