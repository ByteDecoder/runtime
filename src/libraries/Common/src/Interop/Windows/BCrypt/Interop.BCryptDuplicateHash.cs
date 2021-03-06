// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;

internal partial class Interop
{
    internal partial class BCrypt
    {
        internal static SafeBCryptHashHandle BCryptDuplicateHash(SafeBCryptHashHandle hHash)
        {
            SafeBCryptHashHandle newHash;
            NTSTATUS status = BCryptDuplicateHash(hHash, out newHash, IntPtr.Zero, 0, 0);

            if (status != NTSTATUS.STATUS_SUCCESS)
            {
                newHash.Dispose();
                throw CreateCryptographicException(status);
            }

            return newHash;
        }

        [DllImport(Libraries.BCrypt, CharSet = CharSet.Unicode)]
        private static extern NTSTATUS BCryptDuplicateHash(
            SafeBCryptHashHandle hHash,
            out SafeBCryptHashHandle phNewHash,
            IntPtr pbHashObject,
            int cbHashObject,
            int dwFlags);
    }
}
