﻿using Microsoft.AspNetCore.Mvc;

namespace ApiDeContactos.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public abstract class BaseApiController : ControllerBase
    {
        
    }
}
