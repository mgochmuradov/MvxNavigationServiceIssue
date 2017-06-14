using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;

namespace MvxNewNavigation.Core.ViewModels
{
    public class SecondViewModel : MvxViewModel
    {
        private static int _times = 0;
        public SecondViewModel() // <- ViewModel is being constructed TWICE
        {
            _times++;
            Title = "From Constructor " + _times;
        }

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public override Task Initialize()
        {
            // Called on a different instance than the one that is bound to view
            Title = "From Initializer";
            return base.Initialize();
        }
    }
}