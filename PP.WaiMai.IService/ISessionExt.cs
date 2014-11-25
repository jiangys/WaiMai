

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PP.WaiMai.IService
{
	public partial interface IServiceSession
    { 
		IAccountService IAccountService{get;set;}
		IConfigService IConfigService{get;set;}
		IFoodMenuService IFoodMenuService{get;set;}
		IFoodMenuCategoryService IFoodMenuCategoryService{get;set;}
		IOrderService IOrderService{get;set;}
		IRechargeService IRechargeService{get;set;}
		IRestaurantService IRestaurantService{get;set;}
    }

}