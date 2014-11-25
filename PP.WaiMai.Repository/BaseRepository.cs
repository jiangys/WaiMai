using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PP.WaiMai.Repository
{
    public class BaseRepository<T> where T : class,new()
    {
        /// <summary>
        /// EF上下文对象
        /// </summary>
        DbContext db = new DBContextFactory().GetDbContext();
        public BaseRepository()
        {

        }

        #region 1.0 新增 实体 +int Add(T model)
        /// <summary>
        /// 新增 实体，常用
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public virtual int Add(T model)
        {
            db.Set<T>().Add(model);
            return db.SaveChanges();//保存成功后，会将自增的id设置给 model的 主键属性，并返回受影响行数
        }
        #endregion

        #region 2.0 根据 Model 删除 +int Delete(T model)
        /// <summary>
        /// 根据 Model 删除
        /// </summary>
        /// <param name="model">包含要删除Model的对象</param>
        /// <returns></returns>
        public virtual int Delete(T model)
        {
            db.Set<T>().Attach(model);
            db.Set<T>().Remove(model);
            return db.SaveChanges();
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
            //3.1查询要删除的数据
            List<T> listDeleting = db.Set<T>().Where<T>(delWhere).ToList();
            //3.2将要删除的数据 用删除方法添加到 EF 容器中
            listDeleting.ForEach(u =>
            {
                db.Set<T>().Attach(u);//先附加到 EF容器
                db.Set<T>().Remove(u);//标识为 删除 状态
            });
            //3.3一次性 生成sql语句到数据库执行删除
            return db.SaveChanges();
        }
        #endregion

        #region 4.0 修改 +int Modify(T model, params string[] proNames)
        /// <summary>
        /// 4.0 修改，不先查询，单独的上下文，如：
        /// T u = new T() { uId = 1, uLoginName = "asdfasdf" };
        /// this.Modify(u, "uLoginName");
        /// </summary>
        /// <param name="model">要修改的实体对象</param>
        /// <param name="proNames">要修改的 属性 名称</param>
        /// <returns></returns>
        public virtual int Modify(T model, params string[] proNames)
        {
            //4.1将 对象 添加到 EF中
            DbEntityEntry entry = db.Entry<T>(model);
            //4.2先设置 对象的包装 状态为 Unchanged
            entry.State = EntityState.Unchanged;
            //4.3循环 被修改的属性名 数组
            foreach (string proName in proNames)
            {
                //4.4将每个 被修改的属性的状态 设置为已修改状态;后面生成update语句时，就只为已修改的属性 更新
                entry.Property(proName).IsModified = true;
            }
            //4.4一次性 生成sql语句到数据库执行
            return db.SaveChanges();
        }
        #endregion

        #region 4.1同一个上下文，修改实体，适用先查询实体，再更新+int ModifyModel(T entity)
        /// <summary>
        /// 同一个上下文，修改实体，
        /// 适用先查询实体，再更新
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int ModifyModel(T entity)
        {
            if (entity != null)
            {
                db.Entry<T>(entity).State = EntityState.Modified;
            }
            return db.SaveChanges();
        }
        #endregion

        #region 5.0 根据条件查询 +T GetModel(Expression<Func<T,bool>> whereLambda)
        /// <summary>
        /// 5.0 根据条件查询 +List<T> GetOne(Expression<Func<T,bool>> whereLambda)
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        public virtual T GetModel(Expression<Func<T, bool>> whereLambda)
        {
            return db.Set<T>().Where(whereLambda).ToList().FirstOrDefault();
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
            return db.Set<T>().Where(whereLambda).ToList();
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
            rowCount = db.Set<T>().Where(whereLambda).Count();
            //1.查询分页数据
            if (isAsc)
            {
                return db.Set<T>().OrderBy(orderBy).Where(whereLambda).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            }
            //2.查询总行数
            else
            {
                return db.Set<T>().OrderByDescending(orderBy).Where(whereLambda).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            }
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
            //1.获取 对应实体类 的查询 对象
            DbQuery<T> dbQuery = db.Set<T>();
            //2.循环 要连接查询的 属性
            foreach (var joinProperty in joinPropertyNames)
            {
                dbQuery = dbQuery.Include(joinProperty);
            }
            //3.加入 查询 条件
            IQueryable<T> query = dbQuery.Where(whereLambda);
            //4.加入 排序 条件
            IOrderedQueryable<T> orderedQuery = null;
            if (isAsc)
                orderedQuery = query.OrderBy(orderBy);
            else
                orderedQuery = query.OrderByDescending(orderBy);
            //5.分页查询 Skip Take
            //5.1查询 当前页码 的 数据集合
            pagedData.rows = orderedQuery.Skip((pagedData.PageIndex - 1) * pagedData.PageSize).Take(pagedData.PageSize).ToList();
            //5.2查询符合条件的 总行数
            pagedData.total = orderedQuery.Count();
        }
        #endregion

        #region 7.0 执行存储过程或delete、update语句 +int ExcuteSql(string strSql, params object[] paras)
        /// <summary>
        /// 7.0 执行存储过程或delete、update语句 +int ExcuteSql(string strSql, params object[] paras)
        /// SqlParameter[] para = new SqlParameter[] {new SqlParameter("@ID",id)};
        /// ExecuteSql("sp_Userinfos_deleteByID @ID", para);或
        /// ExecuteSql("delete UserInfo where id=@ID", para);
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="paras"></param>
        /// <returns></returns>
        public virtual int ExecuteSql(string strSql, params object[] paras)
        {
            return db.Database.ExecuteSqlCommand(strSql, paras);
        }
        #endregion

        #region 7.1 EF中使用SQL语句进行查询
        /// <summary>
        /// EF中使用SQL语句进行查询
        /// SqlParameter[] paras = new SqlParameter[] {new SqlParameter("@ID",id)};
        /// var model = ExecuteSqlQuery<UserInfo>("select* from UserInfoes where id=@ID ",paras).ToList();
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="paras"></param>
        /// <returns></returns>
        public virtual List<T> ExecuteSqlQuery(string strSql, params object[] paras)
        {
            return db.Database.SqlQuery<T>(strSql, paras).ToList();
        } 
        #endregion

    }
}
