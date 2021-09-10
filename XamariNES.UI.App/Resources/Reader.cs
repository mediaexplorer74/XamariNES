﻿using System;
using System.Reflection;
using System.Linq;

namespace XamariNES.UI.App.Resources
{
    /// <summary>
    ///     Resource Reader Helper Class
    ///
    ///     Helps with handling of Embedded Resources
    /// </summary>
    public class Reader
    {
        private readonly Assembly _assembly;

        /// <summary>
        ///     Default Constructor
        /// </summary>
        public Reader()
        {
            _assembly = typeof(App).GetTypeInfo().Assembly; // .NET Standard 1.4 (for 15063 compatibility)
            //_assembly = Assembly.GetExecutingAssembly();  // .NET Standard 2.0 (for 16299 and above)

        }

        /// <summary>
        ///     Reads an embedded resource to a byte array
        /// </summary>
        /// <param name="resource"></param>
        /// <returns></returns>
        public byte[] GetResource(string resource)
        {
            if (!_assembly.GetManifestResourceNames().Any(x => x == resource))
                throw new Exception($"Embedded Resource Not Found: {resource}");

            byte[] output;
            using (var stream = _assembly.GetManifestResourceStream(resource))
            {
                output = new byte[stream.Length];
                stream.Read(output, 0, (int)stream.Length);
            }

            return output;
        }
    }
}
