

 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PP.WaiMai.Model;
using PP.WaiMai.IRepository; 

namespace PP.WaiMai.IService
{ 
	
	public partial interface ICommentService : IBaseService<Comment>
    {
      
    }   
	
	public partial interface IConfigService : IBaseService<Config>
    {
      
    }   
	
	public partial interface IExpendLogService : IBaseService<ExpendLog>
    {
      
    }   
	
	public partial interface IFeedbackService : IBaseService<Feedback>
    {
      
    }   
	
	public partial interface IFoodMenuService : IBaseService<FoodMenu>
    {
      
    }   
	
	public partial interface IFoodMenuCategoryService : IBaseService<FoodMenuCategory>
    {
      
    }   
	
	public partial interface IOrderService : IBaseService<Order>
    {
      
    }   
	
	public partial interface IRechargeService : IBaseService<Recharge>
    {
      
    }   
	
	public partial interface IRestaurantService : IBaseService<Restaurant>
    {
      
    }   
	
	public partial interface ISarcasmService : IBaseService<Sarcasm>
    {
      
    }   
	
	public partial interface IUserService : IBaseService<User>
    {
      
    }   

}