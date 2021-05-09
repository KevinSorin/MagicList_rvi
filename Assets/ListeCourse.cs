using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ListeDeCourse
{
    public class ListeCourse : MonoBehaviour
    {
        public List<string> liste;
        public Text ArticleName;

        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }


        public void afficherListe()
        {
            Text article;

            foreach(string txt in liste)
            {
                ArticleName.name = txt;
                if (transform.Find(ArticleName.name + "(Clone)") == null)
                {
                    article = (Text)Instantiate(ArticleName, transform);
                    article.text = txt;
                }
            }
        }
    }
}
