using DemoApp.Commons.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DemoApp.Features.Account.Login
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : IView
    {
        public ViewType ViewType => ViewType.Root;

        public LoginPage()
        {
            InitializeComponent();
        }

        private void Entry_Completed(object sender, EventArgs e)
        {
            Password_Entry.Focus();
        }
    }
}