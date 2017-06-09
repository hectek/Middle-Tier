
namespace  Name.Web.Controllers.CMSPages
{

    [RoutePrefix("...")]
    public class CMSPagesApiController : ApiController
    {

        public ICMSPagesService _cmsPageService = null;
        public IUserService _userService = null;

        public CMSPagesApiController(ICMSPagesService cmsPageInject, IUserService userServiceInject)
        {
            _cmsPageService = cmsPageInject;
            _userService = userServiceInject;
        }
        
        
        //INSERT
        [Route, HttpPost]
        public HttpResponseMessage AddCMSPages(CMSPagesAddRequest model)
        {
            if (!ModelState.IsValid || model == null || model.DateToPublish > model.DateToExpire)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            ItemResponse<int> response = new ItemResponse<int>();

            string userId = _userService.GetCurrentUserId();

            response.Item = _cmsPageService.Insert(model, userId);

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

    }

}
