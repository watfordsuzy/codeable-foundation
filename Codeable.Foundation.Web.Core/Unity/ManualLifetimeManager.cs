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
    public class ManualLifetimeManager<T> : LifetimeManager, ITypeLifetimeManager
    {
        #region Constructor

        public ManualLifetimeManager(T value)
        {
            _object = value;
        } 

        #endregion

        #region Private Properties

        private T _object;

        #endregion

        protected override LifetimeManager OnCreateLifetimeManager()
        {
            return this;
        }

        #region Public Methods

        public override object GetValue(ILifetimeContainer container = null)
        {
            return _object;
        }
        public override void RemoveValue(ILifetimeContainer container = null)
        {
            _object = default(T);
        }
        public override void SetValue(object newValue, ILifetimeContainer container = null)
        {
            _object = (T)newValue;
        } 

        #endregion

    }
}
