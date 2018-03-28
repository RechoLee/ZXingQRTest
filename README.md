# 开源的ZXing二维码解决方案
> ZXing for Net
* [codeplex](https://archive.codeplex.com/?p=zxingnet)
* [github](https://github.com/micjahn/ZXing.Net)
* [草料二维码生成网址](https://cli.im/)
* **Blog上的文章**
 * [天马3798](http://www.cnblogs.com/tianma3798/p/5426869.html)

## Start
> 记录学习内容

## 代码部分
**生成的代码部分**
> 注意事项
* 这里需要注意使用BarcodeWriter的Write的方法只能设置大小为256x256

### 生成二维码的方法
#### Generate.cs文件中
```C#
	///生成二维码的方法，使用unity开发的
    public void Generate(string info)
    {
        BarcodeWriter bw = new BarcodeWriter();
        bw.Format = BarcodeFormat.QR_CODE;
        //需要引入QrCode命名空间
        QrCodeEncodingOptions options = new QrCodeEncodingOptions
        {
            //设置optinos
            DisableECI = true,
            //这里需要注意使用BarcodeWriter的Write的方法只能设置大小为256x256
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
    }
```
##### 生成条形码
```C#
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
            Options = myOptions
        };

        //
        Color32[] code = bw.Write(info);
        Texture2D texture = new Texture2D(256,128);
        texture.SetPixels32(code);
        texture.Apply();
        codeImage.texture = texture;
    }
```


