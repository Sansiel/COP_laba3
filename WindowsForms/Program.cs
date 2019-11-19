using ProdDAL.Interfaces;
using ImplementDB;
using ImplementDB.Implementations;
using System;
using System.Data.Entity;
using System.Windows.Forms;
using Unity;
using Unity.Lifetime;

namespace WindowsForms
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var container = BuildUnityContainer();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(container.Resolve <FormProduct>());
        }

        public static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();
            currentContainer.RegisterType<DbContext, DBContext>(new
            HierarchicalLifetimeManager());
            currentContainer.RegisterType<IProductService, ProductServiceDB>(new
            HierarchicalLifetimeManager());
            return currentContainer;
        }
    }
}
