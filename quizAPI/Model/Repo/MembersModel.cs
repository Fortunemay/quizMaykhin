namespace quizAPI.Model.Repo
{
    public class MembersModel
    {
        public string status { get; set; } 
        public string message { get; set; }

        public List<MembersList> membersLists { get; set; }
    }

    public class MembersList
    {
        public int MemberId { get; set; }

        public string? Firstname { get; set; }

        public string? Lastname { get; set; }

        public string? Birthdate { get; set; }

        public int? Age { get; set; }   

        public string? Address { get; set; }

        public bool? IsActive { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }
    }


    public class MembersResp
    {
        public string status { get; set; }
        public string message { get; set; }

    }

    public class MemberReq
    {
        public string? Firstname { get; set; }

        public string? Lastname { get; set; }

        public string? Birthdate { get; set; }

        public string? Address { get; set; }
    }

}
