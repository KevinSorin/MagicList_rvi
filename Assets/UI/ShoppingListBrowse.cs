using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class ShoppingListBrowse : MonoBehaviour
{
    public GameObject BrowseItemType;

    public InputField txtSearch;
    public Button btnResetSearch;

    public GameObject grid;

    List<GameObject> items = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        connectDataSource();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void connectDataSource()
    {
        MagicListDB.shoppingLists.ListChanged += ShoppingLists_ListChanged;
        foreach (ShoppingList sl in MagicListDB.shoppingLists)
        {
            addShoppingList(sl);
        }
    }
    private void ShoppingLists_ListChanged(object sender, ListChangedEventArgs e)
    {
        if (e.ListChangedType == ListChangedType.ItemAdded)
        {
            ShoppingList sl = MagicListDB.shoppingLists[e.NewIndex];
            addShoppingList(sl);
        }
    }

    void addShoppingList(ShoppingList sl)
    {
        GameObject objectInstance = Instantiate(BrowseItemType);
        objectInstance.transform.SetParent(this.grid.transform, false);

        ShoppingListBrowseItem item = objectInstance.GetComponent("ShoppingListBrowseItem") as ShoppingListBrowseItem;
        item.ShoppingListObject = sl;
    }
}
