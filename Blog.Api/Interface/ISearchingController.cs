﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Controllers
{
    public interface ISearchingController<T> where T : class
    {
        Task<List<T>> SearchByText();
    }
}
