﻿using System;
using System.Collections.Generic;
using System.Text;
using WNRY.Models.ViewModels;

namespace WNRY.Services.Interfaces
{
    public interface IProductService
    {
        IEnumerable<ProductVM> GetAll();
    }
}
