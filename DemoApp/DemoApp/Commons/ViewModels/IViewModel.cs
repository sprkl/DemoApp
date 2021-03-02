using System.Threading.Tasks;

namespace DemoApp.Commons.ViewModels
{
    public interface IViewModel
    {
        Task InitializeAsync();
    }

    public interface IViewModel<TParams> where TParams : IViewModelParams
    {
        Task InitializeAsync(TParams @params);
    }
}