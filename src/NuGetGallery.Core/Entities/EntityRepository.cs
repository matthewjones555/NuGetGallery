﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Linq;
using System.Threading.Tasks;

namespace NuGetGallery
{
    public class EntityRepository<T>
        : IEntityRepository<T>
        where T : class, new()
    {
        private readonly IEntitiesContext _entities;

        public EntityRepository(IEntitiesContext entities)
        {
            _entities = entities;
        }

        public async Task CommitChangesAsync()
        {
            await _entities.SaveChangesAsync();
        }

        public void DeleteOnCommit(T entity)
        {
            _entities.Set<T>().Remove(entity);
        }

        public IQueryable<T> GetAll()
        {
            return _entities.Set<T>();
        }

        public void InsertOnCommit(T entity)
        {
            _entities.Set<T>().Add(entity);
        }
    }
}