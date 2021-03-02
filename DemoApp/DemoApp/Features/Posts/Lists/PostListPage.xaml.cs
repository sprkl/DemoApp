using System;
using DemoApp.Commons.Views;
using Xamarin.Forms.Xaml;

namespace DemoApp.Features.Posts.Lists
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PostListPage : IView
    {
        public ViewType ViewType => ViewType.NavigationRoot;

        public PostListPage()
        {
            InitializeComponent();
        }
    }
}