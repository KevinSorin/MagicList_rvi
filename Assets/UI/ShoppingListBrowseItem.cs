using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShoppingListBrowseItem : MonoBehaviour
{
    private ShoppingList shoppingList;

    public Text lblTitle;
    public Button btnEdit;
    public Button btnDelete;
    public Button btnRun;

    public ShoppingList ShoppingList
    {
        get
        {
            return this.shoppingList;
        }
        set
        {
            if(this.shoppingList != value)
            {
                this.shoppingList = value;
                this.lblTitle.text = this.shoppingList.Name;

                this.shoppingList.NameChanged += (o, ea) => { this.lblTitle.text = this.shoppingList.Name; };
                this.shoppingList.Deleted += (o, ea) => { Destroy(this.gameObject); };
            }
        }
    }

    void Start()
    {
        btnEdit.onClick.AddListener(delegate { MenuNavigation.ToListEdit(this.ShoppingList); });
        btnDelete.onClick.AddListener(delegate { this.shoppingList.delete(); });
        btnRun.onClick.AddListener(delegate { MenuNavigation.CurrentList = this.ShoppingList; MenuNavigation.ToScan(); });
    }

    void Update()
    {

    }
}