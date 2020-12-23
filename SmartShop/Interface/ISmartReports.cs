using System;
using System.Collections.Generic;

namespace SmartShop.Interface
{
    public interface ISmartReports : IDisposable
    {
        IEnumerable<Models.Reports> Get();
        Models.Reports GetBy(string key);
        Models.Reports GetBy(string key, string settingValue);
        bool HasHeader(string key, string settingValue);
        bool HasFooter(string key, string settingValue);
        bool IsActivated(string key, string settingValue);
    }
}
