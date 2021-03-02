using System.Threading.Tasks;
using DemoApp.Commons.ViewModels;
using DemoApp.Commons.Views;

namespace DemoApp.Services.Navigations
{
    public interface INavigationService
    {
        public Task NavigateAsync<T>(bool animated = true) where T : IView;

        public Task NavigateAsync<T, TParams>(TParams parameters, bool animated = true)
            where T : IView<TParams>
            where TParams : IViewModelParams;
    }
}