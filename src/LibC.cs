//
// The MIT License (MIT)
//
// Copyright (c) 2013 Alex Rønne Petersen
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
//

using System;
using System.Runtime.InteropServices;

namespace Mono.Debugger.Client
{
    static class LibC
    {
        // These values are correct for Linux, OS X, and FreeBSD. Might
        // need to be reviewed for other platforms.

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void SignalHandler(int signal);

        public static readonly IntPtr ErrorSignal = new IntPtr(-1);

        public static readonly IntPtr IgnoreSignal = new IntPtr(1);

        public static readonly IntPtr DefaultSignal = IntPtr.Zero;

        public const int SignalInterrupt = 2;

        [DllImport("libc", EntryPoint = "signal")]
        public static extern IntPtr SetSignal(int signal, IntPtr handler);

        [DllImport("libc", EntryPoint = "printf")]
        public static extern int Print(string value);
    }
}
