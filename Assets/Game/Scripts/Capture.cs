using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Capture : MonoBehaviour
{

    [Header("Photo Taker")]
    [SerializeField]private Image photoDisplay;


    private Texture2D screenCapture;


    private void Start()
    {

        screenCapture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);

    }

    private void Update()
    {

        if (Input.GetMouseButtonDown(0)) {
        

        
        }


    }

    IEnumerator capturePhoto()
    {
    
        yield return new WaitForEndOfFrame();

        Rect regionToRead = new Rect(0, 0, Screen.width, Screen.height);

        screenCapture.ReadPixels(regionToRead, 0, 0, false);
        screenCapture.Apply();
        ShowPhoto();
    
    
    }

    void ShowPhoto() {

        Sprite photoSprite = Sprite.Create(screenCapture, new Rect(0.0f, 0.0f, screenCapture.width, screenCapture.height), new Vector2(.5f, .5f), 100.0f);

        photoDisplay.sprite = photoSprite;
    
    
    }
}
