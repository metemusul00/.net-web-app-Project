using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Pages.Models; // Kategori modelini i�eren klas�r�n referans�
using System.Threading.Tasks; // Asenkron i�lemler i�in gerekli k�t�phane
using System.Collections.Generic; // List<> kullan�m� i�in gerekli k�t�phane
using Microsoft.AspNetCore.Mvc; // Redirect i�lemleri i�in gerekli k�t�phane

namespace WebApplication1.Pages
{
    public class CategoriesModel : PageModel
    {
        private readonly MongoDBService _mongoDBService; // MongoDB i�lemlerini y�r�tecek servis

        // MongoDBService'i dependency injection ile al�yoruz.
        public CategoriesModel(MongoDBService mongoDBService)
        {
            _mongoDBService = mongoDBService; // Dependency injection ile MongoDB servisini s�n�fa aktar�yoruz
        }

        public List<Category> veri { get; set; } // MongoDB'den al�nacak kategorileri tutacak liste

        // Sayfa y�klendi�inde MongoDB'den kategorileri �ekmek i�in asenkron metod
        public async Task OnGetAsync()
        {
            veri = await _mongoDBService.GetCategoriesAsync(); // Kategorileri MongoDB servisinden al�yoruz
        }

        // Belirli bir slug de�erine g�re �r�n detay sayfas�na y�nlendirme metodu
        public IActionResult OnGetRedirectToCollection(string slug)
        {
            // Kategorinin slug de�erine g�re ilgili �r�n detay sayfas�na y�nlendiriyoruz
            return RedirectToPage("/ProductDetails", new { slug });
        }
    }
}
