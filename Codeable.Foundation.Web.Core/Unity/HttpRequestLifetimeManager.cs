using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unity;
using Unity.Lifetime;
using System.Web;
using System.Diagnostics;

namespace Codeable.Foundation.UI.Web.Core.Unity
{
    public class HttpRequestLifetimeManager : LifetimeManager, ITypeLifetimeManager
    {
        private string _key = Guid.NewGuid().ToString();

        protected override LifetimeManager OnCreateLifetimeManager()
        {
            return this;
        }

        public override object GetValue(ILifetimeContainer container = null)
        {
            if (HttpContext.Current != null)
            {
                if (HttpContext.Current.Items.Contains(_key))
                {
                    return HttpContext.Current.Items[_key];
                }

            }
            return null;
        }

        public override void RemoveValue(ILifetimeContainer container = null)
        {
            if (HttpContext.Current != null)
            {
                HttpContext.Current.Items.Remove(_key);
            }
        }

        public override void SetValue(object newValue, ILifetimeContainer container = null)
        {
            if (HttpContext.Current != null)
            {
                HttpContext.Current.Items[_key] = newValue;
            }

        }

    }
}
