using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDVideoGamesApp.Models
{
    public class VideoGameModel
    {
        public int Id { get; set; }

        public string videoGameName { get; set; }

        public string videoGameDescription { get; set; }
    }
}
