﻿using CasaDelight.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaDelight.DataAccess.Repository
{
    public interface IUnitofWork : IDisposable
    {
        IRepository<Dish> Dishes { get; }
        void Save();
    }
}
