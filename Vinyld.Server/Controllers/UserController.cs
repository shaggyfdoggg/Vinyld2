using Microsoft.AspNetCore.Mvc;
using Vinyld.Server.Models;

namespace Vinyld.Server.Controllers
{
    public class UserController : Controller
    {
        VinylDbContext dbContext = new VinylDbContext();
        //public IActionResult Index()
        //{
        //    return View();
        //}

        [HttpGet]
        public List<User> GetAll()
        {
            return dbContext.Users.ToList();
        }

        [HttpGet("{id}")] //provide the lists or search results
        public User GetById(int id)
        {
            return dbContext.Users.FirstOrDefault(u => u.Id == id);
        }

        [HttpGet("{artist}")]
        public User GetArtist(string artist)
        {
            return dbContext.Users.FirstOrDefault(a => a.Artist == artist);
        }

        [HttpGet("{album}")]
        public User GetAlbum(string album)
        {
            return dbContext.Users.FirstOrDefault(a => a.Album == album);
        }

        [HttpDelete("{id}")]
        public User DeleteById(int id)
        {
            User m = dbContext.Users.FirstOrDefault(d => d.Id == id);
            dbContext.Users.Remove(m);
            dbContext.SaveChanges();
            return m;
        }

        [HttpPost] //Add
        public User AddMusic([FromBody] User music)
        {
            dbContext.Users.Add(music);
            dbContext.SaveChanges();
            return music;

        }

        [HttpPatch]
        public User ChangeInfo(int id, string newArtist, string newAlbum)
        {
            User m = dbContext.Users.FirstOrDefault(m => m.Id == id);
            m.Artist = newArtist;
            m.Album = newAlbum;

            dbContext.Users.Update(m);
            dbContext.SaveChanges();
            return m;
        }

        [HttpPut]
        public User ReplaceInfo(int id, [FromBody] User music)
        {
            User m = dbContext.Users.FirstOrDefault(m => m.Id == id);
            m.Id = id;
            m.FirstName = music.FirstName;
            m.LastName = music.LastName;
            m.Artist = music.Artist;
            m.Album = music.Album;

            dbContext.Users.Update(m);
            dbContext.SaveChanges();
            return m;
        }
    }
}
    
