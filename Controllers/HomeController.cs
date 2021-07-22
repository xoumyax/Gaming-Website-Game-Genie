using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GameGenie.Models;

namespace GameGenie.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string userid, string password)
        {
            gamegenie_dbEntities db = new gamegenie_dbEntities();
            var data = db.Profiles.Where(s => s.UserId.Equals(userid) && s.Password.Equals(password)).FirstOrDefault();
            if (data!=null)
            {
                ViewBag.name = data.Name;
                return RedirectToAction("ViewPage",data);
            }
            return Content("<script>alert('Invalid UserId or Password')</script>");
        }
        [HttpGet]
        public ActionResult ViewPage(Profile emp)
        {
            gamegenie_dbEntities db = new gamegenie_dbEntities();
            var score1 = db.GuessNumbers.FirstOrDefault(s=>s.UserId.Equals(emp.UserId));
            var score2 = db.MemoryGames.FirstOrDefault(s => s.UserId.Equals(emp.UserId));
            var score3 = db.Pacmen.FirstOrDefault(s => s.UserId.Equals(emp.UserId));
            var score4 = db.RockPaperScissors.FirstOrDefault(s => s.UserId.Equals(emp.UserId));
            var score5 = db.Tetris.FirstOrDefault(s => s.UserId.Equals(emp.UserId));
            ViewBag.GuessNumber = (score1 != null) ? score1.Score : 0;
            ViewBag.Pacmen = (score3 != null )? score3.Score : 0;
            ViewBag.MemoryGame = (score2 != null) ? score2.Score : 0;
            ViewBag.RockPaperSiccor = (score4 != null) ? score4.Score : 0;
            ViewBag.Tetris = (score5 != null) ? score5.Score : 0;
            return View(emp);
        }
        public ActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Savedata(Profile emp)
        {
            if (ModelState.IsValid)
            {
                using (gamegenie_dbEntities db = new gamegenie_dbEntities())
                {
                    var data = db.Profiles.Where(s => s.UserId.Equals(emp.UserId)).ToList();
                    if (data.Count() == 0)
                    {
                        db.Profiles.Add(emp);
                        db.SaveChanges();
                        return View("Login");
                    }
                    else
                    {
                        return Content("<script>alert('UserId is already taken. Try another one..')</script>");
                    }
                }
            }
            else
            {
                return View("Signup");
            }
        }
        public ActionResult Forgot()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Forgot(string userid, string email, string password)
        {
            gamegenie_dbEntities db = new gamegenie_dbEntities();
            var data = db.Profiles.Where(s => s.UserId.Equals(userid) && s.Email.Equals(email)).ToList();
            if (data.Count() > 0)
            {
                var userdetail = db.Profiles.FirstOrDefault(s => s.Email.Equals(email));
                userdetail.Password = password;
                db.SaveChanges();
                return View("Login");
            }
            return Content("<script>alert('Wrong Information')</script>");
        }
        public ActionResult GuessNumber(Profile user)
        {
            return View(user);
        }
        public ActionResult Pacman(Profile user)
        {
            return View(user);
        }
        public ActionResult RockPaperSiccor(Profile user)
        {
            return View(user);
        }
        public ActionResult MemoryGame(Profile user)
        {
            return View(user);
        }
        public ActionResult Tetris(Profile user)
        {
            return View(user);
        }
        [HttpPost]
        public ActionResult Update1(GuessNumber std)
        {
            gamegenie_dbEntities db = new gamegenie_dbEntities();
            var exituser = db.GuessNumbers.Where(s => s.UserId.Equals(std.UserId)).ToList();
            if(exituser.Count()==1)
            {
                var detail = db.GuessNumbers.FirstOrDefault(s => s.UserId.Equals(std.UserId));
                if(detail.Score<std.Score)
                {
                    detail.Score = std.Score;
                    db.SaveChanges();
                }
            }
            else
            {
                db.GuessNumbers.Add(std);
                db.SaveChanges();
            }
            return View();
        }
        [HttpPost]
        public ActionResult Update2(Pacman std)
        {
            gamegenie_dbEntities db = new gamegenie_dbEntities();
            var exituser = db.Pacmen.Where(s => s.UserId.Equals(std.UserId)).ToList();
            if (exituser.Count() == 1)
            {
                var detail = db.Pacmen.FirstOrDefault(s => s.UserId.Equals(std.UserId));
                if (detail.Score < std.Score)
                {
                    detail.Score = std.Score;
                    db.SaveChanges();
                }
            }
            else
            {
                db.Pacmen.Add(std);
                db.SaveChanges();
            }
            return View();
        }
        [HttpPost]
        public ActionResult Update3(MemoryGame std)
        {
            gamegenie_dbEntities db = new gamegenie_dbEntities();
            var exituser = db.MemoryGames.Where(s => s.UserId.Equals(std.UserId)).ToList();
            if (exituser.Count() == 1)
            {
                var detail = db.MemoryGames.FirstOrDefault(s => s.UserId.Equals(std.UserId));
                if (detail.Score < std.Score)
                {
                    detail.Score = std.Score;
                    db.SaveChanges();
                }
            }
            else
            {
                db.MemoryGames.Add(std);
                db.SaveChanges();
            }
            return View();
        }
        [HttpPost]
        public ActionResult Update4(RockPaperScissor std)
        {
            gamegenie_dbEntities db = new gamegenie_dbEntities();
            var exituser = db.RockPaperScissors.Where(s => s.UserId.Equals(std.UserId)).ToList();
            if (exituser.Count() == 1)
            {
                var detail = db.RockPaperScissors.FirstOrDefault(s => s.UserId.Equals(std.UserId));
                if (detail.Score < std.Score)
                {
                    detail.Score = std.Score;
                    db.SaveChanges();
                }
            }
            else
            {
                db.RockPaperScissors.Add(std);
                db.SaveChanges();
            }
            return View();
        }
        [HttpPost]
        public ActionResult Update5(Tetri std)
        {
            gamegenie_dbEntities db = new gamegenie_dbEntities();
            var exituser = db.Tetris.Where(s => s.UserId.Equals(std.UserId)).ToList();
            if (exituser.Count() == 1)
            {
                var detail = db.Tetris.FirstOrDefault(s => s.UserId.Equals(std.UserId));
                if (detail.Score < std.Score)
                {
                    detail.Score = std.Score;
                    db.SaveChanges();
                }
            }
            else
            {
                db.Tetris.Add(std);
                db.SaveChanges();
            }
            return View();
        }
    }
}