
using System;
using System.Collections.Generic;

namespace PP.WaiMai.IRepository
{
    public partial interface IDbSession
    {
    ICommentRepository CommentRepository{get;set;}
    IConfigRepository ConfigRepository{get;set;}
    IExpendLogRepository ExpendLogRepository{get;set;}
    IFeedbackRepository FeedbackRepository{get;set;}
    IFoodMenuRepository FoodMenuRepository{get;set;}
    IFoodMenuCategoryRepository FoodMenuCategoryRepository{get;set;}
    IOrderRepository OrderRepository{get;set;}
    IRechargeRepository RechargeRepository{get;set;}
    IRestaurantRepository RestaurantRepository{get;set;}
    ISarcasmRepository SarcasmRepository{get;set;}
    IsysdiagramsRepository sysdiagramsRepository{get;set;}
    IUserRepository UserRepository{get;set;}
    }
}

