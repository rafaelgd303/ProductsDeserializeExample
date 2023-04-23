using System.Text.Json;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class ProductDeserializer
    {
        private const string URL = "https://gist.githubusercontent.com/bradygaster/3d1fcf43d1d1e73ea5d6c1b5aab40130/raw/e0bced80b7672a15e57383c2df61690db037db2c/products.json";

        public static List<Product> ListOfAllDeserializedProducts()
        {
            return GetAllProducts();
        }

        private static List<Product> GetAllProducts()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(URL);
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync(URL).Result;

            var productList = JsonSerializer.Deserialize<List<Product>>(response.Content.ReadAsStream(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    WriteIndented = true
                });

            return productList ?? new List<Product>();
        }
    }
}
