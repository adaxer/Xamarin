using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfMitDependencies
{
    public class SimpleContainer : IServiceLocator
    {
        Dictionary<Type, Type> m_Items = new Dictionary<Type, Type>();

        public void Register<TInferface,TImplemenation>() where TInferface: class where TImplemenation:class
        {
            m_Items[typeof(TInferface)] = typeof(TImplemenation);
        }

        public TInterface Get<TInterface>() where TInterface:class
        {
            if (!m_Items.ContainsKey(typeof(TInterface)))
                return null;

            Type toReturn = m_Items[typeof(TInterface)];
            return Activator.CreateInstance(toReturn) as TInterface;
        }
    }
}
