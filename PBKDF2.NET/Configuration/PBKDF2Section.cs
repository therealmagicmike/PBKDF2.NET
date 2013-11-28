/*
    Copyright (c) 2013 Michael Johnson

    Permission is hereby granted, free of charge, to any person obtaining a copy
    of this software and associated documentation files (the "Software"), to deal
    in the Software without restriction, including without limitation the rights
    to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
    copies of the Software, and to permit persons to whom the Software is
    furnished to do so, subject to the following conditions:

    The above copyright notice and this permission notice shall be included in
    all copies or substantial portions of the Software.

    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
    IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
    AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
    LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
    OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
    THE SOFTWARE.
 */

namespace System.Configuration
{
    /// <summary>
    /// Represents a PBKDF2 configuration section within a configuration file.
    /// </summary>
    public sealed class PBKDF2Section : ConfigurationSection
    {
        #region fields

        internal const string XmlTag = "pbkdf2";

        private static readonly object _lock = new object();
        private static readonly ConfigurationProperty _hashName = new ConfigurationProperty("hashName", typeof(string), "HMACSHA256",
            null, PropertyHelper.HashNameValidator, ConfigurationPropertyOptions.None);
        private static readonly ConfigurationProperty _iterationCount = new ConfigurationProperty("iterations", typeof(int), 1000,
            null, PropertyHelper.IterationCountValidator, ConfigurationPropertyOptions.None);
        private static readonly ConfigurationProperty _saltSize = new ConfigurationProperty("saltSize", typeof(int), 8,
            null, PropertyHelper.SaltSizeValidator, ConfigurationPropertyOptions.None);

        private static PBKDF2Section _instance = null;
        private static ConfigurationPropertyCollection _properties;

        #endregion

        #region constructors

        static PBKDF2Section()
        {
            _properties = new ConfigurationPropertyCollection();
            _properties.Add(_hashName);
            _properties.Add(_iterationCount);
            _properties.Add(_saltSize);
        }

        /// <summary>
        /// Creates and initializes a new instance of System.Security.Cryptography.PBKDF2Section.
        /// </summary>
        public PBKDF2Section() : base() { }

        #endregion

        #region properties

        /// <summary>
        /// Gets the current System.Configuration.PBKDF2Section within the configuration file. If it is not defined within the configuration file, an instance initiaized to default values is returned.
        /// </summary>
        public static PBKDF2Section Current
        {
            get
            {
                if (_instance == null)
                    lock (_lock)
                    {
                        if (_instance == null)
                            try
                            {
                                _instance = (PBKDF2Section)ConfigurationManager.GetSection(XmlTag);
                            }
                            catch (Exception)
                            {
                                _instance = new PBKDF2Section();
                            }
                        if (_instance == null)
                            _instance = new PBKDF2Section();
                    }
                return _instance;
            }
        }

        /// <summary>
        /// Gets or sets the default hash name used by the System.Security.Cryptography.PBKDF2 class for deriving keys when no type is specified.
        /// </summary>
        /// <remarks>This defaults to "HMACSHA256" if no value is specified within the configuration file.</remarks>
        /// <returns>The default hash name used by System.Security.Cryptography.PBKDF2 to derive keys.</returns>
        /// <exception cref="System.ArgumentException">value is null or empty. HashName value cannot be set to a null or empty string.</exception>
        [ConfigurationProperty("hashName", DefaultValue = "HMACSHA256")]
        [StringValidator(MinLength = 1)]
        public string HashName
        {
            get { return (string)base[_hashName]; }
            set { base[_hashName] = value; }
        }

        /// <summary>
        /// Gets or sets the default number of iterations used by the System.Security.Cryptography.PBKDF2 class for deriving keys when no iteration count is specified.
        /// </summary>
        /// <remarks>This defaults to 1000 iterations if no value is specified within the configuration file.</remarks>
        /// <returns>The default number of iterations used by System.Security.Cryptography.PBKDF2 to derive keys.</returns>
        /// <exception cref="System.ArgumentException">value is less than 1. IterationCount value must be greater than zero.</exception>
        [ConfigurationProperty("iterationCount", DefaultValue = 1000)]
        [IntegerValidator(MinValue = 1, MaxValue = int.MaxValue)]
        public int IterationCount
        {
            get { return (int)base[_iterationCount]; }
            set { base[_iterationCount] = value; }
        }

        /// <summary>
        /// Gets or sets the default salt size used by the System.Security.Cryptography.PBKDF2 class for deriving keys when no salt size is specified.
        /// </summary>
        /// <remarks>This defaults to 8 if no value is specified within the configuration file.</remarks>
        /// <returns>The default salt size used by System.Security.Cryptography.PBKDF2 to derive keys.</returns>
        /// <exception cref="System.ArgumentException">value is less than 8 or greater than 65536. SaltSize value cannot be less than 8 and cannot be greater than 65536.</exception>
        [ConfigurationProperty("saltSize", DefaultValue = 8)]
        [IntegerValidator(MinValue = 8, MaxValue = 65536)]
        public int SaltSize
        {
            get { return (int)base[_saltSize]; }
            set { base[_saltSize] = value; }
        }

        /// <summary>
        /// Gets the collection of properties.
        /// </summary>
        /// <returns>The System.Configuration.ConfigurationPropertyCollection of properties for the element.</returns>
        protected override ConfigurationPropertyCollection Properties
        {
            get { return _properties; }
        }

        #endregion
    }
}
