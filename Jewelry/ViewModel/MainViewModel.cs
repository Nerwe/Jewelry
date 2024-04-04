using FontAwesome.Sharp;
using Jewelry.Model;
using Jewelry.Repositories;
using System.Threading;
using System.Windows.Input;

namespace Jewelry.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        //Fields
        private UserAccountModel _currentUserAccount;
        private IUserRepository _userRepository;
        private ViewModelBase _currentChildView;
        private string _caption;
        private IconChar _icon;

        //Properties
        public UserAccountModel CurrentUserAccount
        {
            get => _currentUserAccount;
            set
            {
                _currentUserAccount = value;
                OnPropertyChanged(nameof(CurrentUserAccount));
            }
        }
        public ViewModelBase CurrentChildView
        {
            get => _currentChildView;
            set
            {
                _currentChildView = value;
                OnPropertyChanged(nameof(CurrentChildView));
            }
        }
        public string Caption
        {
            get => _caption;
            set
            {
                _caption = value;
                OnPropertyChanged(nameof(Caption));
            }
        }
        public IconChar Icon
        {
            get => _icon;
            set
            {
                _icon = value;
                OnPropertyChanged(nameof(Icon));
            }
        }

        //Commands
        public ICommand ShowHomeViewCommand { get; }
        public ICommand ShowAnalyzeViewCommand { get; }

        public MainViewModel()
        {
            _userRepository = new UserRepository();
            CurrentUserAccount = new UserAccountModel();

            //Initialize commands
            ShowHomeViewCommand = new ViewModelCommand(ExecuteShowHomeCommand);
            ShowAnalyzeViewCommand = new ViewModelCommand(ExecuteShowAnalyzeCommand);

            //Default view
            ExecuteShowHomeCommand(null);

            LoadCurrentUserData();
        }

        private void ExecuteShowAnalyzeCommand(object obj)
        {
            CurrentChildView = new AnalyzeViewModel();
            Caption = "Analyze";
            Icon = IconChar.ListUl;
        }
        private void ExecuteShowHomeCommand(object obj)
        {
            CurrentChildView = new HomeViewModel();
            Caption = "Dashboard";
            Icon = IconChar.Home;
        }

        private void LoadCurrentUserData()
        {
            var user = _userRepository.GetByUsername(Thread.CurrentPrincipal.Identity.Name);
            if (user != null)
            {
                CurrentUserAccount.Username = user.Username;
                CurrentUserAccount.DisplayName = $"{user.Username}";
                CurrentUserAccount.ProfilePicture = null;
            }
            else
            {
                CurrentUserAccount.DisplayName = "Invalid username";
            }
        }
    }
}
