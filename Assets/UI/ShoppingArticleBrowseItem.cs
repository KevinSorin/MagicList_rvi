using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShoppingArticleBrowseItem : MonoBehaviour
{
    private ShoppingArticle shoppingArticle;

    public Text lblName;
    public InputField nudQuantity;
    public Button btnDelete;

    public Button btnMinus;
    public Button btnPlus;

    public ShoppingArticle ShoppingArticle
    {
        get
        {
            return this.shoppingArticle;
        }
        set
        {
            if(this.shoppingArticle != value && value != null)
            {
                this.shoppingArticle = value;
                this.lblName.text = this.shoppingArticle.reference.name;
                this.nudQuantity.text = this.shoppingArticle.Quantity.ToString();

                this.shoppingArticle.QuantityChanged += shoppingArticle_QuantityChanged;
                this.shoppingArticle.Deleted += shoppingArticle_Deleted;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        btnMinus.onClick.AddListener(OnBtnMinusClicked);
        btnPlus.onClick.AddListener(OnBtnPlusClicked);
        btnDelete.onClick.AddListener(OnBtnDeleteClicked);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void shoppingArticle_QuantityChanged(object sender, EventArgs e)
    {
        this.nudQuantity.text = this.shoppingArticle.Quantity.ToString();
    }

    void shoppingArticle_Deleted(object sender, EventArgs e)
    {
        Destroy(gameObject); ;
    }

    void OnBtnMinusClicked()
    {
        this.shoppingArticle.Quantity -= 1;
    }

    void OnBtnPlusClicked()
    {
        this.shoppingArticle.Quantity += 1;
    }

    void OnBtnDeleteClicked()
    {
        this.shoppingArticle.delete();
    }
}
