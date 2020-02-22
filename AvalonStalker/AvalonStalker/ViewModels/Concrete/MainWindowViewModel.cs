using AvalonStalker.ViewModels.Abstract;
using AvalonStalker.Views;
using Splat;

namespace AvalonStalker.ViewModels.Concrete
{
    public class MainWindowViewModel :  ViewModelBase , IMainWindowViewModel
    {
        public RequestViewModel Request { get; set; }
        public MainWindowViewModel(RequestViewModel viewModel)
        {
            Request = viewModel;
        }

    }
}