using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Edu.Core.DomainRepository;
using Edu.Repository;

namespace Beisen.CSTinsight.Repository
{
    /// <summary>
    /// Ioc Installer
    /// </summary>
    internal static class IocInstaller
    {
        public static void Install(IWindsorContainer container)
        {
            #region 数据访问 注册组件

            container.Register(
                Component.For(typeof(ISqlExcuteContext))
                    .ImplementedBy<ISqlExcuteContext>()
                    .LifeStyle.Singleton,
                Component.For(typeof(IRoleMenuRepository))
                    .ImplementedBy<RoleMenuRepository>()
                    .LifeStyle.Singleton,
                Component.For(typeof(IRoleRepository))
                    .ImplementedBy<RoleRepository>()
                    .LifeStyle.Singleton);

            #endregion
        }
    }
}
