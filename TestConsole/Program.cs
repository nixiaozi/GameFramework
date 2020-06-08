using GameFramework;
using GameFramework.DataTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            // 测试如何通过获得接口类型（没有使用autofac的情况下）
            // 第一次 GameFrameworkEntry.GetModule<T>方法中
            // Utility.Text.Format("{0}.{1}", interfaceType.Namespace, interfaceType.Name.Substring(1)); 获得接口名的对应实体
            // 最后使用反射找到对应类
            GameFrameworkEntry.GetModule<IDataTableManager>();  
        }
    }
}
