using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuNavigation : MonoBehaviour
{
    public enum MenuStates
    {
        MainMenu,
        ListBrowse,
        ListCreate,
        ListEdit,
        Scan
    };

    public GameObject content;

    public MainMenu mainMenu;
    public ShoppingListBrowse listBrowse;
    public ShoppingListManage listManage;

    // Start is called before the first frame update
    void Start()
    {
        mainMenu.gameObject.SetActive(true);
        listBrowse.gameObject.SetActive(false);
        listManage.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateList()
    {

    }

    void BrowseList()
    {

    }

    void EditList()
    {

    }
}
