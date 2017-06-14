using System.Threading.Tasks;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;

namespace MvxNewNavigation.Core.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;
        public MainViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;

            Title = "From Constructor ";
        }
        
        public override Task Initialize() // <- Never being called
        {
            Title = "From Initializer";
            return base.Initialize();
        }

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public IMvxAsyncCommand GoToSecondCommand =>
            new MvxAsyncCommand(GoToSecondAsync);

        private async Task GoToSecondAsync()
        {
            await _navigationService.Navigate<SecondViewModel>();
        }
    }
}