using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceStack.ServiceInterface;
using ServiceStack.ServiceInterface.Auth;
using ServiceStack.WebHost.Endpoints;
using ServiceStack.CacheAccess;
using ServiceStack.CacheAccess.Providers;
using ServiceStack.Configuration;
using OpenCBS.API.ServiceInterface;

namespace OpenCBS.API.Host
{
    public class AppHost : AppHostHttpListenerBase
    {
        public AppHost() : base("StarterTemplate HttpListener", typeof(UserAuthenticationService).Assembly) { }

        public override void Configure(Funq.Container container)
        {
            
            Plugins.Add(new AuthFeature(() => new AuthUserSession(), new IAuthProvider[] {
            //new BasicAuthProvider(),
            new UserAuthenticationService()
        }));
            Plugins.Add(new RegistrationFeature());

            container.Register<ICacheClient>(new MemoryCacheClient());
            var userRep = new InMemoryAuthRepository();
            container.Register<IUserAuthRepository>(userRep);
            /*
            List<string> roles = new List<string>() { "admin" };
            userRep.CreateUserAuth(
                new UserAuth() {UserName = "jsonName", Roles = roles, }, "123");
            //container.Register(new TodoRepository());
            */
            /*
            Routes
                            .Add<Hello>("/hello")
                            .Add<Hello>("/hello/{Name}");
             * */
        }
    }
}
