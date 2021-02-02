using Microsoft.Extensions.Localization;
using System.Reflection;
using WebApplication.Resources;

namespace WebApplication.Services
{
    public class LocService
    {
        private readonly IStringLocalizer _localizer;

        public LocService(IStringLocalizerFactory factory)
        {
            var type = typeof(SharedResource);
            var assemblyName = new AssemblyName(type.GetTypeInfo().Assembly.FullName);
            _localizer = factory.Create("SharedResource", assemblyName.Name);
        }

        public LocalizedString GetString(string key)
        {
            return _localizer[key];
        }
    }

}
