using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Media;
using AvalonStalker.Core.Enums;
using AvalonStalker.Models;
using DynamicData;
using ReactiveUI;

namespace AvalonStalker.ViewModels.Concrete
{
    public class RequestViewModel : ViewModelBase
    {
        private UrlMethod selectedUrlMethod;
        private string url;
        private string syntaxHighlight;
        private string filePath;
        private SourceList<HeaderModel> headerModels { get; } = new SourceList<HeaderModel>();
        private ReadOnlyObservableCollection<HeaderModel> readOnlyHeaderModels;
        
        public ReactiveCommand<Unit,Unit> SetFileCommand { get; }

        public string FilePath
        {
            get => filePath;
            set => this.RaiseAndSetIfChanged(ref filePath, value);
        }

        public ReadOnlyObservableCollection<HeaderModel> ReadOnlyHeaderModels => readOnlyHeaderModels;

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

        public List<string> Syntaxs { get; } = new List<string>() {"XML", "JSON"};

        public UrlMethod SelectedUrlMethod
        {
            get => selectedUrlMethod;
            set => this.RaiseAndSetIfChanged(ref selectedUrlMethod, value);
        }

        public string SyntaxHighlight
        {
            get => syntaxHighlight;
            set => this.RaiseAndSetIfChanged(ref syntaxHighlight, value);
        }

        public string Url
        {
            get => url;
            set => this.RaiseAndSetIfChanged(ref url, value);
        }

        public RequestViewModel()
        {
            SelectedUrlMethod = UrlMethods[0];
            headerModels.Connect().ObserveOn(RxApp.MainThreadScheduler).Bind(out readOnlyHeaderModels).Subscribe();
            AddEmptyHeader();
            SetFileCommand = ReactiveCommand.CreateFromTask(SelectFile);
        }

        public void AddEmptyHeader()
        {
            headerModels.Add(new HeaderModel {Id = headerModels.Count});
        }

        public void RemoveHeader(string id)
        {
            int val = -1;
            if (int.TryParse(id, out val))
            {
                var firstOrDefault = headerModels.Items.FirstOrDefault(x => x.Id == val);
                if (firstOrDefault != null) headerModels.Remove(firstOrDefault);
            }
        }

        public async Task SelectFile()
        {
            var dialog = new OpenFileDialog();
            string[] result = null;
            result = await dialog.ShowAsync(new Window());
            if (result != null)
            {
                FilePath = result.First();
            }
        }
    }
}