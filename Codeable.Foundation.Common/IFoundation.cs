using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Codeable.Foundation.Common.Aspect;
using Codeable.Foundation.Common.Plugins;
using Codeable.Foundation.Common.System;
using Codeable.Foundation.Common.Daemons;
using Unity;
using Unity.Lifetime;

namespace Codeable.Foundation.Common
{
    public interface IFoundation
    {
        void Start(IBootStrap bootStrap);
        void Stop();
        IUnityContainer Container { get; }
        ILogger GetLogger();
        ITracer GetTracer();
        IAspectCoordinator GetAspectCoordinator();
        IPluginManager GetPluginManager();
        IDaemonManager GetDaemonManager();

        T SafeResolve<T>();
        T SafeResolve<T>(string name);
    }
}
