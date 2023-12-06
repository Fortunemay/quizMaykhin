using Microsoft.AspNetCore.Mvc;
using quizAPI.Interface;
using quizAPI.Model.Repo;

namespace quizAPI.Controllers
{
    [Route("api/Members")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly ILogger<MembersController> _log;
        readonly IConfiguration _configuration;
        IMembers _members;

        public MembersController(ILogger<MembersController> log, IConfiguration configuration, IMembers members)
        {
            _log = log;
            _configuration = configuration;
            _members = members;
        }

        [HttpGet]
        [Route("GetMembers")]
        public MembersModel GetMembers()
        {
            MembersModel model = new MembersModel();
            try
            {
                model = _members.GetMembersBC();
                model.status = Const.STATUS_SUCCESS;
            }
            catch (Exception ex)
            {
                model.status = Const.STATUS_ERROR;
                model.message = $"Error: {ex.Message}";

                _log.LogInformation("Fatal Message : " + ex.Message);
                _log.LogInformation("Exception StackTrace : " + ex.StackTrace);

                if (ex.InnerException != null)
                {
                    _log.LogInformation("InnerException Message : " + ex.InnerException.Message);
                    _log.LogInformation("InnerException StackTrace : " + ex.InnerException.StackTrace);
                }
            }

            return model;
        }

        [HttpPost]
        [Route("AddNewMember")]
        public MembersResp AddNewMember(MemberReq req)
        {
            MembersResp model = new MembersResp();
            try
            {
                model = _members.AddNewMemberBC(req);

            }
            catch (Exception ex)
            {
                model.status = Const.STATUS_ERROR;
                model.message = $"Error: {ex.Message}";

                _log.LogInformation("Fatal Message : " + ex.Message);
                _log.LogInformation("Exception StackTrace : " + ex.StackTrace);

                if (ex.InnerException != null)
                {
                    _log.LogInformation("InnerException Message : " + ex.InnerException.Message);
                    _log.LogInformation("InnerException StackTrace : " + ex.InnerException.StackTrace);
                }
            }

            return model;
        }
    }
}
