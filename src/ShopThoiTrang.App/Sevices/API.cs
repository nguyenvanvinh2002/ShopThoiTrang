/*namespace ShopThoiTrang.App.Sevices
{
    public class API
    {
        private readonly HttpClient _httpClient;
        
        public API(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<T> GetTAsync<T>(string url)
        {
            var reponse = await _httpClient.GetAsync(url);
            reponse.EnsureSuccessStatusCode();
            var data = await reponse.Content.ReadAsStringAsync();
            return data;
        }
    }

}
*/