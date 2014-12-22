
using System;
using System.Collections.Generic;

namespace PP.WaiMai.IRepository
{
    public partial interface IDbSession
    {
    IConfigRepository ConfigRepository{get;set;}
    IExpendLogRepository ExpendLogRepository{get;set;}
    IFoodMenuRepository FoodMenuRepository{get;set;}
    IFoodMenuCategoryRepository FoodMenuCategoryRepository{get;set;}
    IOrderRepository OrderRepository{get;set;}
    IRechargeRepository RechargeRepository{get;set;}
    IRestaurantRepository RestaurantRepository{get;set;}
    IUserRepository UserRepository{get;set;}
    }
}

