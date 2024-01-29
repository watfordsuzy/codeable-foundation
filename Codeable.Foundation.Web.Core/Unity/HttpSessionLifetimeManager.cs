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
    public class HttpSessionLifetimeManager : LifetimeManager, ITypeLifetimeManager
    {
        public HttpSessionLifetimeManager(string sessionKey)
        {
            this.SessionKey = "HttpSessionLifetimeManager" + sessionKey;
        }

        protected string SessionKey { get; set; }

        protected override LifetimeManager OnCreateLifetimeManager()
        {
            return this;
        }

        public override object GetValue(ILifetimeContainer container = null)
        {
            if ((HttpContext.Current != null) && (HttpContext.Current.Session != null))
            {
                object result = HttpContext.Current.Session[GenerateSessionKey()];
                if (result != null)
                {
                    return result;
                }
            }
            return null;
        }
        public override void RemoveValue(ILifetimeContainer container = null)
        {
            if ((HttpContext.Current != null) && (HttpContext.Current.Session != null))
            {
                HttpContext.Current.Session.Remove(GenerateSessionKey());
            }
        }
        public override void SetValue(object newValue, ILifetimeContainer container = null)
        {
            if ((HttpContext.Current != null) && (HttpContext.Current.Session != null))
            {
                HttpContext.Current.Session[GenerateSessionKey()] = newValue;
            }
        }

        protected virtual string GenerateSessionKey()
        {
            return this.SessionKey;
        }
    }
}
