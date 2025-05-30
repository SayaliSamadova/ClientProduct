﻿using ClientProductCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClientProductCore.Domain.Interfaces
{
    public interface ICrudRepository<T> where T : IDbEntity
    {
        int Add(T item);
        void Update(T item);
        void Delete(int id);
        List<T> GetAll();
        T Get(int id);
    }
}
