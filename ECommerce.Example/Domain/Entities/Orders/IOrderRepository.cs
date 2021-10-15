﻿using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Orders
{
    public interface IOrderRepository : IAsyncRepository<Order>
    {

    }
}