using System;

namespace Edu.Infrastructure.Attrs
{
    /// <summary>
    /// 枚举数据的Name属性
    /// </summary>
    public class ColumnNumberAttribute : Attribute
    {
        public int ColumnIndex { get; set; }

        public ColumnNumberAttribute(int index)
        {
            this.ColumnIndex = index;
        }
    }
}
