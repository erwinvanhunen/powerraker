namespace powerraker
{

    public class RakerConnection
    {
        private HttpClient? httpClient;

        public string Printer { get; internal set; }
        public string APIKey {get; internal set; }
        public RakerConnection(string printer, string APIKey)
        {
            this.Printer = printer;
            this.APIKey = APIKey;
            Current = this;
        }
        public static RakerConnection? Current
        {
            get; internal set;
        }

        public HttpClient HttpClient
        {
            get
            {
                if (httpClient == null)
                {
                    httpClient = new HttpClient();
                    httpClient.DefaultRequestHeaders.Add("X-Api-Key", APIKey);
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                }
                return httpClient;
            }
        }
    }
}