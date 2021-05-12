using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class ShoppingListBrowse : MonoBehaviour
{
    //Header
    public Button btnNew;

    //Grid
    public GameObject BrowseItemType;
    public GameObject grid;
    List<ShoppingListBrowseItem> items = new List<ShoppingListBrowseItem>();

    // Start is called before the first frame update
    void Start()
    {
        btnNew.onClick.AddListener(MenuNavigation.ToListCreate);

        MagicListDB.shoppingLists.ListChanged += ShoppingLists_ListChanged;
        foreach (ShoppingList sl in MagicListDB.shoppingLists)
        {
            addShoppingList(sl);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void ShoppingLists_ListChanged(object sender, ListChangedEventArgs e)
    {
        if (e.ListChangedType == ListChangedType.ItemAdded)
        {
            addShoppingList(MagicListDB.shoppingLists[e.NewIndex]);
        }
    }

    void addShoppingList(ShoppingList sl)
    {
        GameObject objectInstance = Instantiate(BrowseItemType);
        objectInstance.transform.SetParent(this.grid.transform, false);

        ShoppingListBrowseItem item = objectInstance.GetComponent("ShoppingListBrowseItem") as ShoppingListBrowseItem;
        item.ShoppingList = sl;
        items.Add(item);
    }
}
