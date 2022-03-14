using News.Commands;
using News.Models;
using News.Properties;
using News.Services;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;

namespace News.ViewModels
{
    internal class MainWindowViewModel : BaseViewModel
    {
        public ICommand GetNewsCommandAsync { get => new RelayCommandAsync(GetNews, ex => Error = ex.Message); }

        public string KeyWord
        {
            get => _keyWord;
            set
            {
                _keyWord = value;
                OnPropertyChanged(nameof(KeyWord));
            }
        }

        public string Error
        {
            get => _error;
            set
            {
                _error = value;
                OnPropertyChanged(nameof(Error));
            }
        }

        public bool NewsIsLoading
        {
            get => _newsIsLoading;
            set
            {
                _newsIsLoading = value;
                OnPropertyChanged(nameof(NewsIsLoading));
            }
        }

        public List<New> News
        {
            get => _news;
            set
            {
                _news = value;
                OnPropertyChanged(nameof(News));
            }
        }

        public MainWindowViewModel()
        {
            NewsIsLoading = false;
            _newsService = new NewsService(new HttpService(), Resources.apiKey);
        }

        private async Task GetNews()
        {
            NewsIsLoading = true;
            NewsResponse news = (NewsResponse)await _newsService.GetNewsAsync(KeyWord);
            News = new List<New>(news.News);
            NewsIsLoading = false;
        }

        private readonly INewsService _newsService;
        private string _keyWord;
        private bool _newsIsLoading;
        private string _error;
        private List<New> _news;
    }
}
