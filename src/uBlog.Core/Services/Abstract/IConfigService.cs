﻿namespace uBlog.Core.Services
{
    public interface IConfigService
    {
        string Author { get; }
        string About { get; }
        string Photo { get; }
        string Email { get; }
        string Url { get; }
        string Github { get; }
        string Facebook { get; }
        string Twitter { get; }
        string Skype { get; }
        string Location { get; }
    }
}