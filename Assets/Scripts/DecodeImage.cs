using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ZXing;

public class DecodeImage : MonoBehaviour {

    public RawImage rawImage;
    WebCamTexture webCam;

    // Use this for initialization
    void Start () {
        WebCamDevice[] devices = WebCamTexture.devices;//获取设备相机集合
        string webCamName = devices[0].name;//
        webCam = new WebCamTexture(webCamName, 400,300);//相机的Texture
        rawImage.texture = webCam;//将texture显示在界面。
        //开始获取
        webCam.Play();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// 将拍摄的二维码解码 获取其中的信息
    /// </summary>
    public void Decode()
    {
        BarcodeReader br = new BarcodeReader();
        Color32[] data = webCam.GetPixels32();

        Result result= br.Decode(data, 400, 300);

        Debug.Log(result.Text);
        
    }
}
