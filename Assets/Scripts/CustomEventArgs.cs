using System;
using System.Collections;
using System.Collections.Generic;

public class DeleteEventArgs : EventArgs
{
    public bool Cancel { get; set; } = false;
}

public class ReferenceEventArgs : EventArgs
{
    public ShoppingReference Item;

    public ReferenceEventArgs(ShoppingReference item)
    {
        this.Item = item;
    }
}