﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMarket.DAL.Interfaces
{
    public interface IBaseRepository<T>
    {
        bool Create(T entity);
        T Get(int id);
        Task<List<T>> GetAll();
        bool Delete(int id); 
    }
}
