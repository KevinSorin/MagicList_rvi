using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button btnNewList;
    public Button btnBrowseList;
    public Button btnScan;

    // Start is called before the first frame update
    void Start()
    {
        this.btnNewList.onClick.AddListener(MenuNavigation.ToListCreate);
        this.btnBrowseList.onClick.AddListener(MenuNavigation.ToListBrowse);
        this.btnScan.onClick.AddListener(MenuNavigation.ToScan);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
