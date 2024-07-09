namespace PowerRaker.Model.UpdateManagement
{
    public class UpdateStatus
    {
        public bool Busy { get; set; }
        public int? GithubRateLimit { get; set; }
        public int? GithubRequestsRemaining { get; set; }
        public DateTime? GithubLimitResetTime { get; set; }
        public Dictionary<string, VersionInfo>? VersionInfo { get; set; }
    }

    public class VersionInfo
    {
        public int PackageCount { get; set; }
        public List<string>? PackageList { get; set; }
        public string? Channel {get;set;}
        public bool DebugEnabled {get;set;}
        public bool IsValid {get;set;}
        public string? ConfiguredType {get;set;}
        public string? RemoteAlias {get;set;}
        public string? Branch {get;set;}
        public string? Owner {get;set;}
        public string? RepoName {get;set;}
        public string? Version {get;set;}
        public string? RemoteVersion {get;set;}
        public string? RollbackVersion {get;set;}
        public string? CurrentHash {get;set;}
        public string? RemoteHash {get;set;}
        public bool IsDirty{ get;set;}
        public bool Detached {get;set;}
        public List<Commit>? CommitsBehind {get;set;}
        public List<string>? GitMessages {get;set;}
        public string? FullVersionString {get;set;}
        public bool Pristine {get;set;}
        public string? RecoveryUrl {get;set;}
        public string? RemoteUrl {get;set;}
        public List<string>? Warnings {get;set;}

        public List<string>? Anomalies {get;set;}

    }

    public class Commit
    {
        public string? Sha {get;set;}
        public string? Author {get;set;}
        public DateTime? Date {get;set;}
        public string? Subject {get;set;}
        public string? Message {get;set;}
        public object? Tag {get;set;}
    }
}