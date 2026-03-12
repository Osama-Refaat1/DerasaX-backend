namespace DerasaX.Application.Common
{
    public static class RealtimeGroups
    {
        public static string User(string userId) => $"user_{userId}";
        public static string TenantRole(string tenantId, string role) => $"{tenantId}_{role}";
        public static string TenantAll(string tenantId) => $"{tenantId}_all";
    }
}
