using DemoApp.Commons.ViewModels;

namespace DemoApp.Commons.Views
{
    public interface IView
    {
        ViewType ViewType { get; }
        object BindingContext { get; }
    }
    
    public interface IView<TParams> where TParams : IViewModelParams
    {
        ViewType ViewType { get; }
        object BindingContext { get; }
    }
}