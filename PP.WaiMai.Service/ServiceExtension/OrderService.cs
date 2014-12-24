using PP.WaiMai.IService;
using PP.WaiMai.Model;
using PP.WaiMai.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace PP.WaiMai.Service
{
    public partial class OrderService : BaseService<Order>, IOrderService
    {
        public OrderService()
            : base()
        {

        }

        /// <summary>
        /// 取消订单
        /// </summary>
        /// <param name="id">订单ID</param>
        /// <returns></returns>
        public bool OrderCancel(int id)
        {
            try
            { 
                var orderModel = DbSessionContext.OrderRepository.GetModel(m => m.OrderID == id);
                if (orderModel.OrderStatus==(int)OrderStatusEnum.Succeed)
                {
                    return false;
                }
                //开启事务,保证数据的一致性
                using (var scope = new TransactionScope())
                {
                    //插入数据到消费流水表
                    DbSessionContext.ExpendLogRepository.Add(new ExpendLog()
                    {
                        UserID = orderModel.UserID,
                        ConsumeAmount = -orderModel.TotalPrice,
                        RechargeAmount = 0,
                        CreateDate = DateTime.Now,
                        ExpendLogTypeID = id,
                        ExpendLogType = (int)ExpendLogTypeEnum.Order,
                        Description = "取消订餐退款金额"
                    });
                    //更新用户剩余金额
                    var userModel = DbSessionContext.UserRepository.GetModel(m => m.UserID == orderModel.UserID);
                    userModel.Amount = userModel.Amount + orderModel.TotalPrice;
                    DbSessionContext.UserRepository.ModifyModel(userModel);
                    //更新订单状态为已取消
                    orderModel.OrderStatus = (int)OrderStatusEnum.Cancel;
                    orderModel.EditDate = DateTime.Now;
                    DbSessionContext.OrderRepository.ModifyModel(orderModel);
                    scope.Complete();//提交事务 
                }
                return true;
            }
            catch (Exception ex)
            {
                //写入日志
                return false;
            }
        }
    }
}
