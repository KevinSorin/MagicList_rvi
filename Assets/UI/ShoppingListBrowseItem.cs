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

    public ShoppingList ShoppingListObject
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
                this.lblTitle.text = this.shoppingList.name;
                this.shoppingList.Deleted += (o, ea) => OnListDeleted();
            }
        }
    }

    void OnListDeleted()
    {
        Destroy(this.gameObject);
    }

    void OnBtnDeleteClicked()
    {
        this.shoppingList.delete();
    }

    // Start is called before the first frame update
    void Start()
    {
        btnDelete.onClick.AddListener(OnBtnDeleteClicked);
    }

    // Update is called once per frame
    void Update()
    {

    }
}