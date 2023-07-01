using DatabaseConnectionApp.Models;
using DatabaseConnectionApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DatabaseConnectionApp.Pages
{
    public class IndexModel : PageModel
    {
       
        public List<Product> products { get; set; }

        public void OnGet()
        {
            ProductService productService = new ProductService();
            products = productService.GetProducts();
        }
    }
}