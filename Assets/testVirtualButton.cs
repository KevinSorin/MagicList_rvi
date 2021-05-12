using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class testVirtualButton : MonoBehaviour
{
    public GameObject button;
    public GameObject cube;

    // Start is called before the first frame update
    void Start()
    {
        button = GameObject.Find("VirtualButton");
        button.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonPressed(OnButtonPressed);
        button.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonReleased(OnButtonReleased);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        var cubeRenderer = cube.GetComponent<Renderer>();
        cubeRenderer.material.SetColor("_Color", Color.red);

        Debug.Log("BUTTON PRESSED");
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        var cubeRenderer = cube.GetComponent<Renderer>();
        cubeRenderer.material.SetColor("_Color", Color.yellow);

        Debug.Log("BUTTON RELEASED");
    }
}
