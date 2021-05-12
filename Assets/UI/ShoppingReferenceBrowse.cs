using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ShoppingReferenceBrowse : MonoBehaviour
{
    //Header
    public Button btnClose;

    //Grid
    public GameObject BrowseItemType;
    public GameObject grid;
    public List<ShoppingReferenceBrowseItem> items = new List<ShoppingReferenceBrowseItem>();

    // Start is called before the first frame update
    void Start()
    {
        foreach(ShoppingReference sr in MagicListDB.shoppingReferences)
        {
            this.addShoppingReference(sr);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void addShoppingReference(ShoppingReference sr)
    {
        GameObject objectInstance = Instantiate(BrowseItemType);
        objectInstance.transform.SetParent(this.grid.transform, false);

        ShoppingReferenceBrowseItem item = objectInstance.GetComponent("ShoppingReferenceBrowseItem") as ShoppingReferenceBrowseItem;
        item.ShoppingReference = sr;

        items.Add(item);
    }

    void hideShoppingReferences(List<ShoppingReference> references)
    {
        foreach (ShoppingReferenceBrowseItem item in items.Where(i => references.Contains(i.ShoppingReference)))
            item.gameObject.SetActive(false);
    }

    void clearHidden()
    {
        foreach (ShoppingReferenceBrowseItem item in items)
            item.gameObject.SetActive(true);
    }

    /*void removeShoppingReference(ShoppingReferenceBrowse sr)
    {

    }*/
}
