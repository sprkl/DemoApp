using System;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.ObjectModel;

namespace DemoApp.Models
{
    public class Post : ObservableObject
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }

        public long UserId { get; set; }

        private bool _read;

        public bool Read
        {
            get { return _read; }
            set { SetProperty(ref _read, value); }
        }

        public AsyncCommand OnApproveCommand { get; set; }

        public Post()
        {
            OnApproveCommand = new AsyncCommand(OnApprove, allowsMultipleExecutions : false);
        }

        private async Task OnApprove()
        {
            await Task.Delay(250);
            Read = true;
        }
    }
}