using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WHTR.WaiMai.Contracts.Models
{
    /// <summary>
    /// 餐厅管理类
    /// </summary>
    /// <summary>
    /// Restaurant:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Restaurant
    {
        public Restaurant()
        { }
        #region Model
        private int _id;
        private string _restaurantname;
        private int _sendoutcount = 0;
        private string _takeoutphone;
        private bool _isenable;
        private DateTime _createdate;
        private string _creator;
        private DateTime? _editdate;
        private string _editor;
        private bool _isdel;
        private int _version;
        /// <summary>
        /// 
        /// </summary>
        public int Id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string RestaurantName
        {
            set { _restaurantname = value; }
            get { return _restaurantname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int SendOutCount
        {
            set { _sendoutcount = value; }
            get { return _sendoutcount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TakeoutPhone
        {
            set { _takeoutphone = value; }
            get { return _takeoutphone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsEnable
        {
            set { _isenable = value; }
            get { return _isenable; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime CreateDate
        {
            set { _createdate = value; }
            get { return _createdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Creator
        {
            set { _creator = value; }
            get { return _creator; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? EditDate
        {
            set { _editdate = value; }
            get { return _editdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Editor
        {
            set { _editor = value; }
            get { return _editor; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsDel
        {
            set { _isdel = value; }
            get { return _isdel; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Version
        {
            set { _version = value; }
            get { return _version; }
        }
        #endregion Model

    }
}
