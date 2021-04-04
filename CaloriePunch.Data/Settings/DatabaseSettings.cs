using CaloriePunch.Data.Settings.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaloriePunch.Data.Settings
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
