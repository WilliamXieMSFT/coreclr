// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

// try/finally embedded in a try catch with a nonlocal exit 
using System;

namespace hello
{
    class Class1
    {
        private static TestUtil.TestLog testLog;

        static Class1()
        {
            // Create test writer object to hold expected output
            System.IO.StringWriter expectedOut = new System.IO.StringWriter();

            // Write expected output to string writer object
            expectedOut.WriteLine("in finally");
            expectedOut.WriteLine("done");

            // Create and initialize test log object
            testLog = new TestUtil.TestLog(expectedOut);
        }

        static public int Main(string[] args)
        {
            //Start recording
            testLog.StartRecording();

            try
            {
                if (args.Length == 0) goto done;
                Console.WriteLine("in try");
            }
            finally
            {
                Console.WriteLine("in finally");
            }
            Console.WriteLine("after finally");
            Console.WriteLine("unreached");
            done:
            Console.WriteLine("done");

            // stop recoding
            testLog.StopRecording();

            return testLog.VerifyOutput();
        }

    }
}

