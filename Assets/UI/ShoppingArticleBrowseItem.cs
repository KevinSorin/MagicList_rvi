using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShoppingArticleBrowseItem : MonoBehaviour
{
    private ShoppingArticle article;

    public Text lblName;
    public InputField nudQuantity;
    public Button btnDelete;

    private Button btnMinus;
    private Button btnPlus;

    public ShoppingArticle ShoppingArticle
    {
        get
        {
            return this.article;
        }
        set
        {
            if(this.article != value)
            {

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

    void OnBtnPlusClicked()
    {
        this.article.Quantity += 1;
    }

    void OnBtnMinusClicked()
    {
        this.article.Quantity -= 1;
    }
}
