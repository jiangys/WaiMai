using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PP.WaiMai.Contracts.Services;
using PP.WaiMai.Services;

namespace PP.WaiMai.WebHelper
{
    public class OperateContext
    {
        /// <summary>
        /// 单例模式
        /// </summary>
        private static OperateContext _instance = null;
        public static OperateContext Instance()
        {
            if (_instance == null)
            {
                _instance = new OperateContext();
            }
            return _instance;
        }

        IFoodMenuCategoryService _IFoodMenuCategoryService;
        public IFoodMenuCategoryService IFoodMenuCategoryService
        {
            get
            {
                if (_IFoodMenuCategoryService == null)
                    _IFoodMenuCategoryService = new FoodMenuCategoryService();
                return _IFoodMenuCategoryService;
            }
            set
            {
                _IFoodMenuCategoryService = value;
            }
        }


        IRestaurantService _IRestaurantService;
        public IRestaurantService IRestaurantService
        {
            get
            {
                if (_IRestaurantService == null)
                    _IRestaurantService = new RestaurantService();
                return _IRestaurantService;
            }
            set
            {
                _IRestaurantService = value;
            }
        }


        IFoodMenuService _IFoodMenuService;
        public IFoodMenuService IFoodMenuService
        {
            get
            {
                if (_IFoodMenuService == null)
                    _IFoodMenuService = new FoodMenuService();
                return _IFoodMenuService;
            }
            set
            {
                _IFoodMenuService = value;
            }
        }
        IOrderService _IOrderService;
        public IOrderService IOrderService
        {
            get
            {
                if (_IOrderService == null)
                    _IOrderService = new OrderService();
                return _IOrderService;
            }
            set
            {
                _IOrderService = value;
            }
        }

        IConfigService _IConfigService;
        public IConfigService IConfigService
        {
            get
            {
                if (_IConfigService == null)
                    _IConfigService = new ConfigService();
                return _IConfigService;
            }
            set
            {
                _IConfigService = value;
            }
        }
    }
}
