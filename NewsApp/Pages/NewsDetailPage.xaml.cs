using System.Diagnostics;
using NewsApp.Models;

namespace NewsApp.Pages;

public partial class NewsDetailPage : ContentPage
{
	public NewsDetailPage(Article article)
	{
		InitializeComponent();
		this.Title = "News Detail Page";
        BindingContext = article;
		articleImage.Source = article.Image;
        articleTitle.Text = article.Title;
		articleContent.Text = article.Content;
    }
}