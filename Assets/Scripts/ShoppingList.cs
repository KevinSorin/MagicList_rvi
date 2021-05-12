using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;

public class ShoppingList
{
    private string name = "New shopping list";
    public BindingList<ShoppingArticle> articles = new BindingList<ShoppingArticle>();
    private bool? isListCompleted = null;
    private bool closed = false;

    public event EventHandler NameChanged;
    public event EventHandler ArticlesChanged;
    public event EventHandler ListCompletedChanged;
    public event EventHandler ClosedChanged;
    public event EventHandler Deleting;
    public event EventHandler Deleted;

    public ShoppingList()
    {
        this.articles.ListChanged += (o, e) => OnArticlesChanged(e);
    }

    public ShoppingList(string name) : this()
    {
        this.name = name;
    }

    public override string ToString()
    {
        return this.name;
    }

    public string Name
    {
        get
        {
            return this.name;
        }
        set
        {
            if(this.name != value)
            {
                this.name = value;
                OnNameChanged(EventArgs.Empty);
            }
        }
    }

    private void updateIsListCompleted()
    {
        bool val = (articles.Where(a => !(a.IsQuantityReached)).Count() == 0);
        bool changed = isListCompleted != null && isListCompleted != val;
        isListCompleted = val;
        if (changed)
            OnListCompletedChanged(EventArgs.Empty);
    }
    public bool IsListCompleted
    {
        get
        {
            updateIsListCompleted();
            return isListCompleted ?? false;
        }
    }

    public bool Closed
    {
        get
        {
            return closed;
        }
        set
        {
            if(closed != value)
            {
                closed = value;
                OnClosedChanged(EventArgs.Empty);
            }
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

    protected virtual void OnNameChanged(EventArgs e)
    {
        if (this.NameChanged != null)
            this.NameChanged(this, e);
    }

    protected virtual void OnArticlesChanged(ListChangedEventArgs e)
    {
        if (e.ListChangedType == ListChangedType.ItemAdded)
        {
            this.articles.ElementAt(e.NewIndex).Deleted += (o, ea) => this.articles.Remove(this.articles.ElementAt(e.NewIndex));
            this.articles.ElementAt(e.NewIndex).IsQuantityReachedChanged += (o,ea) => updateIsListCompleted();
        }

        if (this.ArticlesChanged != null)
            this.ArticlesChanged(this, e);
    }

    protected virtual void OnListCompletedChanged(EventArgs e)
    {
        if (this.ListCompletedChanged != null)
            this.ListCompletedChanged(this, e);
    }

    protected virtual void OnClosedChanged(EventArgs e)
    {
        if (this.ClosedChanged != null)
            this.ClosedChanged(this, e);
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
