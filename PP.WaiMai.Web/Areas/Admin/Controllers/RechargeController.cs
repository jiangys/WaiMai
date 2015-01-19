using PP.WaiMai.WebHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PP.WaiMai.Model;
using PP.WaiMai.Model.Enums;
using System.Transactions;

namespace PP.WaiMai.Web.Areas.Admin.Controllers
{
    public class RechargeController : BaseController
    {
        //
        // GET: /Admin/Recharge/
        public ActionResult Index(int? page, string Keyword)
        {
            var model = BLLSession.IRechargeService.GetListBy(m => m.IsDel == false)
                .OrderByDescending(m => m.RechargeID).ToList();
            if (!string.IsNullOrEmpty(Keyword))
            {
                model = model.Where(m => m.User.UserName.Contains(Keyword)).ToList();
            }
            return View(model.ToPagedList(page ?? 1, 15));
        }

        /// <summary>
        /// 充值
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RechargeAmount(Recharge model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //开启事务,保证数据的一致性
                    using (var scope = new TransactionScope())
                    {
                        if (!OperateHelper.IsLogin())
                        {
                            return JsonMsgNoOk("对不起，你没权限操作");
                        }
                        if (!OperateHelper.User.IsAdmin)
                        {
                            return JsonMsgNoOk("对不起，你没权限操作");
                        }
                        var userModel = BLLSession.IUserService.GetModel(m => m.UserID == model.UserID);
                        //插入充值表
                        model.Status = (int)RechargeStatusEnum.Succeed;
                        model.IsDel = false;
                        model.CreateDate = DateTime.Now;
                        model.OpeningBalance = userModel.Amount;
                        model.CurrentBalance = userModel.Amount + model.RechargeAmount;
                        model.RechargeUserName = "sys";
                        BLLSession.IRechargeService.Add(model);
                        //更新用户剩余金额
                        userModel.Amount = model.CurrentBalance;
                        BLLSession.IUserService.ModifyModel(userModel);
                        //插入数据到消费流水表
                        BLLSession.IExpendLogService.Add(new ExpendLog()
                        {
                            UserID = model.UserID,
                            ConsumeAmount = 0,
                            RechargeAmount = model.RechargeAmount,
                            CreateDate = DateTime.Now,
                            ExpendLogTypeID = model.RechargeID,
                            ExpendLogType = (int)ExpendLogTypeEnum.Recharge,
                            Description = "充值完成增加金额"
                        });
                        scope.Complete();//提交事务
                    }
                    return JsonMsgOk("充值成功");
                }
                catch (Exception ex)
                {
                    return JsonMsgNoOk(ex.Message);
                }
            }
            return JsonMsgNoOk("充值失败，信息填写有误");
        }
        public ActionResult SelectUser(int? page, string Keyword)
        {
            var model = BLLSession.IUserService.GetListBy(m => m.IsDel == false).OrderBy(m => m.UserID).Skip(2).ToList();
            if (!string.IsNullOrEmpty(Keyword))
            {
                model = model.Where(m => m.UserName.Contains(Keyword)).ToList();
            }
            return View(model.ToPagedList(page ?? 1, 10));
        }
    }
}