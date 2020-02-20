using System.Collections.Generic;
using Avalonia.Media;
using AvalonStalker.Core.Enums;
using AvalonStalker.Models;
using ReactiveUI;

namespace AvalonStalker.ViewModels.Concrete
{
    public class RequestViewModel:ViewModelBase
    {
        private UrlMethod selectedUrlMethod;
        private string url;
        private string syntaxHighlight;
        public List<UrlMethod> UrlMethods { get; } = new List<UrlMethod>()
        {
            new UrlMethod
                          {
                              Brush = new SolidColorBrush(new Color((byte) 255, (byte) 0, (byte) 128, (byte) 0)),
                              UrlTypesEnum = UrlTypesEnum.GET,

                          },
            new UrlMethod
            {
                Brush = new SolidColorBrush(new Color((byte) 255, (byte) 127, (byte) 0, (byte) 255)),
                UrlTypesEnum = UrlTypesEnum.POST,
            },
        };
        public List<string> Syntaxs { get; } = new List<string>(){"XML", "JSON"};
        public UrlMethod SelectedUrlMethod
        {
            get => selectedUrlMethod;
            set => this.RaiseAndSetIfChanged(ref selectedUrlMethod,value);
        }

        public string SyntaxHighlight
        {
            get => syntaxHighlight;
            set => this.RaiseAndSetIfChanged(ref syntaxHighlight,value);
        }

        public string Url
        {
            get => url;
            set => this.RaiseAndSetIfChanged(ref url,value);
        }

        public RequestViewModel()
        {
            SelectedUrlMethod = UrlMethods[0];
        }
    }
}