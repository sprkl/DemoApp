using System;
using System.Threading.Tasks;
using DemoApp.Commons.ViewModels;
using DemoApp.Commons.Views;
using Xamarin.Forms;

namespace DemoApp.Services.Navigations
{
    public class NavigationService : INavigationService
    {
        public Task NavigateAsync<T>(bool animated = true) where T : IView
        {
            var view = Activator.CreateInstance<T>();
            UpdateNativationStack(view as Page, view.ViewType);

            if (view.BindingContext is IViewModel vm)
                return vm.InitializeAsync();
            
            return Task.CompletedTask;
        }

        public Task NavigateAsync<T, TParams>(TParams parameters, bool animated = true) 
            where T : IView<TParams>
            where TParams : IViewModelParams 
        {
            var view = Activator.CreateInstance<T>();
            UpdateNativationStack(view as Page, view.ViewType);
            
            if (view.BindingContext is IViewModel<TParams> vm)
                return vm.InitializeAsync(parameters);
            
            return Task.CompletedTask;
        }

        private void UpdateNativationStack(Page page, ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.Root:
                    App.Current.MainPage = page;
                    break;
                
                case ViewType.Navigation:
                    App.Current.MainPage.Navigation.PushAsync(page);
                    break;
                
                case ViewType.NavigationRoot:
                    App.Current.MainPage = new NavigationPage(page);
                    break;
                
                case ViewType.NavigationModal:
                    App.Current.MainPage.Navigation.PushModalAsync(page);
                    break;
                
                default:
                    throw new ArgumentOutOfRangeException(nameof(viewType), viewType, null);
            }
        }
    }
}