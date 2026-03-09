using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApiPrev.Models;
using BlogApiPrev.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogApiPrev.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    //controllers should ONLY inherit controllerBase!! Separations of Concerns 
    public class BlogController : ControllerBase // we are inheriting our http and Iactionresult from ControllerBase
    {
        private readonly BlogServices _blogServices;
        // It allows us to inject our functions into our controller!
        //Upon load a constructor runs first to give our methods 
        public BlogController(BlogServices blogServices)
        {
            _blogServices = blogServices;
        }

        [HttpGet("GetBlogs")]
        public async Task<IActionResult> GetAllBlogs()
        {
            var blogs = await _blogServices.GetBlogsAsync();

            if (blogs != null) return Ok(blogs);

            return NotFound(new { Message = "No blogs " });
        }

        [HttpGet("GetBlogsByUserId/{userId}")]
        public async Task<IActionResult> GetAllBlogsByUserId(int userId)
        {
            var blogs = await _blogServices.GetBlogByUserIdAsync(userId);

            if (blogs != null) return Ok(new { blogs });

            return NotFound(new { Message = "No blogs " });
        }

        [HttpPost("AddBlog")]
        public async Task<IActionResult> AddBlog(BlogModel blog)
        {
            if (blog == null)
            {
                return BadRequest("Blog data is required.");
            }
            var success = await _blogServices.AddBlogAsync(blog);

            if (success) return Ok(new { success });

            return BadRequest(new { success });
        }

        [HttpPut("EditBlog")]
        public async Task<IActionResult> EditBlog(BlogModel blog)
        {
            var success = await _blogServices.EditBlogAsync(blog);

            if (success) return Ok(new { success });

            return BadRequest(new { success });
        }

        [HttpDelete("DeletePost")]
        public async Task<IActionResult> DeleteBlogPost(BlogModel blog)
        {
            var success = await _blogServices.EditBlogAsync(blog);

            if (success) return Ok(new { success });

            return BadRequest(new { success });
        }

        [HttpGet("GetBlogByCategory/{category}")]
        public async Task<IActionResult> GetBlogByCategory(string category)
        {
            var blogs = await _blogServices.GetBlogByCategoryAsync(category);

            if (blogs != null) return Ok(new { blogs });

            return BadRequest(new { Message = "No blogs " });
        }
    }
}