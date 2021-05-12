using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class ShoppingListOverview : MonoBehaviour
{
    private ShoppingList shoppingList;

    public Text lblName;
    public Button btnEdit;

    public GameObject BrowseItemType;
    public GameObject grid;
    public List<ShoppingListOverviewItem> items;

    public ShoppingList ShoppingList
    {
        get
        {
            return this.shoppingList;
        }
        set
        {
            if (this.shoppingList != value && value != null)
            {
                clearArticles();

                this.shoppingList = value;

                this.lblName.text = this.shoppingList.Name;
                this.shoppingList.NameChanged += (o, ea) => { this.lblName.text = this.shoppingList.Name; };

                this.shoppingList.articles.ListChanged += shoppingList_ListChanged;

                foreach (ShoppingArticle sa in this.shoppingList.articles)
                    this.addShoppingArticle(sa);
            }
        }
    }

    private void shoppingList_ListChanged(object sender, ListChangedEventArgs e)
    {

    }

    void addShoppingArticle(ShoppingArticle sa)
    {
        GameObject objectInstance = Instantiate(BrowseItemType);
        objectInstance.transform.SetParent(this.grid.transform, false);

        ShoppingListOverviewItem item = objectInstance.GetComponent("ShoppingListOverviewItem") as ShoppingListOverviewItem;
        item.ShoppingArticle = sa;
        items.Add(item);
    }

    public void clearArticles()
    {
        foreach (ShoppingListOverviewItem item in items)
        {
            Destroy(item.gameObject);
        }
        this.items.Clear();
    }

    // Start is called before the first frame update
    void Start()
    {
        this.btnEdit.onClick.AddListener(delegate { MenuNavigation.ToListEdit(this.shoppingList); });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
