using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApiPrev.Context;
using BlogApiPrev.Controllers;
using BlogApiPrev.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogApiPrev.Services
{
    public class BlogServices
    {
        private readonly DataContext _dataContext;

        public BlogServices(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<BlogModel>> GetBlogsAsync () => await _dataContext.Blogs.ToListAsync();

        public async Task<bool> AddBlogAsync(BlogModel blog)
        {
            await _dataContext.Blogs.AddAsync(blog);
            return await _dataContext.SaveChangesAsync() != 0;
        }

        public async Task<bool> EditBlogAsync (BlogModel blog)
        {
            var blogToEdit = await GetBlogByIdAsync(blog.Id);

            if(blogToEdit == null) return false;

            blogToEdit.Title = blog.Title;
            blogToEdit.Image = blog.Image;
            blogToEdit.Category = blog.Category;
            blogToEdit.Description = blog.Description;
            blogToEdit.Date = blog.Date;
            blogToEdit.PublishedName = blog.PublishedName;
            blogToEdit.IsPublished = blog.IsPublished;
            blogToEdit.IsDeleted = blog.IsDeleted;

            _dataContext.Blogs.Update(blogToEdit);
            return await _dataContext.SaveChangesAsync() != 0;
        }

        private async Task<BlogModel> GetBlogByIdAsync(int id)
        {
            return await _dataContext.Blogs.FindAsync(id);
        }
        //Task will return a promise, a list of blog models by id number passed in. Where is a function that find blog with the same id and returns a list Async!
        public async Task<List<BlogModel>> GetBlogByUserIdAsync(int id) => await _dataContext.Blogs.Where(blog => blog.UserId == id).ToListAsync();

        public async Task<List<BlogModel>> GetBlogByCategoryAsync(string category) => await _dataContext.Blogs.Where(blog => blog.Category == category).ToListAsync();
    }
}