using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class MagicListDB : MonoBehaviour
{
    public static BindingList<ShoppingList> shoppingLists = new BindingList<ShoppingList>();
    public static List<ShoppingReference> shoppingReferences = new List<ShoppingReference>();

    void Awake()
    {
        for (int i = 0; i < 10; i++)
            shoppingLists.Add(new ShoppingList("test_" + i));

        MagicListDB.shoppingLists.ListChanged += ShoppingLists_ListChanged;
    }

    private void ShoppingLists_ListChanged(object sender, ListChangedEventArgs e)
    {
        if (e.ListChangedType == ListChangedType.ItemAdded)
        {
            ShoppingList sl = MagicListDB.shoppingLists[e.NewIndex];
            sl.Deleted += (o, ea) => { MagicListDB.shoppingLists.Remove(sl); };
        }
    }
}
