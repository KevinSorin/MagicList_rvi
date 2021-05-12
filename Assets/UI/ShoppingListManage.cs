using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShoppingListManage : MonoBehaviour
{
    public InputField txtName;
    public ShoppingArticleBrowse grid;
    public Button btnScan;

    private ShoppingList shoppingList = null;

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
                this.txtName.text = this.shoppingList.Name;

                this.grid.clearArticles();
                foreach (ShoppingArticle sa in this.shoppingList.articles)
                    this.grid.addArticle(sa);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        txtName.onValueChanged.AddListener(delegate { this.shoppingList.Name = this.txtName.text; });
        btnScan.onClick.AddListener(MenuNavigation.ToScan);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
