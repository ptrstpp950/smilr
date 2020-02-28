/*
 * Smilr API
 *
 * Smilr microservice, RESTful data API
 *
 * OpenAPI spec version: 6.2.0
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */

using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Smilr.DotNet.Attributes;
using Microsoft.AspNetCore.Authorization;
using Smilr.DotNet.Models;
using ProblemDetails = Smilr.DotNet.Models.ProblemDetails;

namespace Smilr.DotNet.Controllers
{ 
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    public class FeedbackApiController : ControllerBase
    { 
        private readonly ApplicationDbContext _dbContext;

        /// <inheritdoc />
        public FeedbackApiController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>This submit new feedback</remarks>
        /// <param name="feedback">The feedback to submit</param>
        /// <response code="200">Feedback object with id</response>
        /// <response code="400">Validation error with feedback</response>
        /// <response code="500">Unexpected error</response>
        [HttpPost]
        [Route("/api/feedback")]
        [ValidateModelState]
        [SwaggerOperation("FeedbackCreate")]
        [SwaggerResponse(statusCode: 200, type: typeof(Feedback), description: "Feedback object with id")]
        [SwaggerResponse(statusCode: 400, type: typeof(ProblemDetails), description: "Validation error with feedback")]
        [SwaggerResponse(statusCode: 500, type: typeof(ProblemDetails), description: "Unexpected error")]
        public virtual async Task<IActionResult> FeedbackCreate([FromBody] Feedback feedback)
        { 
            feedback.Id = string.IsNullOrEmpty(feedback.Id) ? Guid.NewGuid().ToString("D") : feedback.Id;
            _dbContext.Feedback.Add(feedback);
            await _dbContext.SaveChangesAsync();
            return new ObjectResult(feedback);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>This returns all feedback for a given event and topic</remarks>
        /// <param name="eventid">Id of event containing topic</param>
        /// <param name="topicid">Id of topic to leave feedback on</param>
        /// <response code="200">An array of feedback, empty array if topic or event not found</response>
        /// <response code="500">Unexpected error</response>
        [HttpGet]
        [Route("/api/feedback/{eventid}/{topicid}")]
        [ValidateModelState]
        [SwaggerOperation("FeedbackGet")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<Feedback>), description: "An array of feedback, empty array if topic or event not found")]
        [SwaggerResponse(statusCode: 500, type: typeof(ProblemDetails), description: "Unexpected error")]
        public virtual IActionResult FeedbackGet([FromRoute][Required]string eventid, [FromRoute][Required]int? topicid)
        {
            var query = _dbContext.Feedback.Where(x => x.EventId == eventid);
            if (topicid != null)
                query = query.Where(x => x.Topic == topicid);
            return new ObjectResult(query.ToArray());
        }
    }
}
