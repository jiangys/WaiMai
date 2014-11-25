 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PP.WaiMai.Model;
using PP.WaiMai.IRepository; 

namespace PP.WaiMai.IService
{ 
	
	public partial interface IAccountService : IBaseService<Account>
    {
      
    }   
	
	public partial interface IConfigService : IBaseService<Config>
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
}