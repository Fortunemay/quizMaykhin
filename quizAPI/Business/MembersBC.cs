using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Storage;
using quizAPI.Interface;
using quizAPI.Model.Database;
using quizAPI.Model.Repo;

namespace quizAPI.Business
{
    public class MembersBC : IMembers
    {
        private readonly IConfiguration configuration;
        private string connectionString;
        public MembersBC(IConfiguration config)
        {
            configuration = config;
        }

        public MembersModel GetMembersBC()
        {
            connectionString = configuration.GetConnectionString(Const.DBConnectionString);
            SqlConnection conn = new SqlConnection(connectionString);
            MembersModel model = new MembersModel();
            model.membersLists = null;
            try
            {
                conn.Open();
                SqlCommand cm = null;
                string strSQL = @"

                    SELECT [memberId], [Firstname], [Lastname], [Birthdate] = FORMAT([Birthdate], 'dd/MM/yyyy')
                        , [Age] = DATEDIFF([YEAR], [Birthdate], GETDATE())
                        , [Address], [IsActive], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]
                    FROM [dbo].[TbMembers]
                    WHERE 1=1
       
                ";

                cm = new SqlCommand(strSQL, conn);
                SqlDataReader reader = cm.ExecuteReader();

                if (reader.HasRows)
                {
                    model.membersLists = new List<MembersList>();
                    model.membersLists = HelperBC.HelperBC.DataReaderMapToList<MembersList>(reader);
                    model.status = Const.STATUS_SUCCESS;
                }
                else
                    throw new Exception(Const.MSG_NOTFOUND);
            }
            catch (Exception ex)
            {
                model.status = Const.STATUS_ERROR;
                model.message = $"Error: {ex.Message}";
            }

            return model;
        }

        public MembersResp AddNewMemberBC(MemberReq req)
        {
            MembersResp model = new MembersResp();
            try
            {
                if (req != null)
                {
                    using (var _db = new DBAlphaContext())
                    {
                        using (IDbContextTransaction transaction = _db.Database.BeginTransaction())
                        {
                            TbMember tbMember = _db.TbMembers.Where(x => x.Firstname == req.Firstname && x.Lastname == req.Lastname).FirstOrDefault();
                            
                            if (tbMember == null)
                            {
                                tbMember = new TbMember(); 
                                tbMember.Firstname = req.Firstname;
                                tbMember.Lastname = req.Lastname;
                                tbMember.Birthdate = Convert.ToDateTime(req.Birthdate);
                                tbMember.Address = req.Address;
                                tbMember.IsActive = true;
                                tbMember.CreatedBy = 1;
                                tbMember.CreatedDate = DateTime.Now;

                                _db.TbMembers.Add(tbMember);
                                _db.SaveChanges();
                            }
                            

                            transaction.Commit();
                            model.status = Const.STATUS_SUCCESS;
                        }
                    }
                }
                else
                    throw new Exception(Const.MSG_EMPTYDATA);
            }
            catch (Exception ex)
            {
                model.status = Const.STATUS_ERROR;
                model.message = $"Error: {ex.Message}";
            }
            return model;
        }

    }
}
