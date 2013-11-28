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
    /// Internal utility/helper class
    /// </summary>
    internal static class PropertyHelper
    {
        #region fields

        private static ConfigurationValidatorBase _hashNameValidator = null;
        private static ConfigurationValidatorBase _iterationCountValidator = null;
        private static ConfigurationValidatorBase _saltSizeValidator = null;

        #endregion

        #region properties

        /// <summary>
        /// Gets a validator for System.Configuration.PBKDF2Section.HashName configuration property values.
        /// </summary>
        public static ConfigurationValidatorBase HashNameValidator
        {
            get
            {
                if (_hashNameValidator == null)
                    _hashNameValidator = new StringValidator(1);
                return _hashNameValidator;
            }
        }

        /// <summary>
        /// Gets a validator for System.Configuration.PBKDF2Section.IterationCount configuration property values.
        /// </summary>
        public static ConfigurationValidatorBase IterationCountValidator
        {
            get
            {
                if (_iterationCountValidator == null)
                    _iterationCountValidator = new IntegerValidator(1, int.MaxValue);
                return _iterationCountValidator;
            }
        }

        /// <summary>
        /// Gets a validator for System.Configuration.PBKDF2Section.SaltSize configuration property values.
        /// </summary>
        public static ConfigurationValidatorBase SaltSizeValidator
        {
            get
            {
                if (_saltSizeValidator == null)
                    _saltSizeValidator = new IntegerValidator(8, 65536);
                return _saltSizeValidator;
            }
        }

        #endregion
    }
}
