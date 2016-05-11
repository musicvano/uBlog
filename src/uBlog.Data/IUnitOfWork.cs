﻿using System;
using uBlog.Data.Repositories;

namespace uBlog.Data
{
    public interface IUnitOfWork : IDisposable
    {
        IPostRepository Posts { get; }
        ICommentRepository Comments { get; }
        ITagRepository Tags { get; }
        ISettingRepository Settings { get; }
        int Save();
    }
}