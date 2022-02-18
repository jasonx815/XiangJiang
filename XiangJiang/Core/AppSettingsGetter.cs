using System;
using System.Configuration;

namespace XiangJiang.Core
{
    public sealed class AppSettingsGetter : IDisposable
    {
        private readonly Configuration _appConfig;
        private readonly AppSettingsSection _appSettings;

        public AppSettingsGetter()
        {
            _appConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            _appSettings = _appConfig.AppSettings;
        }

        public void Dispose()
        {
            Save();
        }

        public T Get<T>(string key)
        {
            CheckKey(key);
            var value = _appSettings?.Settings[key]?.Value;

            return (T) Convert.ChangeType(value, typeof(T));
        }

        private void CheckKey(string key)
        {
            Checker.Begin().NotNullOrEmpty(key, nameof(key));
        }

        public bool Exist(string key)
        {
            CheckKey(key);
            return _appSettings.Settings[key] != null;
        }

        public bool TryGet<T>(string key, out T value)
        {
            value = default;
            CheckKey(key);
            try
            {
                var valueString = _appSettings?.Settings[key]?.Value;

                value = (T) Convert.ChangeType(valueString, typeof(T));
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void Remove(string key)
        {
            CheckKey(key);
            _appSettings.Settings.Remove(key);
        }

        public void Save()
        {
            _appConfig.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }

        public void Set(string key, string value)
        {
            CheckKey(key);
            if (Exist(key))
                _appSettings.Settings[key].Value = value;
            else
                _appSettings.Settings.Add(key, value);
        }
    }
}