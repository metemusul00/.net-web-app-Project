using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks; // Asenkron i�lemler i�in gerekli k�t�phane
using System.Collections.Generic; // List<> kullan�m� i�in gerekli k�t�phane
using WebApplication1.Pages.Models; // Modelleri i�eren klas�r
using Microsoft.AspNetCore.Mvc; // Redirect i�lemleri i�in gerekli k�t�phane

namespace WebApplication1.Pages
{
    public class ProductDetailsModel : PageModel
    {
        private readonly MongoDBService _mongoDBService; // MongoDB i�lemleri i�in servis

        // MongoDBService'i dependency injection ile al�yoruz.
        public ProductDetailsModel(MongoDBService mongoDBService)
        {
            _mongoDBService = mongoDBService; // Dependency injection ile MongoDB servisini s�n�fa aktar�yoruz
        }

        public Category SelectedCategory { get; set; } // Se�ilen kategori bilgisi

        public List<Category> veri { get; set; } // Kategorileri tutan liste

        // Belirli bir slug'a g�re MongoDB'den kategori verisini �ekmek i�in asenkron metot
        public async Task OnGetAsync(string slug)
        {
            var allCategories = await _mongoDBService.GetCategoriesAsync(); // T�m kategorileri al�yoruz
            SelectedCategory = allCategories.FirstOrDefault(c => c.slug == slug); // Belirli bir slug'a g�re se�ilen kategoriyi buluyoruz

            // Se�ilen kategori bilgilerini konsola yazd�r�yoruz
            if (SelectedCategory != null)
            {
                Console.WriteLine($"Se�ilen Kategori - Slug: {SelectedCategory.slug}, URL: {SelectedCategory.url}");
            }
        }

        // Belirli bir slug de�erine g�re y�nlendirme metodu
        public IActionResult OnGetRedirectToCollection(string slug)
        {
            // Kategorinin slug de�erine g�re ilgili �r�n detay sayfas�na y�nlendiriyoruz
            return RedirectToPage("/ProductDetails", new { slug });
        }
    }
}

// �r�n detaylar� i�in model s�n�f�
public class Products
{
    public string slug { get; set; } // �r�n slug'�
    public string url { get; set; } // �r�n URL'si
    public string category { get; set; } // �r�n kategorisi

    public List<ProductDetails> products { get; set; } // �r�n detaylar�n� tutan liste
    // Di�er alanlar� buraya ekleyin
}
