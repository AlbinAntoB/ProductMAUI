using ProductMAUI.Models;

namespace ProductMAUI;

public partial class ProductDetailPage : ContentPage
{
    public ProductDetailPage(Product product)
    {
        InitializeComponent();
        DisplayProductDetails(product);
    }

    private void DisplayProductDetails(Product product)
    {
        ProductTitle.Text = product.Title;
        ProductPrice.Text = $"Price: {product.Price:C}";
        ProductDescription.Text = product.Description;
    }
}