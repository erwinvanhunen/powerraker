namespace PowerRaker.Model.Administration
{
    public class Server
    {
        public ServerConfig? Config { get; set; }
        public List<ServerFile>? Files {get;set;}
    }

    public class ServerConfig
    {
        public ServerConfigServer? Server { get; set; }

        public object? DbusManager { get; set; }
        public ServerConfigDatabase? Database { get; set; }
        public ServerConfigSecrets? Secrets { get; set; }
        public ServerConfigFileManager? FileManager { get; set; }
        public ServerConfigAuthorization? Authorization { get; set; }
        public ServerConfigMachine? Machine {get;set;}
        public ServerConfigDataStore? DataStore {get;set;}
        public ServerConfigJobQueue? JobQueue {get;set;}
        public ServerConfigAnnouncements? Announcements {get;set;}
    }

    public class ServerConfigServer
    {
        public string? Host { get; set; }
        public int Port { get; set; }
        public int SslPort { get; set; }
        public bool EnableDebugLogging { get; set; }
        public bool EnableAsyncioDebug { get; set; }
        public string? KlippyUdsAddress { get; set; }
        public int MaxUploadSize { get; set; }
        public string? SslCertificatePath { get; set; }
        public string? SslKeyPath { get; set; }
    }

    public class ServerConfigSecrets
    {
        public string? SecretsPath { get; set; }
    }

    public class ServerConfigDatabase
    {
        public string? DataBasePath { get; set; }
        public bool EnableDatabaseDebug { get; set; }
    }
    public class ServerConfigFileManager
    {
        public bool EnableObjectProcessing { get; set; }
        public double DefaultMetadataParserTimeout { get; set; }
        public bool EnableObserverWarnings { get; set; }
        public bool EnableInotifyWarnings { get; set; }
        public bool QueueGCodeUploads { get; set; }
        public bool CheckKlipperConfigPath { get; set; }
        public string? ConfigPath { get; set; }
        public bool EnableConfigWriteAccess { get; set; }
        public string? LogPath { get; set; }
    }

    public class ServerConfigAuthorization
    {
        public int LoginTimeout { get; set; }
        public bool ForceLogins { get; set; }
        public string? DefaultSource { get; set; }
        public bool EnableApiKey { get; set; }
        public string? MaxLoginAttempts { get; set; }
        public List<string>? CorsDomains { get; set; }
        public List<string>? TrustedClients { get; set; }
    }

    public class ServerConfigMachine 
    {
        public string? SudoPassword {get;set;}
        public string? Provider {get;set;}
        public string? ShutDownAction {get;set;}
        public string? SupervisordConfigPath {get;set;}
        public bool ForceValidation {get;set;}
        public bool ValidateService {get;set;}
        public bool ValidateConfig {get;set;}
    }

    public class ServerConfigDataStore
    {
        public int TemperatureStoreSize {get;set;}
        public int GcodeStoreSize {get;set;}
    }

    public class ServerConfigJobQueue
    {
        public bool LoadOnStartup {get;set;}
        public bool AutomaticTransition {get;set;}
        public double JobTransitionDelay {get;set;}
        public string? JobTransitionGcode {get;set;}
    }
    
    public class ServerConfigAnnouncements 
    {
        public bool DevMode {get;set;}
        public List<string>? Subscriptions {get;set;}
    }

    public class ServerFile {
        public string? Filename {get;set;}
        public List<string>? Sections {get;set;}
    }
}