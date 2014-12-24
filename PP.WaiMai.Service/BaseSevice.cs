using PP.WaiMai.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PP.WaiMai.Service
{
    public abstract class BaseService<T> : IService.IBaseService<T> where T : class ,new()
    {
        /// <summary>
        /// 在基类的构造函数内部，直接调用了此抽象方法，必须在子类里面实现
        /// </summary>
        public BaseService()
        {
            SetCurrentRepository();
        }

        /// <summary>
        /// 当前仓储
        /// </summary>
        protected IBaseRepository<T> CurrentRepository { get; set; }

        /// <summary>
        /// 设置当前仓储,定义一个纯的抽象方法，子类在实现此父类的时候，必须重写当前的抽象方法。
        /// </summary>
        public abstract void SetCurrentRepository();

        /// <summary>
        /// 数据仓储接口（相当于数据层工厂，可以创建所有的数据子类对象）
        /// </summary>
        private IDbSession iDbSession;

        #region 数据仓储 属性 + IDBSession DBSession
        /// <summary>
        /// 数据仓储 属性
        /// </summary>
        public IDbSession DbSessionContext
        {
            get
            {
                if (iDbSession == null)
                {
                    IDbSessionFactory sessionFactory = new PP.WaiMai.Repository.DbSessionFactory(); //DI.SpringHelper.GetObject<DALMSSQL.DbSessionFactory>("DBSessFactory");
                    iDbSession = sessionFactory.GetCurrentDbSession();
                }
                return iDbSession;
            }
        }
        #endregion

        //2.增删改查方法
        #region 1.0 新增 实体 +int Add(T model)
        /// <summary>
        /// 新增 实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public virtual int Add(T model)
        {
            return this.CurrentRepository.Add(model);
        }
        #endregion

        #region 2.0 根据 用户 id 删除 +int Delete(int uId)
        /// <summary>
        /// 根据 用户 id 删除
        /// </summary>
        /// <param name="uId"></param>
        /// <returns></returns>
        public virtual int Delete(T model)
        {
            return this.CurrentRepository.Delete(model);
        }
        #endregion

        #region 3.0 根据条件删除 +int DeleteBy(Expression<Func<T, bool>> delWhere)
        /// <summary>
        /// 3.0 根据条件删除
        /// </summary>
        /// <param name="delWhere"></param>
        /// <returns></returns>
        public virtual int DeleteBy(Expression<Func<T, bool>> delWhere)
        {
            return this.CurrentRepository.DeleteBy(delWhere);
        }
        #endregion

        #region 4.0 修改 +int Modify(T model, params string[] proNames)
        /// <summary>
        /// 4.0 修改，如：
        /// </summary>
        /// <param name="model">要修改的实体对象</param>
        /// <param name="proNames">要修改的 属性 名称</param>
        /// <returns></returns>
        public virtual int Modify(T model, params string[] proNames)
        {
            return this.CurrentRepository.Modify(model, proNames);
        }
        #endregion

        #region 4.1同一个上下文，修改实体，适用先查询实体，再更新+int ModifyModel(T model)
        /// <summary>
        /// 同一个上下文，修改实体，
        /// 适用先查询实体，再更新
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual int ModifyModel(T model)
        {
            return this.CurrentRepository.ModifyModel(model);
        }
        #endregion

        #region  4.2 批量修改 +int Modify(Expression<Func<T, bool>> whereLambda, params string[] modifiedProNames)
        /// <summary>
        ///  4.2 批量修改 +int Modify(T model, Expression<Func<T, bool>> whereLambda, params string[] modifiedProNames)
        /// </summary>
        /// <param name="model"></param>
        /// <param name="whereLambda"></param>
        /// <param name="modifiedProNames"></param>
        /// <returns></returns>
        public virtual int ModifyBy(T model, Expression<Func<T, bool>> whereLambda, params string[] modifiedProNames)
        {
            return this.CurrentRepository.ModifyBy(model, whereLambda, modifiedProNames);
        }
        #endregion

        #region 5.0 根据条件查询 +List<T> GetListBy(Expression<Func<T,bool>> whereLambda)
        /// <summary>
        /// 5.0 根据条件查询 +List<T> GetListBy(Expression<Func<T,bool>> whereLambda)
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        public virtual List<T> GetListBy(Expression<Func<T, bool>> whereLambda)
        {
            return this.CurrentRepository.GetListBy(whereLambda);
        }
        #endregion

        #region 5.2 根据条件查询 +T GetModel(Expression<Func<T,bool>> whereLambda)
        /// <summary>
        /// 5.0 根据条件查询 +T GetOne(Expression<Func<T,bool>> whereLambda)
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        public virtual T GetModel(Expression<Func<T, bool>> whereLambda)
        {
            return this.CurrentRepository.GetListBy(whereLambda).FirstOrDefault();
        }
        #endregion

        #region 5.1 根据条件 排序 和查询 + List<T> GetListBy<TKey>
        /// <summary>
        /// 5.1 根据条件 排序 和查询
        /// </summary>
        /// <typeparam name="TKey">排序字段类型</typeparam>
        /// <param name="whereLambda">查询条件 lambda表达式</param>
        /// <param name="orderLambda">排序条件 lambda表达式</param>
        /// <returns></returns>
        public virtual List<T> GetListBy<TKey>(Expression<Func<T, bool>> whereLambda)
        {
            return this.CurrentRepository.GetListBy(whereLambda);
        }
        #endregion

        #region 6.1分页查询 带输出 +List<T> GetPagedList<TKey>
        /// <summary>
        /// 6.1分页查询 带输出
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="rowCount"></param>
        /// <param name="whereLambda"></param>
        /// <param name="orderBy"></param>
        /// <param name="isAsc"></param>
        /// <returns></returns>
        public virtual List<T> GetPagedList<TKey>(int pageIndex, int pageSize, ref int rowCount, Expression<Func<T, bool>> whereLambda, Expression<Func<T, TKey>> orderBy, bool isAsc = true)
        {
            return this.CurrentRepository.GetPagedList<TKey>(pageIndex, pageSize, ref rowCount, whereLambda, orderBy, isAsc);
        }
        #endregion

        #region 6.2 分页查询 +void GetPagedList<TKey>
        /// <summary>
        /// 6.0 分页查询
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="pagedData">分页模型（页码，页容量；总行数，当前页数据集合）</param>
        /// <param name="whereLambda">查询条件</param>
        /// <param name="orderBy">排序条件</param>
        /// <param name="isAsc">是否升序</param>
        /// <param name="joinPropertyNames">join属性名</param>
        public void GetPagedList<TKey>(
            Model.FormatModels.PageData pagedData,
            System.Linq.Expressions.Expression<Func<T, bool>> whereLambda,
            System.Linq.Expressions.Expression<Func<T, TKey>> orderBy,
            bool isAsc = true,
            params string[] joinPropertyNames)
        {
            this.CurrentRepository.GetPagedList<TKey>(pagedData, whereLambda, orderBy, isAsc, joinPropertyNames);
        }
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
        public virtual int ExecuteSql(string strSql, params object[] paras)
        {
            return this.CurrentRepository.ExecuteSql(strSql, paras);
        }

        #endregion

        #region 7.1 EF中使用SQL语句进行查询+List<T> ExecuteSqlQuery
        /// <summary>
        /// EF中使用SQL语句进行查询
        /// SqlParameter[] paras = new SqlParameter[] {new SqlParameter("@ID",id)};
        /// var model = ExecuteSqlQuery<UserInfo>("select* from UserInfo where id=@ID ",paras).ToList();
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="paras"></param>
        /// <returns></returns>
        public virtual List<T> ExecuteSqlQuery(string strSql, params object[] paras)
        {
            return this.CurrentRepository.ExecuteSqlQuery(strSql, paras);
        }
        #endregion
    }
}
