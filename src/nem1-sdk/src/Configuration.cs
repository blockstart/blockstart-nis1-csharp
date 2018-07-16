using System;
using System.Configuration;

namespace io.nem1.sdk
{
    internal class MyMosaicConfigSection : ConfigurationSection
    {
        [ConfigurationProperty("", IsRequired = true, IsDefaultCollection = true)]
        internal MosaicInstanceCollection Mosaics
        {
            get => (MosaicInstanceCollection)this[""];
            set => this[""] = value;
        }
    }

    internal class MosaicInstanceCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new MosaicConfigElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((MosaicConfigElement)element).Name;
        }
    }

    internal class MosaicConfigElement : ConfigurationElement
    {
        [ConfigurationProperty("name", IsKey = true, IsRequired = true)]
        internal string Name
        {
            get => (string)base["name"];
            set => base["name"] = value;
        }

        [ConfigurationProperty("mosaicId", IsRequired = true)]
        internal string MosaicID
        {
            get => (string)base["mosaicId"];
            set => base["mosaicID"] = value;
        }
        [ConfigurationProperty("initialSupply", IsRequired = true)]
        internal ulong InitialSupply
        {
            get => (ulong)base["initialSupply"];
            set => base["initialSupply"] = value;
        }
        [ConfigurationProperty("divisibility", IsRequired = true)]
        internal int Divisibility
        {
            get => (int)base["divisibility"];
            set => base["divisibility"] = value;
        }
    }

    internal class ConfigDiscovery
    {
        internal static string Location { get; set; }

        internal ConfigDiscovery()
        {
            Location = GetType().Assembly.Location;
        }
        internal MosaicInstanceCollection GetConfig(string key)
        {
            Configuration config;
            var exeConfigPath = Location;
            try
            {
                config = ConfigurationManager.OpenExeConfiguration(exeConfigPath);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            if (config != null)
            {
                return GetAppSetting(config, key);

            }
            throw new Exception("mosaic config missing");
        }

        internal static MosaicInstanceCollection GetAppSetting(Configuration config, string key)
        {
            if (config.GetSection(key) is MyMosaicConfigSection element)
            {
                return element.Mosaics;
            }
            throw new Exception("mosaic config missing");
        }
    }
}