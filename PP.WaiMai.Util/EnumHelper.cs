using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PP.WaiMai.Util
{
    public class EnumHelper
    {
        public static string GetDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
            if ((attributes != null) && (attributes.Length > 0))
                return attributes[0].Description;
            else
                return value.ToString();

        }
        /// <summary>
        /// 获取枚举的描述文本
        /// </summary>
        /// <param name="e">枚举成员</param>
        /// <returns></returns>
        public static string GetEnumDescription(object e)
        {
            //获取字段信息
            System.Reflection.FieldInfo[] ms = e.GetType().GetFields();
            Type t = e.GetType();
            foreach (System.Reflection.FieldInfo f in ms)
            {
                //判断名称是否相等
                if (f.Name != e.ToString()) continue;
                //反射出自定义属性
                foreach (Attribute attr in f.GetCustomAttributes(true))
                {
                    //类型转换找到一个Description，用Description作为成员名称
                    System.ComponentModel.DescriptionAttribute dscript = attr as System.ComponentModel.DescriptionAttribute;
                    if (dscript != null)
                        return dscript.Description;
                }
            }
            //如果没有检测到合适的注释，则用默认名称
            return e.ToString();
        }
        /// <summary>
        ///  把枚举的描述和值绑定到DropDownList
        /// </summary>
        /// <param name="enumType"></param>
        /// <returns></returns>
        public static List<SelectListItem> GetSelectList(Type enumType)
        {
            List<SelectListItem> selectList = new List<SelectListItem>();

            foreach (object e in Enum.GetValues(enumType))
            {
                selectList.Add(new SelectListItem { Text = GetEnumDescription(e), Value = ((int)e).ToString() });
            }

            return selectList;
        }
        /// <summary>
        ///  把枚举的描述和值绑定到DropDownList
        /// </summary>
        /// <param name="enumType"></param>
        /// <returns></returns>
        public static List<SelectListItem> GetSelectList(Type enumType, int select)
        {
            List<SelectListItem> selectList = new List<SelectListItem>();

            foreach (object e in Enum.GetValues(enumType))
            {
                selectList.Add(new SelectListItem { Text = GetEnumDescription(e), Value = ((int)e).ToString(), Selected = ((int)e == select) });
            }

            return selectList;
        }

    }
}
