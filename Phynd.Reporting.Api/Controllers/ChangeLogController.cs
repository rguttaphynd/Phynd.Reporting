using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Phynd.Common.Interfaces;
using Phynd.Common.Models;
using Phynd.Reporting.BusinessEntities;
using Phynd.Reporting.BusinessService;

namespace Phynd.Reporting.Api.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/ChangeLog")]
    public partial class ChangeLogController : Controller
    {
        private readonly IChangeLogBusinessService service;
        private readonly ILoggingManager logger;

        public ChangeLogController(IChangeLogBusinessService service, ILoggingManager loggingManager)
        {
            this.service = service;
            this.logger = loggingManager;
        }

        // GET: api/ChangeLog
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var userContext = (PhyndUserContext)HttpContext.Items["PhyndUserContext"];
                var p = await service.GetAllAsync(userContext.TargetHealthSystemID);
                if (p == null)
                    return NotFound();
                return new ObjectResult(p);
            }
            catch (Exception ex)
            {
                logger.LogException(ex);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // GET: api/ChangeLog/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var userContext = (PhyndUserContext)HttpContext.Items["PhyndUserContext"];
                var p = await service.GetByIdAsync(id);
                if (p == null)
                    return NotFound();
                
                return new OkObjectResult(p);
            }
            catch (Exception ex)
            {
                logger.LogException(ex);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        
        // POST: api/ChangeLog
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]ChangeLog obj)
        {
            try
            {
                var userContext = (PhyndUserContext)HttpContext.Items["PhyndUserContext"];
                var response = await service.CreateAsync(userContext.UserID, obj);
                return new OkObjectResult(response);
            }
            catch (Exception ex)
            {
                logger.LogException(ex);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        
        // PUT: api/ChangeLog/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]ChangeLog obj)
        {
            try
            {
                var userContext = (PhyndUserContext)HttpContext.Items["PhyndUserContext"];
                var response = await service.UpdateAsync(1, obj);
                return new OkObjectResult(response);
            }
            catch (Exception ex)
            {
                logger.LogException(ex);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // DELETE: api/ChangeLog/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var userContext = (PhyndUserContext)HttpContext.Items["PhyndUserContext"];
                var response = await service.DeleteAsync(userContext.UserID, id);
                return new OkObjectResult(response);
            }
            catch (Exception ex)
            {
                logger.LogException(ex);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}

