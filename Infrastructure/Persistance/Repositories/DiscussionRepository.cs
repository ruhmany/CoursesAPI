﻿using Core.Entities;
using Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistance.Repositories
{
    public class DiscussionRepository : BaseRepository<Discussion>, IDiscussionRepository
    {
        public DiscussionRepository(ApplicationDbContext Context) : base(Context)
        {
        }
    }
}