using Library.Domain.Aggregates;
using Library.Domain.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorApp.Services
{
    public class LibraryClient
    {
        private readonly HttpClient _httpClient;

        public LibraryClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Book>> GetBooksAsync()
        {
            var books = await _httpClient.GetFromJsonAsync<List<Book>>("api/v1/books");
            return books;
        }

        public async Task<List<Worker>> GetWorkersAsync()
        {
            var workers = await _httpClient.GetFromJsonAsync<List<Worker>>("api/v1/persons/workers");
            return workers;
        }

        public async Task<List<UserModel>> GetUsersAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<UserModel>>("api/v1/persons/users");
        }
    }
}
