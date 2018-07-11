using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestMakerFreeTrial.ViewModels;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestMakerFreeTrial.Controllers
{
    [Route("api/[controller]")]
    public class QuizController : Controller
    {
        #region RESTful conventions methods 
        /// <summary> 
        /// Retrieves the Answer with the given {id} 
        /// </summary> 
        /// &lt;param name="id">The ID of an existing Answer</param> 
        /// <returns>the Answer with the given {id}</returns> 
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Content("Not implemented (yet)!");
        }
        /// <summary> 
        /// Adds a new Answer to the Database 
        /// </summary> 
        /// <param name="m">The AnswerViewModel containing the data to insert</param> 
        [HttpPut]
        public IActionResult Put(QuizViewModel m)
        {
            throw new NotImplementedException();
        }
        /// <summary> 
        /// Edit the Answer with the given {id} 
        /// </summary> 
        /// <param name="m">The AnswerViewModel containing the data to update</param> 
        [HttpPost]
        public IActionResult Post(QuizViewModel m)
        {
            throw new NotImplementedException();
        }
        /// <summary> 
        /// Deletes the Answer with the given {id} from the Database 
        /// </summary> 
        /// <param name="id">The ID of an existing Answer</param> 
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            throw new NotImplementedException();
        }
        #endregion

        
        #region Attribute-based routing methods 
        /// <summary> 
        /// GET: api/quiz/latest 
        /// Retrieves the {num} latest Quizzes 
        /// </summary> 
        /// <param name="num">the number of quizzes to retrieve</param> 
        /// <returns>the {num} latest Quizzes</returns>

        // GET: api/<controller>
        [HttpGet("Latest/{num}")]
        public IActionResult Latest(int num = 10)
        {
            var sampleQuizzes = new List<QuizViewModel>()
            {
                new QuizViewModel{ Id = 1, Title ="test"},
                new QuizViewModel{ Id = 2, Title ="test1"},
                new QuizViewModel{ Id = 3, Title ="test2"}
            };

            return new JsonResult(sampleQuizzes, new Newtonsoft.Json.JsonSerializerSettings() { Formatting = Newtonsoft.Json.Formatting.Indented });
        }

        // GET api/<controller>/5
        [HttpGet("ByTitle/{num:int?}")]        
        public IActionResult ByTitle(int num=10)
        {
            var quizModel = ((JsonResult)Latest(num)).Value as List<QuizViewModel>;

            return new JsonResult(quizModel, new JsonSerializerSettings() { Formatting = Formatting.Indented });
            
        }

        /// <summary>
        /// GET: api/quiz/mostViewed
        /// Retrieves the {num} random Quizzes
        /// </summary>
        /// <param name="num">the number of quizzes to retrieve</param>
        /// <returns>{num} random Quizzes</returns>
        [HttpGet("Random/{num:int?}")]
        public IActionResult Random(int num = 10)
        {
            var sampleQuizzes = ((JsonResult)Latest(num)).Value
                as List<QuizViewModel>;
            return new JsonResult(
                   sampleQuizzes.OrderBy(t => Guid.NewGuid()),
                   new JsonSerializerSettings()
                   {
                       Formatting = Formatting.Indented
                   });
        }

        #endregion
    }
}
