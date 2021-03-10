
using System;
using AndreSteenveld.Lassi.Model;
using JsonApiDotNetCore.Configuration;
using JsonApiDotNetCore.Controllers;
using JsonApiDotNetCore.Services;
using Microsoft.Extensions.Logging;

namespace AndreSteenveld.Lassi {

    public class BookController : JsonApiController<Book>
    {
        public BookController(IJsonApiOptions options, ILoggerFactory loggerFactory, IResourceService<Book, int> resourceService) : base(options, loggerFactory, resourceService)
        {
        }
    }

    // public class MemberController : JsonApiController<Member>
    // {
    //     public MemberController(IJsonApiOptions options, ILoggerFactory loggerFactory, IResourceService<Member, Guid> resourceService) : base(options, loggerFactory, resourceService)
    //     {
    //     }
    // }

}