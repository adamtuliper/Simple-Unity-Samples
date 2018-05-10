#define DEBUG

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class UnityConsoleDebugTraceListener : TraceListener
{
    private int outputMessageCount;

    public override void Write(string message)
    {
        outputMessageCount++;
        UnityEngine.Debug.Log(message);
    }

    public override void WriteLine(string message)
    {
        outputMessageCount++;
        UnityEngine.Debug.Log(message);
    }

    protected override void Dispose(bool disposing)
    {
        UnityEngine.Debug.Log(string.Format("Disposing trace listener, {0} entries written.", outputMessageCount));
        base.Dispose(disposing);
    }
}
