using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EAD_Assignment3_BlogApplication.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EAD_Assignment3_BlogApplication.Controllers
{
    public class AdminController : Controller
    {
        // GET: /<controller>/
        [HttpGet]
        public ViewResult Admin()
        {
            return View();
        }
        [HttpPost]
        public ViewResult Admin(Admin a)
        {
            if(ModelState.IsValid)
            {
                UserRepository.ReadData();
                return View("AllUsers",UserRepository.user);
            }
            else
            {
                return View();
            }
        }
        public ViewResult Remove(int id)
        {
            UserRepository.ReadData();
            Users u = UserRepository.user.Find(u => u.Id == id);
            UserRepository.RemoveData(u.Name);

            UserRepository.ReadData();
            return View("AllUsers", UserRepository.user);
        }
        public ViewResult Details(int id)
        {
            UserRepository.ReadData();
            Users u = UserRepository.user.Find(u => u.Id == id);
            UserRepository.ReadSomePost(u.Name);

            return View("Info", UserRepository.post);
        }
        [HttpGet]
        public ViewResult Edit(int id)
        {
            UserRepository.ReadData();
            Users u = UserRepository.user.Find(u => u.Id == id);
            return View("Edit");
        }
        [HttpPost]
        public ViewResult Edit(Users u)
        {
            if (ModelState.IsValid)
            {
                UserRepository.ReadData();
                foreach (Users usr in UserRepository.user)
                {
                    if (usr.Id == u.Id)
                    {
                        UserRepository.UpdateData(u, usr.Name);
                        break;
                    }
                }
                UserRepository.ReadData();
                return View("AllUsers",UserRepository.user);
            }
            else
            {
                ModelState.AddModelError(String.Empty, "Please enter correct data");
                return View();
            }
        }
        [HttpGet]
        public ViewResult AddUser()
        {
            return View();
        }
        [HttpPost]
        public ViewResult AddUser(Users u)
        {
            if (ModelState.IsValid)
            {
                UserRepository.AddUser(u);
                UserRepository.ReadData();
                return View("AllUsers", UserRepository.user);
            }
            else
            {
                return View();
            }
        }
    }
}
