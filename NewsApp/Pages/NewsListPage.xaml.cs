using NewsApp.Models;
using NewsApp.Services;

namespace NewsApp.Pages;

public partial class NewsListPage : ContentPage
{
    String categoryName;
    public List<Article> ArticleList;
    public NewsListPage(Category category)
	{
		InitializeComponent();
		BindingContext = category;

		this.Title = category.Name;
        this.categoryName = category.Name;
        ArticleList = new List<Article>();
        GetCategoryNews();
    }

    private async Task GetCategoryNews()
    {
        var apiService = new ApiService();
        var newsResult = await apiService.GetNews(categoryName);
        foreach (var item in newsResult.Articles)
        {
            ArticleList.Add(item);
        }
        CvNews.ItemsSource = ArticleList;
    }

    private async void CvNews_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var selectedCategory = e.CurrentSelection[0] as Article;
        await Navigation.PushAsync(new NewsDetailPage(selectedCategory));
    }
}