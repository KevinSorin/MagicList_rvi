using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;

public class ShoppingArticle
{
    public ShoppingReference reference;
    public BindingList<string> barCodes = new BindingList<string>();
    private int quantity = 1;

    public event EventHandler BarCodesListChanged;
    public event EventHandler QuantityChanged;
    public event EventHandler isQuantityReachedChanged;
    public event EventHandler Deleting;
    public event EventHandler Deleted;

    public ShoppingArticle(ShoppingReference reference)
    {
        this.reference = reference;
        this.barCodes.ListChanged += (o, ea) => OnBarCodesListChanged(ea);
    }

    public ShoppingArticle(ShoppingReference reference, int quantity) : this(reference)
    {
        this.quantity = quantity;
    }

    public int Quantity
    {
        get
        {
            return quantity;
        }
        set
        {
            if (this.quantity != value && value >= 0)
            {
                bool quantityReachedTemp = this.IsQuantityReached;

                this.quantity = value;
                OnQuantityChanged(EventArgs.Empty);

                if (this.IsQuantityReached != quantityReachedTemp)
                    OnIsQuantityReachedChanged(EventArgs.Empty);
            }
        }
    }

    public bool IsQuantityReached
    {
        get
        {
            return barCodes.Count >= quantity;
        }
    }

    public void delete()
    {
        DeleteEventArgs e = new DeleteEventArgs();
        OnDeleting(e);

        if (!e.Cancel)
        {
            OnDeleted(e);
        }
    }

    protected virtual void OnBarCodesListChanged(ListChangedEventArgs e)
    {
        if (e.ListChangedType == ListChangedType.ItemAdded)
        {
            if (barCodes.Count - 1 < quantity && IsQuantityReached)
                OnIsQuantityReachedChanged(EventArgs.Empty);
        }
        if (e.ListChangedType == ListChangedType.ItemDeleted)
        {
            if (barCodes.Count + 1 >= quantity && !IsQuantityReached)
                OnIsQuantityReachedChanged(EventArgs.Empty);
        }
        if (this.BarCodesListChanged != null)
            this.BarCodesListChanged(this, e);
    }

    protected virtual void OnQuantityChanged(EventArgs e)
    {
        if (this.QuantityChanged != null)
            this.QuantityChanged(this, e);
    }

    protected virtual void OnIsQuantityReachedChanged(EventArgs e)
    {
        if (this.isQuantityReachedChanged != null)
            this.isQuantityReachedChanged(this, e);
    }

    protected virtual void OnDeleting(DeleteEventArgs e)
    {
        if (this.Deleting != null)
            this.Deleting(this, e);
    }

    protected virtual void OnDeleted(DeleteEventArgs e)
    {
        if (this.Deleted != null)
            this.Deleted(this, e);
    }
}