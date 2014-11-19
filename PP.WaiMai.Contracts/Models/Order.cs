/**  版本信息模板在安装目录下，可自行修改。
* Order.cs
*
* 功 能： N/A
* 类 名： Order
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/11/15 1:21:46   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace PP.WaiMai.Contracts.Models
{
	/// <summary>
	/// Order:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Order
	{
		public Order()
		{}
		#region Model
		private int _id;
		private int _foodmenuid;
		private int _totalcount;
		private decimal _totalprice;
		private string _nickname;
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
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int FoodMenuId
		{
			set{ _foodmenuid=value;}
			get{return _foodmenuid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int TotalCount
		{
			set{ _totalcount=value;}
			get{return _totalcount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal TotalPrice
		{
			set{ _totalprice=value;}
			get{return _totalprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string NickName
		{
			set{ _nickname=value;}
			get{return _nickname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime CreateDate
		{
			set{ _createdate=value;}
			get{return _createdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Creator
		{
			set{ _creator=value;}
			get{return _creator;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? EditDate
		{
			set{ _editdate=value;}
			get{return _editdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Editor
		{
			set{ _editor=value;}
			get{return _editor;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool IsDel
		{
			set{ _isdel=value;}
			get{return _isdel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int Version
		{
			set{ _version=value;}
			get{return _version;}
		}
		#endregion Model

	}
}

