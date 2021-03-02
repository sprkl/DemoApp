﻿using System.Collections.Generic;
using System.Threading.Tasks;
using DemoApp.Domain.Entities;
using Refit;

namespace DemoApp.Application.HttpServices.Posts
{
    public interface IPostService
    {
        [Get("/posts")]
        Task<List<Post>> ListPostAsync();
        
        [Get("/posts/{postId}")]
        Task<Post> GetPostAsync([AliasAs("postId")] long postId);
    }
}