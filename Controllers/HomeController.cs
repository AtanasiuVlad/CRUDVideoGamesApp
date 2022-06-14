using CRUDVideoGamesApp.Models;
using CRUDVideoGamesApp.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDVideoGamesApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IVideoGamesRepository<VideoGameModel> _videoGamesRepository;
        public HomeController(ILogger<HomeController> logger, IVideoGamesRepository<VideoGameModel> videoGamesRepository)
        {
            _logger = logger;
            _videoGamesRepository = videoGamesRepository;
        }


        [HttpGet]
        [Route("GetVideoGames")]
        public async Task<ActionResult<string>> GetVideoGames()
        {
            try
            {
                var videos = await _videoGamesRepository.GetVideoGames();
                Console.WriteLine(videos);
                return Ok(JsonConvert.SerializeObject(videos));
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex, ex.Message);
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet]
        [Route("GetVideoGameById/{id}")]
        public async Task<ActionResult<string>> GetVideoGameById(int id)
        {
            try
            {
                var video = await _videoGamesRepository.GetEntityById("dbo.sp_getVideoGameById", id);
                return Ok(JsonConvert.SerializeObject(video));
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex, ex.Message);
                return StatusCode(500, ex.Message);
            }
        }
        [HttpDelete]
        [Route("DeleteVideoGame/{id}")]
        public async Task<ActionResult> DeleteVideoGame(int id)
        {
            try
            {
                await _videoGamesRepository.DeleteEntities("dbo.sp_DeleteBikes", id);
                return Ok("201");
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex, ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
