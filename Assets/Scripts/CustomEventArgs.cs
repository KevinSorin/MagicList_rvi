using System;
using System.Collections;
using System.Collections.Generic;

public class DeleteEventArgs : EventArgs
{
    public bool Cancel { get; set; } = false;
}
