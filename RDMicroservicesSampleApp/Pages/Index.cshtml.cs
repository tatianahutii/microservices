using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RDMicroservicesSampleApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;        

        public List<List<string>> Products = [];

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            Products = System.IO.File.ReadAllLines("products.csv").Skip(1).Select(l => l.Split(',').ToList()).ToList();
        }

        public IActionResult OnPost(string id)
        {
            Products = System.IO.File.ReadAllLines("products.csv").Skip(1).Select(l => l.Split(',').ToList()).ToList();
            var product = Products.FirstOrDefault(p => p[0] == id);
            if (product != null)
            {
                product[5] = (int.Parse(product[5]) - 1).ToString();
            }                       

            System.IO.File.WriteAllLines("products.csv", new List<string> { "id,name,description,picture,price,stock" }.Concat(Products.Select(p => string.Join(",", p)).ToList()));
            return RedirectToPage();
        }
    }
}
