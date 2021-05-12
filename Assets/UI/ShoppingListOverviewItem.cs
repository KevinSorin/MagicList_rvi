using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShoppingListOverviewItem : MonoBehaviour
{
    private ShoppingArticle shoppingArticle;

    public Text lblName;
    public Text lblQuantity;
    public Image imgQuantityReached;

    public ShoppingArticle ShoppingArticle
    {
        get
        {
            return this.shoppingArticle;
        }
        set
        {
            if (this.shoppingArticle != value)
            {
                this.shoppingArticle = value;

                this.lblName.text = this.shoppingArticle.Name;
                this.lblQuantity.text = this.shoppingArticle.CurrentQuantity.ToString() + " / " + this.shoppingArticle.Quantity.ToString();
                this.imgQuantityReached.enabled = this.shoppingArticle.IsQuantityReached;

                this.shoppingArticle.CurrentQuantityChanged += (o, ea) => { this.lblQuantity.text = this.shoppingArticle.CurrentQuantity.ToString() + " / " + this.shoppingArticle.Quantity.ToString(); };
                this.shoppingArticle.QuantityChanged += (o, ea) => { this.lblQuantity.text = this.shoppingArticle.CurrentQuantity.ToString() + " / " + this.shoppingArticle.Quantity.ToString(); };
                this.shoppingArticle.IsQuantityReachedChanged += (o, ea) => { this.imgQuantityReached.enabled = this.shoppingArticle.IsQuantityReached; };
                this.shoppingArticle.Deleted += (o, ea) => { Destroy(gameObject); };
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
