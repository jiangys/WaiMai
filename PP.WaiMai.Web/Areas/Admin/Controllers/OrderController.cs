using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PP.WaiMai.WebHelper;
using PagedList;
using System.Transactions;
using PP.WaiMai.Model;
using PP.WaiMai.Model.Enums;

namespace PP.WaiMai.Web.Areas.Admin.Controllers
{
    public class OrderController : BaseController
    {
        //
        // GET: /Admin/Order/
        public ActionResult Index(int? page, string Keyword)
        {
            var model = BLLSession.IOrderService.GetListBy(m => true).OrderByDescending(m => m.OrderID).ToList();
            if (!string.IsNullOrEmpty(Keyword))
            {
                model = model.Where(m => m.FoodMenu.MenuName.Contains(Keyword) || m.User.UserName.Contains(Keyword)).ToList();
            }
            return View(model.ToPagedList(page ?? 1, 15));
        }

        [HttpPost]
        public ActionResult Del(int id)
        {
            try
            {
                //开启事务,保证数据的一致性
                using (var scope = new TransactionScope())
                {
                    var orderModel = BLLSession.IOrderService.GetModel(m => m.OrderID == id);
                    //插入数据到消费流水表
                    BLLSession.IExpendLogService.Add(new ExpendLog()
                    {
                        ConsumeAmount = -orderModel.TotalPrice,
                        RechargeAmount = 0,
                        CreateDate = DateTime.Now,
                        ExpendLogTypeID = id,
                        ExpendLogType = (int)ExpendLogTypeEnum.Order,
                        Description = "取消订餐退款金额"
                    });
                    //更新用户剩余金额
                    var userModel = BLLSession.IUserService.GetModel(m => m.UserID == orderModel.UserID);
                    userModel.Amount = userModel.Amount + orderModel.TotalPrice;
                    BLLSession.IUserService.ModifyModel(userModel);
                    //删除订单
                    orderModel.IsDel = true;
                    BLLSession.IOrderService.ModifyModel(orderModel);

                    scope.Complete();//提交事务 
                }
                return JsonMsgOk("删除成功", "/Admin/Restaurant");
            }
            catch (Exception ex)
            {
                return JsonMsgNoOk(ex.Message);
            }
        }
    }
}