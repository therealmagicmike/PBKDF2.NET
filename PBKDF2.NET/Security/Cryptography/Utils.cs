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

namespace System.Security.Cryptography
{
    /// <summary>
    /// Internal utility/helper class
    /// </summary>
    internal static class Utils
    {
        #region fields

        private static RNGCryptoServiceProvider _rng = null;

        #endregion

        #region properties

        /// <summary>
        /// Provides access to a static RngCryptoServiceProvider.
        /// </summary>
        internal static RNGCryptoServiceProvider StaticRngCryptoService
        {
            get
            {
                if (_rng == null)
                    _rng = new RNGCryptoServiceProvider();
                return _rng;
            }
        }

        #endregion

        #region methods

        /// <summary>
        /// Encodes an integer into a 4-byte array, in big endian.
        /// </summary>
        /// <param name="i">The integer to encode.</param>
        /// <returns>array of bytes, in big endian.</returns>
        internal static byte[] GetBigEndianBytes(uint i)
        {
            byte[] b = BitConverter.GetBytes(i);
            byte[] invertedBytes = { b[3], b[2], b[1], b[0] };
            return BitConverter.IsLittleEndian ? invertedBytes : b;
        }

        /// <summary>
        /// Generates a new random salt of the specified size.
        /// </summary>
        /// <param name="saltSize">The size of the salt to be generated, in bytes.</param>
        /// <returns>A new random salt of the specified size.</returns>
        /// <exception cref="System.ArgumentException">A salt must be at least 8 bytes in size.</exception>
        internal static byte[] GenerateSalt(int saltSize)
        {
            if (saltSize < 8)
                throw new ArgumentException("A salt must be at least 8 bytes in length.", "saltSize");

            byte[] salt = new byte[saltSize];
            StaticRngCryptoService.GetBytes(salt);
            return salt;
        }

        #endregion
    }
}
