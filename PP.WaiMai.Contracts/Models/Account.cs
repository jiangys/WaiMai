/**  版本信息模板在安装目录下，可自行修改。
* Account.cs
*
* 功 能： N/A
* 类 名： Account
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/11/19 16:24:16   N/A    初版
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
	/// Account:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Account
	{
		public Account()
		{}
		#region Model
		private int _id;
		private string _accountname;
		private string _ipaddress;
		private decimal _amount;
		private DateTime _createdate;
		private bool _isdel;
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
		public string AccountName
		{
			set{ _accountname=value;}
			get{return _accountname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string IPAddress
		{
			set{ _ipaddress=value;}
			get{return _ipaddress;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal Amount
		{
			set{ _amount=value;}
			get{return _amount;}
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
		public bool IsDel
		{
			set{ _isdel=value;}
			get{return _isdel;}
		}
		#endregion Model

	}
}

