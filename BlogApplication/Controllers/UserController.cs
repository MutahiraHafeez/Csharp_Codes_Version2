using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EAD_Assignment3_BlogApplication.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EAD_Assignment3_BlogApplication.Controllers
{
    public class UserController : Controller
    {
        private readonly IWebHostEnvironment _iwebHost;

        public UserController(IWebHostEnvironment webHostEnvironment)
        {
            _iwebHost = webHostEnvironment;
        }
        public static List<Users> myUser = new List<Users>();
        // GET: /<controller>/
        [HttpGet]
        public ViewResult UserLogin()
        {
            return View();
        }
        [HttpPost]
        public ViewResult UserLogin(Users u)
        {
           

            //if (ModelState.IsValid)
            //{
            //    myUser.Clear();
            //    myUser.Add(u);
                
            //    UserRepository.ReadPost();
            //    return View("ShowPost", UserRepository.post);

            //}
            //else
            //{
            //    ModelState.AddModelError(String.Empty, "Please enter correct data");
            //    return View();
            //}

            if (ModelState.IsValid)
            {
                UserRepository.ReadData();
                foreach (Users s in UserRepository.user)
                {
                    string Email1 = u.Email.ToString().Trim();
                    string Email2 = s.Email.ToString().Trim();
                    if (Email1 == Email2)
                    {
                        myUser.Clear();
                        myUser.Add(u);

                        UserRepository.ReadPost();
                        return View("ShowPost", UserRepository.post);
                    }
                }
                ModelState.AddModelError(String.Empty, "Please enter correct Information");
                return View();

            }
            else
            {
                ModelState.AddModelError(String.Empty, "Please enter correct data");
                return View();
            }

        }
        [HttpGet]
        public ViewResult UserSignUp()
        {
            return View();
        }
        [HttpPost]
        public async Task<ViewResult> UserSignUpAsync(Users u)
        {
            if (ModelState.IsValid)
            {
                myUser.Clear();
                myUser.Add(u);
                if (u.ImageName != null)
                {

                    //string imgType = Path.GetExtension(imgfile.FileName);
                    //var imgPath = Path.Combine(_iwebHost.WebRootPath,"Image", imgfile.FileName);
                    //var filestream = new FileStream(imgPath, FileMode.Create);
                    //await imgfile.CopyToAsync(filestream);
                    //u.ImageName = imgfile.FileName;

                    string wwwRoot = _iwebHost.WebRootPath;
                    string fileName = Path.GetFileNameWithoutExtension(u.ImageFile.FileName);
                    string extension = Path.GetExtension(u.ImageFile.FileName);
                    u.ImageName = fileName = fileName + extension;
                    string path = Path.Combine(wwwRoot + "/Image", fileName);
                    var fileStream = new FileStream(path, FileMode.Create);
                    await u.ImageFile.CopyToAsync(fileStream);


                }
                UserRepository.ReadPost();
                UserRepository.AddUser(u);
                return View("ShowPost",UserRepository.post);
            }
            else
            {

                return View();
            }
        }
        [HttpGet]
        public ViewResult ShowPost()
        {
            return View(UserRepository.post);
        }
        //[HttpGet]
        //public ViewResult ShowPost(String Name)
        //{
        //    string name = null;
        //    foreach (Users s in myUser)
        //    {
        //        Name = s.Name;
        //    }
        //    return View();
        //}
        [HttpGet]
        public ViewResult CreatePost()
        {
           
            return View();
        }
        [HttpPost]
        public ViewResult CreatePost(Posts p)
        {   
            if(ModelState.IsValid)
            {
                foreach(Users s in myUser)
                {
                    p.Name = s.Name;
                }
                
                UserRepository.AddPost(p);
                UserRepository.ReadPost();
                return View("ShowPost",UserRepository.post);

            }
            else
            {
                ModelState.AddModelError(String.Empty, "Please enter correct data");
                return View();
            }
           
        }
        [HttpGet]
        public ViewResult UserProfile()
        {
            return View();
        }
        [HttpPost]
        public ViewResult UserProfile(Users u)
        {
            if (ModelState.IsValid)
            {
                string Name=null;
                foreach (Users s in myUser)
                {
                    Name = s.Name;
                }
                UserRepository.UpdateData(u,Name);

                UserRepository.ReadPost();
                return View("ShowPost", UserRepository.post);

            }
            else
            {
                ModelState.AddModelError(String.Empty, "Please enter correct data");
                return View();
            }
        }
        public ViewResult About()
        {
            return View();
        }
        [HttpGet]
        public ViewResult Delete(int id)
        {
           
            UserRepository.DeletePost(id);
            UserRepository.ReadPost();

            return View("ShowPost", UserRepository.post);
        }
       
        [HttpGet]
        public ViewResult EditPost()
        {
            return View();
        }
        [HttpPost]
        public ViewResult EditPost(Posts p)
        {
      
            foreach (Users s in myUser)
            {
                p.Name = s.Name;
            }
            
            UserRepository.UpdatePost(p);
            UserRepository.ReadPost();

            return View("ShowPost",UserRepository.post);
        }
        
        public ViewResult ChoiceView(int id)
        {
            UserRepository.ReadPost();
            Posts p = UserRepository.post.Find(p => p.Id == id);
            string Name = null;
            foreach (Users s in myUser)
            {
                Name = s.Name;
            }
            string name2 = p.Name.Trim();
            if (!(string.Equals(Name,name2)))
            {
                return View("ViewPost", p);
            }
            else
            {
                return View("OtherPost",p);
            }
            
        }
    }
}
