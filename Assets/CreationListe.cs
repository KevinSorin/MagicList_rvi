using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ListeDeCourse
{
    public class CreationListe : MonoBehaviour
    {
        //public List<string> listeCourse;
        public InputField article;
        public ScrollRect previewListe;
        public Text Txtprefab;
        public Button Btnprefab;
        public ListeCourse listeValidee;

        void Start()
        {
            article.text = string.Empty;
        }


        void Update()
        {

        }

        public void ajouterArticle()
        {
            Text newArticle;
            Button newBtnDel;

            newArticle = (Text)Instantiate(Txtprefab, transform);

            newBtnDel = (Button)Instantiate(Btnprefab, transform);
            newBtnDel.onClick.AddListener(delegate {Destroy(newArticle.gameObject); Destroy(newBtnDel.gameObject); listeValidee.liste.Remove(newArticle.text);});

            newArticle.text =  article.text;
            listeValidee.liste.Add(article.text);
        }

    }
}