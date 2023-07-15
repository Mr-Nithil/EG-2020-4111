using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DesktopApplication
{
    public partial class MainWindowVM : ObservableObject
    {
        [ObservableProperty]
        public ObservableCollection<User> users;

        [ObservableProperty]
        public User selectedUser;

        public MainWindowVM()
        {

            users = new ObservableCollection<User>
            {
                new User("Tom", "Brown", 21, "03/18/2002", "3.45", "1.png"),
                new User("Sam", "Green", 25, "09/13/1998", "3.87", "3.png"),
                new User("Anne", "Tammy", 23, "06/27/2000", "2.98", "6.png")

            };

        }

        public static void CloseMainWindow()
        {

        }

        [RelayCommand]
        public void AddStudent()
        {
            var w = new AddUserWindowVM();
            AddUserWindow window = new(w);
            window.ShowDialog();

            if (w.Stu_User.FirstName != null)
            {
                Users.Add(w.Stu_User);
            }
        }

        [RelayCommand]
        public void ExecuteEditStudentCommand()
        {
            if (SelectedUser != null)
            {
                var w = new AddUserWindowVM(SelectedUser);
                var window = new AddUserWindow(w);

                window.ShowDialog();

                int index = Users.IndexOf(SelectedUser);
                Users.RemoveAt(index);
                Users.Insert(index, w.Stu_User);

            }
            else
            {
                MessageBox.Show("Select a User to Edit.", "Error!");
            }
        }



        [RelayCommand]
        public void Delete()
        {
            if (SelectedUser != null)
            {
                Users.Remove(SelectedUser);
                MessageBox.Show("Deletion successful!", "Deleted! \a ");

            }
            else
            {
                MessageBox.Show("Select a User to Delete.", "Error!");


            }
        }
    }
}
