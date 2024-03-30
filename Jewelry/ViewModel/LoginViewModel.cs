using Jewelry.Model;
using Jewelry.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Jewelry.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        //Fields
        private string _username;
        private SecureString _password;
        private string _errorMessage;
        private bool _isViewVisible = true;

        private IUserRepository _userRepository;

        //Properties
        public string Username 
        { 
            get => _username; 
            set
            {
                _username = value;
                OnPropetryChanged(nameof(Username));
            }
        }
        public SecureString Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropetryChanged(nameof(Password));
            }
        }
        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                OnPropetryChanged(nameof(ErrorMessage));
            }
        }
        public bool IsViewVisible
        {
            get => _isViewVisible;
            set
            {
                _isViewVisible = value;
                OnPropetryChanged(nameof(IsViewVisible));
            }
        }

        //Commands
        public ICommand LoginCommad { get; }
        public ICommand ShowPasswordCommad { get; }

        //Constructors
        public LoginViewModel()
        {
            _userRepository = new UserRepository();
            LoginCommad = new ViewModelCommand(ExecuteLoginCommand, CanExecuteLoginCommand);
        }

        private bool CanExecuteLoginCommand(object obj)
        {
            bool validData;

            if(string.IsNullOrWhiteSpace(Username) || Username.Length < 3 || 
                Password == null || Password.Length < 3)
                validData = false;
            else
                validData = true;

            return validData;
        }

        private void ExecuteLoginCommand(object obj)
        {
            var isValidUser = _userRepository.AuthenticateUser(new System.Net.NetworkCredential(Username, Password));
            if (isValidUser)
            {
                Thread.CurrentPrincipal = new GenericPrincipal(
                    new GenericIdentity(Username), null);
                IsViewVisible = false;
            }
            else
            {
                ErrorMessage = "* Invalid Username or Password";
            }
        }
    }
}
