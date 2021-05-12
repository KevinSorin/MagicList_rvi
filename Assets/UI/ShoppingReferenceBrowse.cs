using System;
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

    public event EventHandler ReferenceSelected;

    // Start is called before the first frame update
    void Start()
    {
        btnClose.onClick.AddListener(delegate { this.gameObject.SetActive(false); });

        foreach(ShoppingReference sr in MagicListDB.shoppingReferences)
        {
            this.addShoppingReference(sr);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addShoppingReference(ShoppingReference sr)
    {
        GameObject objectInstance = Instantiate(BrowseItemType);
        objectInstance.transform.SetParent(this.grid.transform, false);

        ShoppingReferenceBrowseItem item = objectInstance.GetComponent("ShoppingReferenceBrowseItem") as ShoppingReferenceBrowseItem;
        item.ShoppingReference = sr;

        item.btnSelect.onClick.AddListener(delegate { this.OnReferenceSelected(new ReferenceEventArgs(sr)); });

        items.Add(item);
    }

    protected virtual void OnReferenceSelected(ReferenceEventArgs e)
    {
        if (this.ReferenceSelected != null)
            this.ReferenceSelected(this, e);
    }
}
