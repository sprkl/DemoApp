using DemoApp.Commons.Views;
using Xamarin.Forms.Xaml;

namespace DemoApp.Posts.Details
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PostDetailsPage : IView<PostDetailsViewModelParams>
    {        
        public ViewType ViewType => ViewType.Navigation;

        public PostDetailsPage()
        {
            InitializeComponent();
        }
    }
}