using Microsoft.AspNetCore.Mvc;
using Vinyld.Server.Models;

namespace Vinyld.Server.Controllers
{
    public class FavoriteController : Controller
    {
        VinylDbContext dbContext = new VinylDbContext();
        //public IActionResult Index()
        //{
        //    return View();
        //}

        [HttpGet]
        public List<Favorite> GetAll()
        {
            return dbContext.Favorites.ToList();
        }

        [HttpGet("{id}")]
        public Favorite GetById(int id)
        {
            return dbContext.Favorites.FirstOrDefault(f => f.Id == id);
        }

        [HttpPost]
        public Favorite AddFavorite([FromBody] Favorite newFav)
        {
            Favorite favorite = new Favorite();
            int x = 0;
            foreach (Favorite f in dbContext.Favorites)
            {
                if (newFav.UserId == f.UserId && newFav.FavoriteItem == f.FavoriteItem)
                {
                    x++;
                }
            }
            if (x==0)
            {
                favorite.UserId = newFav.UserId;
                favorite.FavoriteItem = newFav.FavoriteItem;
                dbContext.Favorites.Add(favorite);
                dbContext.SaveChanges();
            }
            return favorite;
        }

        [HttpDelete("{id}")]
        public Favorite DeleteById(int id)
        {
            Favorite deleted = dbContext.Favorites.Find(id);
            dbContext.Favorites.Remove(deleted);
            dbContext.SaveChanges();
            return deleted;
        }

        [HttpPatch]
        public Favorite ChangeInfo(int id, int userId, string favoriteItem)
        {
            Favorite f = dbContext.Favorites.FirstOrDefault(f => f.Id == id);
            f.UserId = userId;
            f.FavoriteItem = favoriteItem;

            dbContext.Favorites.Update(f); dbContext.SaveChanges(); return f;
        }

        //[HttpPut]
        //public User ReplaceFavorite(int id, [FromBody] Favorite favorite)
        //{
        //    Favorite f = dbContext.Favorites.FirstOrDefault(f => f.Id == id);
        //    f.Id = id;
        //    f.UserId = favorite.UserId;
        //    f.FavoriteItem = favorite.FavoriteItem;

        //    dbContext.Favorites.Update(f);
        //    dbContext.SaveChanges();
        //    return f;
        //}

        [HttpPut("{id}")]
        public Favorite PutFavorite([FromBody] Favorite favorite)
        {
            dbContext.Favorites.Update(favorite);
            dbContext.SaveChanges();
            return favorite;
        }
    }
}

//[HttpDelete("{questionId}/{userId}")]
//public IActionResult DeleteFavoriteByIds(int questionId, string userId)
//{
//    Favorite deleted = dBContext.Favorites.FirstOrDefault(f => f.QuestionId == questionId && f.UserId == userId);

//    if (deleted != null)
//    {
//        dBContext.Favorites.Remove(deleted);
//        dBContext.SaveChanges();
//        return Ok(deleted);
//    }

//    return NotFound(); // Or you can return a different status code based on your requirements
//}
//check out this method once you implement google id
 
