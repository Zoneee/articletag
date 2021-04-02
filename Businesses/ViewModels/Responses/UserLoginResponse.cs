using Entity.Enum;

namespace Deepbio.ApplicationCore.ResearcherDbUser.Query
{
    public class UserLoginResponse
    {
        public long UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public TagRoleEnum Role { get; set; }
        public string RoleName => Role.ToDescriptionOrString();
    }
}
