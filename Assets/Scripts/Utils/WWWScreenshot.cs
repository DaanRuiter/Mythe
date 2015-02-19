using UnityEngine;
using System.Collections;

public class WWWScreenshot : MonoBehaviour
{

    // Grab a screen shot and upload it to a CGI script.
    // The CGI script must be able to hande form uploads.
    string screenShotURL = "http://localhost/cgi/screenshotUpload.php";
    // Take a screen shot immediately
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.F12))
        {
            StartCoroutine(UploadPNG());
        }
    }

    IEnumerator UploadPNG()
    {
        // We should only read the screen after all rendering is complete
        yield return new WaitForEndOfFrame();

        // Create a texture the size of the screen, RGB24 format
        int width = Screen.width;
        int height = Screen.height;
        Texture2D tex = new Texture2D(width, height, TextureFormat.RGB24, false);
        // Read screen contents into the texture

        tex.ReadPixels(new Rect(0, 0, width, height), 0, 0);
        tex.Apply();

        // Encode texture into PNG
        byte[] bytes = tex.EncodeToPNG();
        Destroy(tex);

        // Create a Web Form
        WWWForm form = new WWWForm();
        form.AddField("score", Time.frameCount.ToString());
        form.AddBinaryData("screenshot", bytes, "screenshot.png", "image/png");
        // Upload to a cgi script
        WWW w = new WWW(screenShotURL, form);
        yield return w;
        if (!string.IsNullOrEmpty(w.error))
        {
            print(w.error);
        }
        else
        {
            print(w.text);
        }
    }
}
