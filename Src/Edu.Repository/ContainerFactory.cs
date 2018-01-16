using System;
using Castle.Windsor;
using Edu.Infrastructure.Helper;

namespace Edu.Repository
{
    /// <summary>
    /// 组件工厂
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public static class ContainerFactory<T>
    {
        /// <summary>
        /// WindsorContainer object
        /// </summary>
        private static readonly IWindsorContainer windsor;
        
        /// <summary>
        /// Construction Method.
        /// Initialization IOC.
        /// </summary>
        static ContainerFactory()
        {
            try
            {
                //IOC containers establishment, and through the most dynamic configuration file by adding components.
                //Castle.Core.Resource.ConfigResource source = new Castle.Core.Resource.ConfigResource();
                //XmlInterpreter interpreter = new XmlInterpreter(source);
                windsor = new WindsorContainer();
                IocInstaller.Install(windsor);
            }
            catch (Exception e1)
            {
                LogHelper.Error(typeof(IWindsorContainer),"注册IOC出错",e1);
            }
        }

        /// <summary>
        /// Returns a component instance by the type of service.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Instance
        {
            get
            {
                try
                {
                    return windsor.Resolve<T>();
                }
                catch (Exception e1)
                {
                    LogHelper.Error(typeof(IWindsorContainer), "获取类型出错：" + typeof(T).Name, e1);
                    return default(T);
                }
            }
        }
    }
}

