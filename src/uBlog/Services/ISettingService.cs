﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using uBlog.Data.Entities;

namespace uBlog.Services
{
    public interface ISettingService
    {
        Settings Settings { get; set; }
    }
}