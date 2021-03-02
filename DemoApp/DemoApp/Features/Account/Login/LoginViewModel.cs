using DemoApp.Commons.ViewModels;
using DemoApp.Features.Posts.Lists;
using DemoApp.Services.Navigations;
using System;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.ObjectModel;

namespace DemoApp.Features.Account.Login
{
    public class LoginViewModel : ObservableObject, IViewModel
    {
        private INavigationService _navigationService;

        private string _email;

        public string Email
        {
            get { return _email; }
            set
            {
                SetProperty(ref _email, value);
                OnLoginSubmitCommand.ChangeCanExecute();
            }
        }

        private string _password;

        public string Password
        {
            get { return _password; }
            set
            {
                SetProperty(ref _password, value);
                OnLoginSubmitCommand.ChangeCanExecute();
            }
        }

        private bool _isLoading;

        public bool IsLoading
        {
            get { return _isLoading; }
            set { SetProperty(ref _isLoading, value); }
        }


        public Task InitializeAsync()
        {
            return Task.CompletedTask;
        }

        public AsyncCommand OnLoginSubmitCommand { get; }

        public LoginViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            OnLoginSubmitCommand = new AsyncCommand(
                OnLoginSubmit,
                canExecute: CanSubmitLogin,
                allowsMultipleExecutions: false);
        }

        private async Task OnLoginSubmit()
        {
            IsLoading = true;
            await Task.Delay(5000);

            await _navigationService.NavigateAsync<PostListPage>();
            IsLoading = false;
        }

        public bool CanSubmitLogin(object obj) =>
            !string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(Password);
    }
}
