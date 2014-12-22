

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PP.WaiMai.IService; 

namespace PP.WaiMai.Service
{
	public partial class ServiceSession:IService.IServiceSession
    {
		#region 业务接口 IConfigService
		IConfigService iConfigService;
		public IConfigService IConfigService
		{
			get
			{
				if(iConfigService==null)
					iConfigService= new ConfigService();
				return iConfigService;
			}
			set
			{
				iConfigService= value;
			}
		}
		#endregion

		#region 业务接口 IExpendLogService
		IExpendLogService iExpendLogService;
		public IExpendLogService IExpendLogService
		{
			get
			{
				if(iExpendLogService==null)
					iExpendLogService= new ExpendLogService();
				return iExpendLogService;
			}
			set
			{
				iExpendLogService= value;
			}
		}
		#endregion

		#region 业务接口 IFoodMenuService
		IFoodMenuService iFoodMenuService;
		public IFoodMenuService IFoodMenuService
		{
			get
			{
				if(iFoodMenuService==null)
					iFoodMenuService= new FoodMenuService();
				return iFoodMenuService;
			}
			set
			{
				iFoodMenuService= value;
			}
		}
		#endregion

		#region 业务接口 IFoodMenuCategoryService
		IFoodMenuCategoryService iFoodMenuCategoryService;
		public IFoodMenuCategoryService IFoodMenuCategoryService
		{
			get
			{
				if(iFoodMenuCategoryService==null)
					iFoodMenuCategoryService= new FoodMenuCategoryService();
				return iFoodMenuCategoryService;
			}
			set
			{
				iFoodMenuCategoryService= value;
			}
		}
		#endregion

		#region 业务接口 IOrderService
		IOrderService iOrderService;
		public IOrderService IOrderService
		{
			get
			{
				if(iOrderService==null)
					iOrderService= new OrderService();
				return iOrderService;
			}
			set
			{
				iOrderService= value;
			}
		}
		#endregion

		#region 业务接口 IRechargeService
		IRechargeService iRechargeService;
		public IRechargeService IRechargeService
		{
			get
			{
				if(iRechargeService==null)
					iRechargeService= new RechargeService();
				return iRechargeService;
			}
			set
			{
				iRechargeService= value;
			}
		}
		#endregion

		#region 业务接口 IRestaurantService
		IRestaurantService iRestaurantService;
		public IRestaurantService IRestaurantService
		{
			get
			{
				if(iRestaurantService==null)
					iRestaurantService= new RestaurantService();
				return iRestaurantService;
			}
			set
			{
				iRestaurantService= value;
			}
		}
		#endregion

		#region 业务接口 IUserService
		IUserService iUserService;
		public IUserService IUserService
		{
			get
			{
				if(iUserService==null)
					iUserService= new UserService();
				return iUserService;
			}
			set
			{
				iUserService= value;
			}
		}
		#endregion

    }

}