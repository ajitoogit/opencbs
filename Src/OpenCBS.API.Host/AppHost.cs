using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceStack.ServiceInterface;
using ServiceStack.WebHost.Endpoints;
using ServiceStack.Configuration;
using OpenCBS.API.ServiceInterface;

namespace OpenCBS.API.Host
{
    public class AppHost : AppHostHttpListenerBase
    {
        public AppHost() : base("StarterTemplate HttpListener", typeof(UserAuthenticationService).Assembly) { }

        public override void Configure(Funq.Container container)
        {
            //container.Register(new TodoRepository());
            /*
            Routes
                            .Add<Hello>("/hello")
                            .Add<Hello>("/hello/{Name}");
             * */
        }
    }
}
