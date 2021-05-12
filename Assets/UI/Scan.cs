using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

using Vuforia;

using UnityEngine;
using UnityEngine.UI;
using ZXing;
using ZXing.QrCode;

public class Scan : MonoBehaviour
{
    #region BARCODE
    private string barCode;
    public string BarCode
    {
        get
        {
            return this.barCode;
        }
        set
        {
            if(this.barCode != value)
            {
                this.barCode = value;
            }
        }
    }
    #endregion

    #region LEFT_PANEL
    public GameObject panel;
    public Button btnOpenClose;

    public bool opened = false;

    void OnBtnOpenCloseClicked()
    {
        if (opened)
            CloseLeftPanel();
        else
            OpenLeftPanel();
    }

    public void OpenLeftPanel()
    {
        if (!opened)
        {
            panel.transform.position = panel.transform.position + new Vector3(540, 0, 0);
            btnOpenClose.transform.position = btnOpenClose.transform.position + new Vector3(540, 0, 0);
            opened = true;
        }
    }

    public void CloseLeftPanel()
    {
        if(opened)
        {
            panel.transform.position = panel.transform.position + new Vector3(-540, 0, 0);
            btnOpenClose.transform.position = btnOpenClose.transform.position + new Vector3(-540, 0, 0);
            opened = false;
        }
    }
    #endregion

    #region PRIVATE_MEMBERS
    private PIXEL_FORMAT mPixelFormat = PIXEL_FORMAT.UNKNOWN_FORMAT;
    private bool mAccessCameraImage = true;
    private bool mFormatRegistered = false;
    private IBarcodeReader _barcodeReader = new BarcodeReader();
    #endregion // PRIVATE_MEMBERS

    #region MONOBEHAVIOUR_METHODS
    void Start()
    {
#if UNITY_EDITOR
        mPixelFormat = PIXEL_FORMAT.GRAYSCALE; // Need Grayscale for Editor
#else
        mPixelFormat = PIXEL_FORMAT.RGB888; // Use RGB888 for mobile
#endif

        // Register Vuforia life-cycle callbacks:
        VuforiaARController.Instance.RegisterVuforiaStartedCallback(OnVuforiaStarted);
        InvokeRepeating("OnTrackablesUpdated", 2f, 1f);
        VuforiaARController.Instance.RegisterOnPauseCallback(OnPause);

        btnOpenClose.onClick.AddListener(OnBtnOpenCloseClicked);
    }
    #endregion // MONOBEHAVIOUR_METHODS

    #region PRIVATE_METHODS
    private void OnVuforiaStarted()
    {
        // Try register camera image format
        if (CameraDevice.Instance.SetFrameFormat(mPixelFormat, true))
        {
            Debug.Log("Successfully registered pixel format " + mPixelFormat.ToString());
            mFormatRegistered = true;
        }
        else
        {
            Debug.LogError(
                "\nFailed to register pixel format: " + mPixelFormat.ToString() +
                "\nThe format may be unsupported by your device." +
                "\nConsider using a different pixel format.\n");
            mFormatRegistered = false;
        }
    }
    /// 
    /// Called each time the Vuforia state is updated
    /// 
    void OnTrackablesUpdated()
    {
        CameraDevice.Instance.SetFocusMode(CameraDevice.FocusMode.FOCUS_MODE_TRIGGERAUTO);

        RegognizeQR();
    }

    void RegognizeQR()
    {
        if (mFormatRegistered)
        {
            if (mAccessCameraImage)
            {

                Vuforia.Image image = CameraDevice.Instance.GetCameraImage(mPixelFormat);

                if (image == null)
                {
                    Debug.Log("Camera image capture failure;");
                }
                else
                {
                    var imgSource = new RGBLuminanceSource(image.Pixels, image.BufferWidth, image.BufferHeight, true);

                    var result = _barcodeReader.Decode(imgSource);
                    if (result != null)
                    {

                        /*PopupUI.Instance
                            .SetTitle("Detection de QR Code")
                            .SetMessage(result.Text)
                            .OnClose(delegate { Debug.Log("Closed");})
                            .Show();
                        Debug.Log("RECOGNIZED: " + result.Text);*/
                        barCode = result.Text;
                    }
                }
            }
        }

    }

    /// 
    /// Called when app is paused / resumed
    /// 
    void OnPause(bool paused)
    {
        if (paused)
        {
            Debug.Log("App was paused");
            UnregisterFormat();
        }
        else
        {
            Debug.Log("App was resumed");
            RegisterFormat();
        }
    }
    /// 
    /// Register the camera pixel format
    /// 
    void RegisterFormat()
    {
        if (CameraDevice.Instance.SetFrameFormat(mPixelFormat, true))
        {
            Debug.Log("Successfully registered camera pixel format " + mPixelFormat.ToString());
            mFormatRegistered = true;
        }
        else
        {
            Debug.LogError("Failed to register camera pixel format " + mPixelFormat.ToString());
            mFormatRegistered = false;
        }
    }
    /// 
    /// Unregister the camera pixel format (e.g. call this when app is paused)
    /// 
    void UnregisterFormat()
    {
        Debug.Log("Unregistering camera pixel format " + mPixelFormat.ToString());
        CameraDevice.Instance.SetFrameFormat(mPixelFormat, false);
        mFormatRegistered = false;
    }
    #endregion //PRIVATE_METHODS

    void Update()
    {
    }

    public ShoppingListOverview shoppingListOverview;
}
