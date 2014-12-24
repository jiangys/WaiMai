using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PP.WaiMai.IService
{
    public interface IBaseService<T> where T : class,new()
    {
        #region 1.0 新增 实体 +int Add(T model)
        /// <summary>
        /// 新增 实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int Add(T model);
        #endregion

        #region 2.0 根据 id 删除 +int Delete(T model)
        /// <summary>
        /// 根据 id 删除
        /// </summary>
        /// <param name="model">包含要删除id的对象</param>
        /// <returns></returns>
        int Delete(T model);
        #endregion

        #region 3.0 根据条件删除 +int DeleteBy(Expression<Func<T, bool>> delWhere)
        /// <summary>
        /// 3.0 根据条件删除
        /// </summary>
        /// <param name="delWhere"></param>
        /// <returns></returns>
        int DeleteBy(Expression<Func<T, bool>> delWhere);
        #endregion

        #region 4.0 修改 +int Modify(T model, params string[] proNames)
        /// <summary>
        /// 4.0 修改，如：Modify(new Model.UserInfo() { ID = id, Password = password }, "Password");
        /// Modify(model, "pName", "pAreaName", "pControllerName");
        /// </summary>
        /// <param name="model">要修改的实体对象</param>
        /// <param name="proNames">要修改的 属性 名称</param>
        /// <returns></returns>
        int Modify(T model, params string[] proNames);
        #endregion

        #region 4.1同一个上下文，修改实体，适用先查询实体，再更新+int ModifyModel(T entity)
        /// <summary>
        /// 同一个上下文，修改实体，
        /// 适用先查询实体，再更新
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        int ModifyModel(T entity);
        #endregion

        #region 4.2 批量修改 +int Modify(T model, Expression<Func<T, bool>> whereLambda, params string[] modifiedProNames)
        /// <summary>
        /// 4.2 批量修改
        /// 使用用例子： var model = BLLSession.IOrderService.ModifyBy(new Order() { OrderStatus = (int)OrderStatusEnum.Succeed }, m => m.OrderStatus == (int)OrderStatusEnum.Handle, new string[]{"OrderStatus"});
        /// </summary>
        /// <param name="model">要修改的实体对象</param>
        /// <param name="whereLambda">查询条件</param>
        /// <param name="proNames">要修改的 属性 名称</param>
        /// <returns></returns>
        int ModifyBy(T model, Expression<Func<T, bool>> whereLambda, params string[] modifiedProNames);
        #endregion

        T GetModel(System.Linq.Expressions.Expression<Func<T, bool>> whereLambda);

        #region 5.0 根据条件查询 +List<T> GetListBy(Expression<Func<T,bool>> whereLambda)
        /// <summary>
        /// 5.0 根据条件查询 +List<T> GetListBy(Expression<Func<T,bool>> whereLambda)
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        List<T> GetListBy(Expression<Func<T, bool>> whereLambda);
        #endregion

        #region 6.1 分页查询 输出总行数 + List<T> GetPagedList<TKey>
        /// <summary>
        /// 6.1 分页查询 输出总行数 + List<T> GetPagedList<TKey>
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="rowCount"></param>
        /// <param name="whereLambda"></param>
        /// <param name="orderBy"></param>
        /// <returns></returns>
        List<T> GetPagedList<TKey>(int pageIndex, int pageSize, ref int rowCount, Expression<Func<T, bool>> whereLambda, Expression<Func<T, TKey>> orderBy, bool isAsc = true);
        #endregion

        #region 6.2 分页查询 +void GetPagedList<TKey>
        /// <summary>
        /// 6.2 分页查询
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="pagedData">分页模型（页码，页容量；总行数，当前页数据集合）</param>
        /// <param name="whereLambda">查询条件</param>
        /// <param name="orderBy">排序条件</param>
        /// <param name="isAsc">是否升序</param>
        /// <param name="joinPropertyNames">join属性名</param>
        void GetPagedList<TKey>(
            Model.FormatModels.PageData pagedData,
            System.Linq.Expressions.Expression<Func<T, bool>> whereLambda,
            System.Linq.Expressions.Expression<Func<T, TKey>> orderBy,
            bool isAsc = true,
            params string[] joinPropertyNames);
        #endregion

        #region 7.0 执行存储过程或delete、update语句 +int ExecuteSql(string strSql, params object[] paras)
        /// <summary>
        /// 7.0 执行存储过程或delete、update语句 +int ExecuteSql(string strSql, params object[] paras)
        /// ExecuteSql(" UPDATE dbo.UserInfo SET Password=@Password WHERE ID=@ID"
        ///    , new SqlParameter("@Password", password)
        ///    , new SqlParameter("@ID", id)
        /// SqlParameter[] para = new SqlParameter[] {new SqlParameter("@ID",id) , new SqlParameter("@Password", password)};
        /// ExecuteSql("sp_Userinfos_deleteByID @ID", para);或
        /// ExecuteSql("delete UserInfo where id=@ID", para);
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="paras"></param>
        /// <returns></returns>
        int ExecuteSql(string strSql, params object[] paras);

        #endregion

        #region 7.1 EF中使用SQL语句进行查询+List<T> ExecuteSqlQuery
        /// <summary>
        /// EF中使用SQL语句进行查询
        /// SqlParameter[] paras = new SqlParameter[] {new SqlParameter("@ID",id) , new SqlParameter("@Password", password)};
        /// var model = db.Database.SqlQuery<UserInfo>("select* from UserInfoes where id=@ID ",paras).ToList();      
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="paras"></param>
        /// <returns></returns>
        List<T> ExecuteSqlQuery(string strSql, params object[] paras);
        #endregion
    }
}
