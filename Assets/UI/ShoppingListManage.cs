using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class ShoppingListManage : MonoBehaviour
{
    public InputField txtName;
    public ShoppingArticleBrowse grid;
    public Button btnScan;
    public Button btnAdd;
    public ShoppingReferenceBrowse referenceSelector;

    private ShoppingList shoppingList;
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

                this.shoppingList.articles.ListChanged += (o, ea) => {
                    if (ea.ListChangedType == ListChangedType.ItemAdded)
                    {
                        this.grid.addArticle(this.shoppingList.articles[ea.NewIndex]);
                    }
                };
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        txtName.onValueChanged.AddListener(delegate { this.shoppingList.Name = this.txtName.text; });
        
        btnAdd.onClick.AddListener(delegate {
            this.referenceSelector.gameObject.SetActive(true); 
            this.referenceSelector.transform.SetAsLastSibling(); 
        });

        referenceSelector.ReferenceSelected += referenceSelector_ReferenceSelected;
        
        btnScan.onClick.AddListener(MenuNavigation.ToScan);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void referenceSelector_ReferenceSelected(object sender, EventArgs e)
    {
        ShoppingArticle sa = new ShoppingArticle((e as ReferenceEventArgs).Item);
        this.ShoppingList.articles.Add(sa);

        this.referenceSelector.gameObject.SetActive(false);
    }
}
