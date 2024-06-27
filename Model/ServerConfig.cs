namespace powerraker
{
    public class Server
    {
        public ServerConfig Config { get; set; }
    }

    public class ServerConfig
    {
        public Server Server { get; set; }

        public object DbusManager { get; set; }
        public ServerConfigDatabase Database { get; set; }
    }

    public class ServerConfigServer
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public int SslPort { get; set; }
        public bool EnableDebugLogging { get; set; }
        public bool EnableAsyncioDebug { get; set; }
        public string KlippyUdsAddress { get; set; }
        public int MaxUploadSize { get; set; }
        public string SslCertificatePath { get; set; }
        public string SslKeyPath { get; set; }
    }

    public class ServerConfigDatabase
    {
        public string DataBasePath { get; set; }
        public bool EnableDatabaseDebug { get; set; }
    }
}