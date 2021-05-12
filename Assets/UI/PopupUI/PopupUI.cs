using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


namespace EasyUI.Dialogs
{
    public class Popup
    {
        public string Title = "Title";
        public string Message = "Contenu ici";
        public UnityAction OnClose;
    }

    public class PopupUI : MonoBehaviour
    {
        [SerializeField] GameObject canvas;
        [SerializeField] Text titleUIText;
        [SerializeField] Text messageUIText;
        [SerializeField] Button ajouterUIButton;

        Popup popup = new Popup();


        //Singleton pattern
        public static PopupUI Instance;

        void Awake()
        {
            Instance = this;

            //Add close event listener
            ajouterUIButton.onClick.RemoveAllListeners();
            ajouterUIButton.onClick.AddListener(Hide);
        }

        //Set Popup Title
        public PopupUI SetTitle(string title)
        {
            popup.Title = title;
            return Instance;
        }

        //Set Popup Title
        public PopupUI SetMessage(string message)
        {
            popup.Message = message;
            return Instance;
        }

        //Set Popup Title
        public PopupUI OnClose(UnityAction action)
        {
            popup.OnClose = action;
            return Instance;
        }

        //Show Popup
        public void Show()
        {
            titleUIText.text = popup.Title;
            messageUIText.text = popup.Message;

            canvas.SetActive(true);
        }

        //Hide Popup
        public void Hide()
        {
            canvas.SetActive(false);

            //Invoke OnClose Event
            if (popup.OnClose != null)
                popup.OnClose.Invoke();

            //Reset Popup
            popup = new Popup();

        }
        /*
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
        */
    }
}


