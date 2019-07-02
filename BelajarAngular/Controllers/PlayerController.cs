using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BelajarAngular.Models;    

namespace BelajarAngular.Controllers
{
    public class PlayerController : Controller
    {
        private CrudContext _context = null;

        public PlayerController()
        {
            _context = new CrudContext();
        }

        // GET: Player
        public JsonResult GetPlayers()   //All
        {
            List<Player> listPlayers = _context.Players.ToList();
            return Json(new { list = listPlayers}, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetPlayerById(int id) //By ID
        {
            Player player = _context.Players.Where(x => x.PlayerId == id).SingleOrDefault();
            return Json(new { player = player }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult AddPlayer(Player player) //Insert
        {
            _context.Players.Add(player);
            _context.SaveChanges();
            return Json(new { status = "Player Added Successfully" });
        }

        public JsonResult UpdatePlayer(Player player) //Update
        {
            _context.Entry(player).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
            return Json(new { status = "Player Update Successfully" });
        }

        public JsonResult DeletePlayer(int id) //Delete
        {
            Player player = _context.Players.Where(x => x.PlayerId == id).SingleOrDefault();
            _context.Players.Remove(player);
            _context.SaveChanges();
            return Json(new { status = "Player Delete Successfully" });
        }
    }
}