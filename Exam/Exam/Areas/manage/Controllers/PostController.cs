using Exam.Helpers;
using Exam.Models;
using Microsoft.AspNetCore.Mvc;

namespace Exam.Areas.manage.Controllers
{
    [Area("manage")]
    public class PostController : Controller
    {
        private readonly Context _context;
        private readonly IWebHostEnvironment _web;

        public PostController(Context context,IWebHostEnvironment web)
        {
            this._context = context;
            this._web = web;
        }
        public IActionResult Index()
        {
            List<Post> posts = _context.Posts.ToList();
            return View(posts);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Post post)
        {
            if(post.ImageFile.ContentType != "image/png"&& post.ImageFile.ContentType != "image/jpeg")
            {
                ModelState.AddModelError("ImageFile", "Only .jpeg and .png");
                return View();
            }
           post.Image= FileManager.SaveFile(_web.WebRootPath, "uploads/posts", post.ImageFile);
            _context.Posts.Add(post);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            Post post = _context.Posts.Find(id);
            return View(post);
        }
        [HttpPost]
        public IActionResult Update(Post post)
        {
            Post expost = _context.Posts.FirstOrDefault(x => x.Id == post.Id);
            if (post != null)
            {
                if (post.ImageFile != null)
                {
                    if (post.ImageFile.ContentType != "image/png" && post.ImageFile.ContentType != "image/jpeg")
                    {
                        ModelState.AddModelError("ImageFile", "Only .jpeg and .png");
                        return View();
                    }

                    string name = FileManager.SaveFile(_web.WebRootPath, "uploads/posts", post.ImageFile);
                    FileManager.DeletePath(_web.WebRootPath, "uploads/posts", expost.Image);
                    post.Image = name;
                }
            }
                _context.SaveChanges();
                return RedirectToAction("Index");
        }

        [HttpGet]

        [HttpPost]
        public IActionResult Delete(int id)
        {
            Post post = _context.Posts.FirstOrDefault(x=>x.Id==id);
            if (post.Image != null)
            {
                FileManager.DeletePath(_web.WebRootPath, "uploads/posts", post.Image);
            }

            _context.Posts.Remove(post);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
