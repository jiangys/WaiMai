


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PP.WaiMai.Model;
using PP.WaiMai.IService; 

namespace PP.WaiMai.Service
{
    
	
	public partial class ConfigService : BaseService<Config>,IConfigService
    {
        public override void SetCurrentRepository()
        {
            //设置处理当前请求的仓储
            this.CurrentRepository = DbSessionContext.ConfigRepository;
        }
    }   
	
	public partial class ExpendLogService : BaseService<ExpendLog>,IExpendLogService
    {
        public override void SetCurrentRepository()
        {
            //设置处理当前请求的仓储
            this.CurrentRepository = DbSessionContext.ExpendLogRepository;
        }
    }   
	
	public partial class FoodMenuService : BaseService<FoodMenu>,IFoodMenuService
    {
        public override void SetCurrentRepository()
        {
            //设置处理当前请求的仓储
            this.CurrentRepository = DbSessionContext.FoodMenuRepository;
        }
    }   
	
	public partial class FoodMenuCategoryService : BaseService<FoodMenuCategory>,IFoodMenuCategoryService
    {
        public override void SetCurrentRepository()
        {
            //设置处理当前请求的仓储
            this.CurrentRepository = DbSessionContext.FoodMenuCategoryRepository;
        }
    }   
	
	public partial class OrderService : BaseService<Order>,IOrderService
    {
        public override void SetCurrentRepository()
        {
            //设置处理当前请求的仓储
            this.CurrentRepository = DbSessionContext.OrderRepository;
        }
    }   
	
	public partial class RechargeService : BaseService<Recharge>,IRechargeService
    {
        public override void SetCurrentRepository()
        {
            //设置处理当前请求的仓储
            this.CurrentRepository = DbSessionContext.RechargeRepository;
        }
    }   
	
	public partial class RestaurantService : BaseService<Restaurant>,IRestaurantService
    {
        public override void SetCurrentRepository()
        {
            //设置处理当前请求的仓储
            this.CurrentRepository = DbSessionContext.RestaurantRepository;
        }
    }   
	
	public partial class UserService : BaseService<User>,IUserService
    {
        public override void SetCurrentRepository()
        {
            //设置处理当前请求的仓储
            this.CurrentRepository = DbSessionContext.UserRepository;
        }
    }   
}