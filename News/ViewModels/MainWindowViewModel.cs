using News.Commands;
using News.Models;
using News.Properties;
using News.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;

namespace News.ViewModels
{
    internal class MainWindowViewModel : BaseViewModel
    {
        public ICommand GetNewsCommandAsync 
        { 
            get => new RelayCommandAsync(GetNews, ex =>
            {
                NewsIsLoading = true;
                Status = $"Ошибка: {ex.Message}";
            }); 
        }

        public string KeyWord
        {
            get => _keyWord;
            set
            {
                _keyWord = value;
                OnPropertyChanged(nameof(KeyWord));
            }
        }

        public string Status
        {
            get => _status;
            set
            {
                _status = value;
                OnPropertyChanged(nameof(Status));
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
            Status = "Загрузка новостей..";
            NewsIsLoading = true;
            NewsResponse news = await _newsService.GetNewsAsync(KeyWord);

            switch (news.Status)
            {
                case "ok":
                    News = new List<New>(news.News);
                    NewsIsLoading = false;
                    return;
                case "error": throw new Exception(news.Message);
            }
        }

        private readonly INewsService _newsService;
        private string _keyWord;
        private bool _newsIsLoading;
        private string _status;
        private List<New> _news;
    }
}
