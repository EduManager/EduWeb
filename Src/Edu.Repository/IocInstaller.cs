using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Edu.Core.DomainRepository;
using Edu.Repository.UnitOfWork;

namespace Edu.Repository
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
                    .ImplementedBy<SqlExcuteContext>()
                    .LifeStyle.Singleton,
                Component.For(typeof(IRoleMenuRepository))
                    .ImplementedBy<RoleMenuRepository>()
                    .LifeStyle.Singleton,
                Component.For(typeof(IRoleRepository))
                    .ImplementedBy<RoleRepository>()
                    .LifeStyle.Singleton,
                Component.For(typeof(IMenuRepository))
                    .ImplementedBy<MenuRepository>()
                    .LifeStyle.Singleton,
                Component.For(typeof(ICampusRepository))
                    .ImplementedBy<CampusRepository>()
                    .LifeStyle.Singleton,
                Component.For(typeof(ICourseRepository))
                    .ImplementedBy<CourseRepository>()
                    .LifeStyle.Singleton,
                Component.For(typeof(IUserRepository))
                    .ImplementedBy<UserRepository>()
                    .LifeStyle.Singleton);

            #endregion
        }
    }
}
