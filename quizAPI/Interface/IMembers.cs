using quizAPI.Model.Repo;

namespace quizAPI.Interface
{
    public interface IMembers
    {
        MembersModel GetMembersBC();

        MembersResp AddNewMemberBC(MemberReq req);
    }
}
