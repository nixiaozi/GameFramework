using GameFramework;
using GameFramework.DataTable;
using GameFramework.Fsm;
using GameFramework.Procedure;
using GameFrameworkExample;
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
            ///
            // 测试如何通过获得接口类型（没有使用autofac的情况下）
            // 第一次 GameFrameworkEntry.GetModule<T>方法中
            // Utility.Text.Format("{0}.{1}", interfaceType.Namespace, interfaceType.Name.Substring(1)); 获得接口名的对应实体
            // 最后使用反射找到对应类
            GameFrameworkEntry.GetModule<IDataTableManager>();


            ///
            // 测试using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>; 这句执行后的副作用
            // ProcedureExample procedureExample = new ProcedureExample();  不需要显式的实例化
            var m_ProcedureManager = GameFrameworkEntry.GetModule<IProcedureManager>();
            ProcedureBase[] procedures = new ProcedureBase[1]; 
            procedures[0] = (ProcedureBase)Activator.CreateInstance(typeof(ProcedureExample)); 
            // 代码初始化的过程中会先在Fsm状态机中添加Procedure流程集合
            // 以及初始化有限状态机管理器（如果没有初始化的话）
            m_ProcedureManager.Initialize(GameFrameworkEntry.GetModule<IFsmManager>(), procedures); 
            var getProcedure= m_ProcedureManager.GetProcedure<ProcedureExample>(); // 获取流程不会切换流程
            var currentProcedure= m_ProcedureManager.CurrentProcedure;

            m_ProcedureManager.StartProcedure<ProcedureExample>();  // 开始一个流程才会切换当前流程
            currentProcedure = m_ProcedureManager.CurrentProcedure;

            // 使用Assembly反射的方式获得基于ProcedureBase 的个数
            // 这个是GF框架查找流程的方法  ProcedureComponentInspector 类中 Type.GetTypeNames(typeof(ProcedureBase));
            var m_ProcedureTypeNames = TypeHelper.GetTypeNames(typeof(ProcedureBase));


            ///

        }
    }
}
