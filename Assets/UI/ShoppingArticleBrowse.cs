using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShoppingArticleBrowse : MonoBehaviour
{
    public GameObject BrowseItemType;
    public GameObject grid;

    public List<ShoppingArticleBrowseItem> items = new List<ShoppingArticleBrowseItem>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addArticle(ShoppingArticle sa)
    {
        GameObject objectInstance = Instantiate(BrowseItemType);
        objectInstance.transform.SetParent(this.grid.transform, false);
        ShoppingArticleBrowseItem item = objectInstance.GetComponent("ShoppingArticleBrowseItem") as ShoppingArticleBrowseItem;
        item.ShoppingArticle = sa;

        items.Add(item);
    }

    public void removeArticle(ShoppingArticle sa)
    {
        List<ShoppingArticleBrowseItem> removedItems = items.Where(i => i.ShoppingArticle == sa).ToList();
        foreach(ShoppingArticleBrowseItem item in removedItems)
        {
            this.items.Remove(item);
            Destroy(item.gameObject);
        }
    }

    public void clearArticles()
    {
        foreach(ShoppingArticleBrowseItem item in items)
        {
            Destroy(item.gameObject);
        }
        this.items.Clear();
    }
}
