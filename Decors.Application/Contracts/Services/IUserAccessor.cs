namespace Decors.Application.Contracts.Services
{
    public interface IUserAccessor
    {
        public string GetCurrentUserId();
        public string GetCurrentEmail();
        public string GetCurrentUserName();
    }
}
