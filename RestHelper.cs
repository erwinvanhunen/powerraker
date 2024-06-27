namespace powerraker
{
    internal static class RestHelper
    {
        public static string ExecuteGetRequest(RakerConnection connection, string endPoint)
        {
            var url = connection.Printer + endPoint;

            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            //client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", context.GetAccessToken());
            var returnValue = client.GetStringAsync(url).GetAwaiter().GetResult();
            return returnValue;
        }
    }
}