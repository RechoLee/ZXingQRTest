using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Drawing;
using ZXing;
using ZXing.QrCode;
using System.IO;
using ZXing.QrCode.Internal;
using ZXing.Common;

public class GenerateCode : MonoBehaviour {

    public RawImage codeImage;

	// Use this for initialization
	void Start () {
        Generate("http://www.baidu.com/");
        //Generate("123456789052154561316130340");
        //Test("Hello");
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
        bw.Format = BarcodeFormat.QR_CODE;//二维码
        //需要引入QrCode命名空间
        QrCodeEncodingOptions options = new QrCodeEncodingOptions
        {
            //设置optinos
            DisableECI = true,
            Height = 256,
            Width= 256,
            Margin=2,
            CharacterSet="UTF-8",
        };

        bw.Options = options;

        Color32[] code= bw.Write(info);
        Texture2D texture2D = new Texture2D(256,256);
        texture2D.SetPixels32(code);
        texture2D.Apply();

        codeImage.texture = texture2D;

        //保存
        var path=Application.dataPath+"/Image";
        string name = Guid.NewGuid().ToString() + ".png";
        FileStream fs = new FileStream(path + "/" + name, FileMode.OpenOrCreate);
        fs.Write(texture2D.EncodeToPNG(), 0, texture2D.EncodeToPNG().Length);
        fs.Dispose();
        fs.Close();

    }

    /// <summary>
    /// 生成条形码
    /// </summary>
    /// <param name="info"></param>
    public void Generate2(string info)
    {
        QrCodeEncodingOptions myOptions = new QrCodeEncodingOptions
        {
            Width = 256,
            Height= 128,
            Margin=2
        };

        BarcodeWriter bw = new BarcodeWriter
        {
            Format = BarcodeFormat.CODE_128,//关键部分
            //Format=BarcodeFormat.ITF,
            Options = myOptions
        };

        //
        Color32[] code = bw.Write(info);
        Texture2D texture = new Texture2D(256,128);
        texture.SetPixels32(code);
        texture.Apply();
        codeImage.texture = texture;
    }

    /// <summary>
    /// 生成带logo的二维码
    /// </summary>
    /// <param name="info"></param>
    public void Generate3(string info)
    {
        BarcodeWriter bw = new BarcodeWriter();
        
    }

    public void Test(string text)
    {
        string path = "C:/Users/Recho/Pictures/Saved Pictures/test.png";
        Bitmap logo = new Bitmap(path);

        //构造写码器
        MultiFormatWriter writer = new MultiFormatWriter();
        Dictionary<EncodeHintType, object> hint = new Dictionary<EncodeHintType, object>();
        hint.Add(EncodeHintType.CHARACTER_SET, "UTF-8");
        hint.Add(EncodeHintType.ERROR_CORRECTION, ErrorCorrectionLevel.H);

        //生成二维码
        BitMatrix bm = writer.encode(text, BarcodeFormat.QR_CODE, 300, 300, hint);
        //BarcodeWriter<Bitmap> br = new BarcodeWriter<Bitmap>();
        BarcodeWriter br = new BarcodeWriter();
        Color32[] map = br.Write(bm);
        //Bitmap bitmap = new Bitmap();
        //map.Save("C:/Users/Recho/Pictures/Saved Pictures/test1.png");
    }
}
