﻿// Copyright (c) Geekbuying Corporation
// All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License"); you may not
// use this file except in compliance with the License.  You may obtain a copy
// of the License at http://www.apache.org/licenses/LICENSE-2.0
// 
// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
// KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY IMPLIED
// WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE,
// MERCHANTABLITY OR NON-INFRINGEMENT.
// 
// See the Apache Version 2.0 License for specific language governing
// permissions and limitations under the License.

using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Geekbuying.HBaseClient.Tests.Utilities
{
    internal static class SecureStringExtensions
    {
        /// <summary>
        /// Transforms a SecureString into a string.
        /// </summary>
        /// <param name="value">
        /// The SecureString to transform.
        /// </param>
        /// <returns>
        /// A string representing the contents of the original SecureString.
        /// </returns>
        internal static string ToPlainString(this SecureString value)
        {
            if (value == null) return null;

            string rv;
            var pointer = IntPtr.Zero;
            try
            {
                pointer = Marshal.SecureStringToGlobalAllocUnicode(value);
                rv = Marshal.PtrToStringUni(pointer);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(pointer);
            }

            return rv;
        }
    }
}