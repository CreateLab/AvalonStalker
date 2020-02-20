using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using AvalonStalker.ViewModels.Concrete;

namespace AvalonStalker.Views
{
    public class RequestView : ReactiveUserControl<RequestViewModel>
    {
        public RequestView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}