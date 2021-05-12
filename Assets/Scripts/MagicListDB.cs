using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class MagicListDB : MonoBehaviour
{
    public static BindingList<ShoppingList> shoppingLists = new BindingList<ShoppingList>();
    public static List<ShoppingReference> shoppingReferences = new List<ShoppingReference>()
    {
        new ShoppingReference("Orange", "orange", "orange.jpg"),
        new ShoppingReference("Pastis", "pastis", "pastis.jpg"),
        new ShoppingReference("Tofu", "tofu", "tofu.jpg")
    };

    void Awake()
    {
        DontDestroyOnLoad(this);
        MagicListDB.shoppingLists.ListChanged += ShoppingLists_ListChanged;

        for (int i = 0; i < 3; i++)
        {
            ShoppingList sl = new ShoppingList("test_" + i);
            sl.articles.Add(new ShoppingArticle(MagicListDB.shoppingReferences[0], 3));
            sl.articles.Add(new ShoppingArticle(MagicListDB.shoppingReferences[1], 1));
            sl.articles.Add(new ShoppingArticle(MagicListDB.shoppingReferences[2], 2));
            MagicListDB.shoppingLists.Add(sl);
        }
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
