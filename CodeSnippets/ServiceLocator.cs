using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfMitDependencies
{
    public sealed class ServiceLocator
    {
        private static readonly IServiceLocator instance = new SimpleContainer();

        static ServiceLocator(){}

        private ServiceLocator(){}

        public static IServiceLocator Instance
        {
            get {return instance;}
        }
    } 
 

    public interface IServiceLocator
    {
        T Get<T>() where T : class;
    }
}
