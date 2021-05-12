using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

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

    //Initialized
    public GameObject content;

    public Button btnTitle;

    public MainMenu mainMenu;
    public ShoppingListBrowse listBrowse;
    public ShoppingListManage listManage;
    public Scan scan;

    //Static
    public static MenuStates currentState = MenuStates.MainMenu;
    public static ShoppingList CurrentList = null;

    public static MainMenu MainMenu;
    public static ShoppingListBrowse ListBrowse;
    public static ShoppingListManage ListManage;
    public static Scan Scan;

    void Start()
    {
        MenuNavigation.MainMenu = this.mainMenu;
        MenuNavigation.ListBrowse = this.listBrowse;
        MenuNavigation.ListManage = this.listManage;
        MenuNavigation.Scan = this.scan;

        btnTitle.onClick.AddListener(MenuNavigation.ToMainMenu);

        ToMainMenu();
    }

    void Update()
    {
        
    }

    public static void ToMainMenu()
    {
        MenuNavigation.Scan.CloseLeftPanel();
        MenuNavigation.CurrentList = null;

        MenuNavigation.MainMenu.gameObject.SetActive(true);
        MenuNavigation.ListBrowse.gameObject.SetActive(false);
        MenuNavigation.ListManage.gameObject.SetActive(false);
        MenuNavigation.Scan.gameObject.SetActive(false);
    }

    public static void ToListBrowse()
    {
        MenuNavigation.Scan.CloseLeftPanel();
        MenuNavigation.CurrentList = null;

        MenuNavigation.MainMenu.gameObject.SetActive(false);
        MenuNavigation.ListBrowse.gameObject.SetActive(true);
        MenuNavigation.ListManage.gameObject.SetActive(false);
        MenuNavigation.Scan.gameObject.SetActive(false);
    }

    public static void ToListCreate()
    {
        MenuNavigation.Scan.CloseLeftPanel();

        ShoppingList sl = new ShoppingList();
        MagicListDB.shoppingLists.Add(sl);
        MenuNavigation.CurrentList = sl;
        MenuNavigation.ListManage.ShoppingList = sl;

        MenuNavigation.MainMenu.gameObject.SetActive(false);
        MenuNavigation.ListBrowse.gameObject.SetActive(false);
        MenuNavigation.ListManage.gameObject.SetActive(true);
        MenuNavigation.Scan.gameObject.SetActive(false);
    }

    public static void ToListEdit(ShoppingList sl)
    {
        MenuNavigation.Scan.CloseLeftPanel();

        MenuNavigation.CurrentList = sl;
        MenuNavigation.ListManage.ShoppingList = MenuNavigation.CurrentList;

        MenuNavigation.MainMenu.gameObject.SetActive(false);
        MenuNavigation.ListBrowse.gameObject.SetActive(false);
        MenuNavigation.ListManage.gameObject.SetActive(true);
        MenuNavigation.Scan.gameObject.SetActive(false);
    }

    public static void ToScan()
    {
        MenuNavigation.Scan.CloseLeftPanel();

        MenuNavigation.Scan.panel.SetActive(MenuNavigation.CurrentList != null);
        MenuNavigation.Scan.btnOpenClose.gameObject.SetActive(MenuNavigation.CurrentList != null);
        MenuNavigation.Scan.shoppingListOverview.ShoppingList = MenuNavigation.CurrentList;

        MenuNavigation.MainMenu.gameObject.SetActive(false);
        MenuNavigation.ListBrowse.gameObject.SetActive(false);
        MenuNavigation.ListManage.gameObject.SetActive(false);
        MenuNavigation.Scan.gameObject.SetActive(true);
    }
}
