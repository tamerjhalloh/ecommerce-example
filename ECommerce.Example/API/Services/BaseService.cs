﻿using Domain.Interfaces;

namespace API.Services
{
    public class BaseService
    {
        protected internal IUnitOfWork UnitOfWork { get; set; }
        public BaseService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
    }
}
