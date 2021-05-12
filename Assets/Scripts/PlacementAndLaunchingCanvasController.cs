using UnityEngine;
using UnityEngine.UI;
using Vuforia;
using System.Collections;
using System.Collections.Generic;

public class PlacementAndLaunchingCanvasController : MonoBehaviour
{

    [SerializeField]
    private PlacementObject placedObject;

    [SerializeField]
    private Color activeColor = Color.red;

    [SerializeField]
    private Color inactiveColor = Color.gray;

    [SerializeField]
    private Camera arCamera;

    [SerializeField]
    private bool displayCanvas = true;
	
	[SerializeField]
	private GameObject VirtualButton;
	
	[SerializeField]
	private GameObject cube;
	
	private bool ButtonPressed;	
	
	[SerializeField]
	private Text yuka;

    void Awake() 
    {
		
    }

	void Start()
	{
		VirtualButton = GameObject.Find("VirtualButton");
		ButtonPressed = false;
        VirtualButton.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonPressed(OnButtonPressed);
        VirtualButton.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonReleased(OnButtonReleased);		
	}
	
	public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        var cubeRenderer = cube.GetComponent<Renderer>();
        cubeRenderer.material.SetColor("_Color", Color.red);
		ButtonPressed = !ButtonPressed;
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        var cubeRenderer = cube.GetComponent<Renderer>();
        cubeRenderer.material.SetColor("_Color", Color.yellow);
    }
	
	
    void Update()
    {
		Debug.Log("Button is " + (ButtonPressed ? "pressed" : "not pressed"));
		// if we got a hit meaning that it was selected
		if (ButtonPressed)
		{
			PlacementObject placementObject = cube.transform.GetComponent<PlacementObject>();
			MeshRenderer placementObjectMeshRenderer = placedObject.GetComponent<MeshRenderer>();
			if(placementObject != null)
			{
				placementObject.Selected = true;
				placementObjectMeshRenderer.material.color = activeColor;
				
				if(displayCanvas) 
				{
					yuka.text = MenuNavigation.Scan.BarCode;
					placementObject.ToggleCanvas();
				}
			}
		}
		else
		{
			PlacementObject placementObject = placedObject.GetComponent<PlacementObject>();
			MeshRenderer placementObjectMeshRenderer = placedObject.GetComponent<MeshRenderer>();
			if(placementObject != null)
			{
				placementObject.Selected = false;
				placementObjectMeshRenderer.material.color = inactiveColor;

				if(displayCanvas) 
				{
					placementObject.HideCanvas();
				}
			}
		}
    }
}
