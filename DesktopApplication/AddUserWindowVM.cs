using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace DesktopApplication
{
    public partial class AddUserWindowVM : ObservableObject
    {
        [ObservableProperty]
        public string firstname;

        [ObservableProperty]
        public string lastname;

        [ObservableProperty]
        public int age;

        [ObservableProperty]
        public string dateofbirth;

        [ObservableProperty]
        public string gpa;


        public User Stu_User { get; private set; }
        public Action CloseAction { get; internal set; }


        public AddUserWindowVM(User u)
        {
            Stu_User = u;

            firstname = Stu_User.FirstName;
            lastname = Stu_User.LastName;
            age = Stu_User.Age;
            dateofbirth = Stu_User.DateOfBirth;
            gpa = Stu_User.GPA;

        }
        public AddUserWindowVM()
        {

        }


        [RelayCommand]
        public void Save()
        {

            if (double.Parse(Gpa) < 0 || double.Parse(Gpa) > 4.0)
            {
                MessageBox.Show("Invalid GPA", "Error!");
                return;
            }
            if (Stu_User == null)
            {

                Stu_User = new User()
                {
                    FirstName = Firstname,
                    LastName = Lastname,
                    Age = Age,
                    DateOfBirth = dateOfBirth.ToString("MM/dd/yyyy"),
                    GPA = Gpa,
                    Image = "10.png"
                };
            }
            else
            {

                Stu_User.FirstName = Firstname;
                Stu_User.LastName = Lastname;
                Stu_User.Age = Age;
                Stu_User.DateOfBirth = dateOfBirth.ToString("MM/dd/yyyy");
                Stu_User.GPA = Gpa;

            }

            if (Stu_User.FirstName != null)
            {
                CloseAction();
            }
            Application.Current.MainWindow.Show();


        }

        public DateTime dateOfBirth = DateTime.Today;

        public DateTime DateOfBirth
        {
            get { return dateOfBirth; }
            set
            {
                dateOfBirth = value;
                OnPropertyChanged(nameof(DateOfBirth));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
