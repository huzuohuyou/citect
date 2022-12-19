﻿using System.Diagnostics;
using System.Windows.Forms;

namespace CtApiExample
{
    class TextBoxTraceListener : TraceListener
    {
        private TextBox tBox; public TextBoxTraceListener(TextBox box) { this.tBox = box; }
        public override void Write(string msg)
        { //allows tBox to be updated from different thread
            tBox.Parent.Invoke(new MethodInvoker(delegate () { tBox.Text = msg+ tBox.Text; }));
        }
        public override void WriteLine(string msg) { Write(msg + "\r\n"); }
    }
}
