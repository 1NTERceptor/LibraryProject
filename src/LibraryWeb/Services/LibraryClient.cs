using Library.Messages.Models;
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

        public async Task<List<BookModel>> GetBooksAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<BookModel>>("api/v1/books");
        }

        public async Task<List<WorkerModel>> GetWorkersAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<WorkerModel>>("api/v1/persons/workers");
        }

        public async Task<List<UserModel>> GetUsersAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<UserModel>>("api/v1/persons/users");
        }
    }
}
