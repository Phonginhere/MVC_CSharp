﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication_Blog_Tags.Models;
using Newtonsoft.Json;

namespace PersonalBlogTemplateWithServices.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog  
        public ActionResult Index()
        {
            // Read the list  
            var blogs = PostManager.Read();
            if (blogs == null)
            {
                ViewBag.Empty = true;
                return View();
            }
            else
            {
                // Just for sorting.  
                blogs = (from blog in blogs
                         orderby blog.CreateTime descending
                         select blog).ToList();

                ViewBag.Empty = false;
                return View(blogs);
            }
        }

        [Route("blog/read/{id}")] // Set the ID parameter  
        public ActionResult Read(int id)
        {
            // Read one single blog  
            var blogs = PostManager.Read();
            BlogPostModel post = null;

            if (blogs != null && blogs.Count > 0)
            {
                post = blogs.Find(x => x.ID == id);
            }

            if (post == null)
            {
                ViewBag.PostFound = false;
                return View();
            }
            else
            {
                ViewBag.PostFound = true;
                return View(post);
            }
        }

        public ActionResult Create()
        {
            if (Request.HttpMethod == "POST")
            {
                // Post request method  
                var title = Request.Form["title"].ToString();
                var tags = Request.Form["tags"].ToString().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                var content = Request.Form["content"].ToString();

                // Save content  
                var post = new BlogPostModel { Title = title, CreateTime = DateTime.Now, Content = content, Tags = tags.ToList() };
                PostManager.Create(JsonConvert.SerializeObject(post));

                // Redirect  
                Response.Redirect("~/blog");
            }
            return View();
        }

        [Route("blog/edit/{id}")]
        public ActionResult Edit(int id)
        {
            if (Request.HttpMethod == "POST")
            {
                // Post request method  
                var title = Request.Form["title"].ToString();
                var tags = Request.Form["tags"].ToString().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                var content = Request.Form["content"].ToString();

                // Save content  
                var post = new BlogPostModel { Title = title, CreateTime = DateTime.Now, Content = content, Tags = tags.ToList() };
                PostManager.Update(id, JsonConvert.SerializeObject(post));

                // Redirect  
                Response.Redirect("~/blog");
            }
            else
            {
                // Find the required post.  
                var post = PostManager.Read().Find(x => x.ID == id);

                if (post != null)
                {
                    // Set the values  
                    ViewBag.Found = true;
                    ViewBag.PostTitle = post.Title;
                    ViewBag.Tags = post.Tags;
                    ViewBag.Content = post.Content;
                }
                else
                {
                    ViewBag.Found = false;
                }
            }

            // Finally return the view.  
            return View();
        }
    }
}