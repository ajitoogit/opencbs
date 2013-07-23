using ServiceStack.ServiceInterface;
using ServiceStack.ServiceInterface.Auth;
using ServiceStack.ServiceHost;

namespace OpenCBS.API.ServiceInterface
{
    [Route("/TestRequest")]
    [Route("/TestRequest/{Name}/{SessionId}")]
    public class TestRequest
    {
        public string Name { get; set; }
        public string SessionId { get; set; }
    }

    public class TestResponse
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string SessionId { get; set; }

    }
    [MyAuthenticate]
    [MyRequiredPermission("TestService")]
    class TestService : Service
    {
        public object Any(TestRequest request)
        {
            IAuthSession s = this.GetSession();
            ServiceStack.CacheAccess.ICacheClient ca = this.GetCacheClient();
            bool has = s.HasRole("admin");
            IHttpRequest r = base.Request;
            
            string ddd = Session.ToString();
            ddd = SessionFactory.ToString();
            return new TestResponse { Username = s.UserName, Password = "w", SessionId =  s.Id};
            
        }
    }
}
