using System.Net.Http.Headers;

namespace Day3WebAPIConsumingConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Console.WriteLine(" --------------- Show All Client -------------");
            GetAllClient();
            Console.WriteLine("------------------------------");
            Console.Write("Enter the id : ");
            int id;
            int.TryParse(Console.ReadLine(), out id);
            ShowClient(id);
            Console.ReadLine();


        }

        public static async void GetAllClient()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7029/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync("api/Clients").Result;

                if (response.IsSuccessStatusCode)
                {
                    var Clients = response.Content.ReadAsAsync<IEnumerable<Client>>().Result;
                    foreach (var item in Clients)
                    {
                        Console.WriteLine($"{item.ClientId} , Name {item.Name} , Email {item.Email} $ , Mobile : {item.Mobile}");
                    }
                }
            }

        }
        public static async void ShowClient(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7029/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/clients/" + id);

                if (response.IsSuccessStatusCode)
                {
                    Client item = await response.Content.ReadAsAsync<Client>();
                    Console.WriteLine($"{item.ClientId} , Name {item.Name} , Email {item.Email} $ , Mobile : {item.Mobile}");
                }
            }
        }
    }
}
