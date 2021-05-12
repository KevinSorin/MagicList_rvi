using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShoppingReferenceBrowseItem : MonoBehaviour
{
    private ShoppingReference shoppingReference;

    public Image imgReference;
    public Text lblName;
    public Button btnSelect;

    public ShoppingReference ShoppingReference
    {
        get
        {
            return this.shoppingReference;
        }
        set
        {

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
