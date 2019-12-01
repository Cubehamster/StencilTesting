using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalRenderTextureManager : MonoBehaviour
{
    public Camera cameraYLayer0;
  //  public Camera cameraYLayer1;

    public Camera cameraBLayer0;
    //  public Camera cameraBLayer1;

    public Material cameraMatYLayer0;
    //public Material cameraMatYLayer1;

    public Material cameraMatBLayer0;
   // public Material cameraMatBLayer1;

    // Start is called before the first frame update
    void Update()
    {
        if (cameraBLayer0.targetTexture != null)
        {
            cameraBLayer0.targetTexture.Release();
        }

        if (cameraYLayer0.targetTexture != null)
        {
            cameraYLayer0.targetTexture.Release();
        }

        //RenderTexture tempRTB = RenderTexture.GetTemporary(Screen.width, Screen.height, 4, RenderTextureFormat.ARGB64);
        //cameraMatYLayer0.mainTexture = tempRTB;
        //RenderTexture.ReleaseTemporary(tempRTB);

        cameraYLayer0.targetTexture = new RenderTexture(Screen.width, Screen.height, 4, RenderTextureFormat.ARGB64);
        cameraMatYLayer0.mainTexture = cameraYLayer0.targetTexture;
        cameraYLayer0.targetTexture.Release();

        //    if (cameraYLayer1.targetTexture != null)
        //     {
        //         cameraYLayer1.targetTexture.Release();
        //     }
        //     cameraYLayer1.targetTexture = new RenderTexture(Screen.width, Screen.height, 48, RenderTextureFormat.ARGBHalf);
        //     cameraMatYLayer1.mainTexture = cameraYLayer1.targetTexture;

        //RenderTexture tempRTY = RenderTexture.GetTemporary(Screen.width, Screen.height, 4, RenderTextureFormat.ARGB64);
        //cameraMatBLayer0.mainTexture = tempRTY;
        //RenderTexture.ReleaseTemporary(tempRTY);

        cameraBLayer0.targetTexture = new RenderTexture(Screen.width, Screen.height, 4, RenderTextureFormat.ARGB64);
        cameraMatBLayer0.mainTexture = cameraBLayer0.targetTexture;
        cameraBLayer0.targetTexture.Release();



        //     if (cameraBLayer1.targetTexture != null)
        //     {
        //          cameraBLayer1.targetTexture.Release();
        //     }
        //      cameraBLayer1.targetTexture = new RenderTexture(Screen.width, Screen.height, 48, RenderTextureFormat.ARGBHalf);
        //       cameraMatBLayer1.mainTexture = cameraBLayer1.targetTexture;
    }



}
