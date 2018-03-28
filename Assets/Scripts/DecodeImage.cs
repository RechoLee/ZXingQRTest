using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ZXing;

public class DecodeImage : MonoBehaviour {

    public RawImage rawImage;
    WebCamTexture webCam;

    public Texture2D texture;

    // Use this for initialization
    void Start () {

        DecodeForFile();

    }

    /// <summary>
    /// 相机扫描
    /// </summary>
    public void ScanImage()
    {
        WebCamDevice[] devices = WebCamTexture.devices;//获取设备相机集合
        string webCamName = devices[0].name;//
        webCam = new WebCamTexture(webCamName, 400, 300);//相机的Texture
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

    public void DecodeForFile()
    {

        BarcodeReader br = new BarcodeReader();

        //这里需要注意 要将texture设置为可读可写 参考网址
        //https://docs.unity3d.com/Manual/class-TextureImporter.html
        Color32[] data = texture.GetPixels32();

        var result= br.Decode(data,texture.width,texture.height);

        Debug.Log(result.Text);
    }
}
