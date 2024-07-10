using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json.Linq;
using PowersoftIntergration.Models;
using System.Globalization;

namespace PowersoftIntergration.Services;

public class CryptoService
{
    private readonly HttpClient _httpClient;
    public CryptoService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<CryptoCurrency>> GetAllCryptosAsync()
    {
        var response = await _httpClient.GetStringAsync("https://api.coincap.io/v2/assets");
        var jsonResponse = JObject.Parse(response);
        var cryptos = jsonResponse["data"].ToObject<List<CryptoCurrency>>();
        return cryptos;
    }
    public async Task<CryptoCurrency> GetCryptoByIdAsync(string id)
    {
        var response = await _httpClient.GetStringAsync($"https://api.coincap.io/v2/assets/{id}");
        var jsonResponse = JObject.Parse(response);
        var crypto = jsonResponse["data"].ToObject<CryptoCurrency>();
        return crypto;
    }
    public IEnumerable<CryptoCurrency> GetCryptoSorted(IEnumerable<CryptoCurrency> cryptos, string sortingParam) 
    {
        return sortingParam.ToLower() switch
        {
            "price" => cryptos.OrderBy(c => c.PriceUsd),
            "marketcap" => cryptos.OrderBy(c => c.MarketCapUsd),
            "name" => cryptos.OrderBy(c => c.Name),
            _ => cryptos.OrderBy(c => int.Parse(c.Rank)),
        };
    }
    public IEnumerable<CryptoCurrency> Pagination(IEnumerable<CryptoCurrency> cryptos, int Page) 
    {
        int PageSize = 10;
        return cryptos.Skip((Page - 1) * PageSize).Take(PageSize);
    }
}
