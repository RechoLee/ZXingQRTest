using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using ZXing;
using ZXing.QrCode;

public class GenerateCode : MonoBehaviour {

    public RawImage codeImage;

	// Use this for initialization
	void Start () {
        Generate("Hello World!");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// 生成一个二维码
    /// </summary>
    public void Generate(string info)
    {
        BarcodeWriter bw = new BarcodeWriter();
        bw.Format = BarcodeFormat.QR_CODE;
        //需要引入QrCode命名空间
        QrCodeEncodingOptions options = new QrCodeEncodingOptions
        {
            //设置optinos
            DisableECI = true,
            Height = 256,
            Width= 256,
            Margin=1,
            CharacterSet="UTF-8",
        };

        bw.Options = options;

        Color32[] code= bw.Write(info);
        Texture2D texture2D = new Texture2D(256,256);
        texture2D.SetPixels32(code);
        texture2D.Apply();

        codeImage.texture = texture2D;
    }
}
