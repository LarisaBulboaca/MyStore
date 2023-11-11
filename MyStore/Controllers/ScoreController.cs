using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyStore.Domain;
using MyStore.Helpers;
using MyStore.Models;
using MyStore.Services;

namespace MyStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScoreController : Controller
    {
        private readonly IScoreService scoreService;

        public ScoreController(IScoreService scoreService)
        {
            this.scoreService = scoreService;
        }

        // GET: api/<ScoreController>
        [HttpGet]
        public IEnumerable<ScoreModel> Get()
        {
            var allScores = scoreService.GetScores();

            var modelsToReturn = new List<ScoreModel>();
            foreach (var score in allScores)
            {
                modelsToReturn.Add(score.ToScoreModel());
            }

            return modelsToReturn;
        }

        // GET api/<ScoreController>/5
        [HttpGet("{id}")]
        public ActionResult<Score> GetById(int id)
        {
            var scoreFromDb = scoreService.GetScore(id);

            if (scoreFromDb == null)
            {
                return NotFound();
            }

            var model = new ScoreModel();
            model = scoreFromDb.ToScoreModel();

            return Ok(model);
        }
        // PUT api/<ScoreController>/5

        [HttpPut("{id}")]
        public ActionResult<ScoreModel> Update(int id, ScoreModel model)
        {
            var existingScore = scoreService.GetScore(id);
            if (existingScore == null)
            {
                return NotFound();
            }

            TryUpdateModelAsync(existingScore);

            var scoreToUpdate = new Score();
            scoreToUpdate = model.ToScore();
            scoreService.Update(scoreToUpdate);

            return Ok(scoreToUpdate.ToScoreModel());
        }

        // POST api/<ScoreController>
        [HttpPost]
        public IActionResult Create(ScoreModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var scoreToSave = new Score();
            scoreToSave = model.ToScore();


            scoreService.InsertNew(scoreToSave);

            model.Score1 = scoreToSave.Score1;

            return CreatedAtAction(nameof(GetById), new { id = scoreToSave.Score1 }, model);

        }

        // DELETE api/<ScoreController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var score = scoreService.GetScore(id);
            if (score == null)
            {
                return NotFound(score);
            }

            scoreService.Remove(score);

            return NoContent();
        }
    }
}
