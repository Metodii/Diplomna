using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MainPageMobile.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public Action DisplayInvalidLoginPrompt;
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        private string email;
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Email"));
            }
        }
        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Password"));
            }
        }
        public ICommand SubmitCommand { protected set; get; }
        public LoginViewModel()
        {
            _studentFirstName = "Gosho";
            SubmitCommand = new Command(OnSubmit);
        }
        public void OnSubmit()
        {
            if (email != "metodi.pandurov@gmail.com" || password != "secret")
            {
                DisplayInvalidLoginPrompt();
            }
        }


        private string _studentFirstName;
        public String StudentFirstName 
        {
            get
            {
                return _studentFirstName;
            }
            set
            {
                _studentFirstName = value;
                PropertyChanged(this, new PropertyChangedEventArgs("StudentFirstName"));
            }
        }

    }
}
