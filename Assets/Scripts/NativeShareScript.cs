using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class NativeShareScript : MonoBehaviour {

    public void ShareBtnPress()
    {
        StartCoroutine(ShareScreenshot());
    }

    IEnumerator ShareScreenshot()
    {
        yield return new WaitForEndOfFrame();

        Texture2D ss = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        ss.ReadPixels(new Rect (0, 0, Screen.width, Screen.height), 0, 0);
        ss.Apply();

        string filePath = Path.Combine(Application.temporaryCachePath, "shared img.png");
        File.WriteAllBytes(filePath, ss.EncodeToPNG());

        Destroy(ss);
        new NativeShare().AddFile(filePath).SetSubject("Jump Yeah")
            .SetText("Consegui " + GameManager.score + " pontos! E tu?").Share();
    }

    private void OnApplicationFocus(bool focus)
    {

    }
}