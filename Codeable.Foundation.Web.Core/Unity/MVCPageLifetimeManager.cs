using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unity;
using Unity.Lifetime;
using System.Web.Mvc;

namespace Codeable.Foundation.UI.Web.Core.Unity
{
    public class MVCPageLifetimeManager : LifetimeManager, ITypeLifetimeManager
    {
        #region Constructor

        public MVCPageLifetimeManager(WebViewPage viewPage, string datakey)
        {
            _viewPage = viewPage;
            _dataKey = "__MVCPageLifetimeManager_" + datakey;
        } 

        #endregion

        #region Private Properties

        private string _dataKey;
        private WebViewPage _viewPage;

        #endregion

        protected override LifetimeManager OnCreateLifetimeManager()
        {
            return this;
        }

        #region Public Methods

        public override object GetValue(ILifetimeContainer container = null)
        {
            return _viewPage.Context.Items[_dataKey];;
        }
        public override void RemoveValue(ILifetimeContainer container = null)
        {
            _viewPage.Context.Items.Remove(_dataKey);
        }
        public override void SetValue(object newValue, ILifetimeContainer container = null)
        {
            _viewPage.Context.Items[_dataKey] = newValue;
        }

        #endregion
    }
}
