using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Capture : MonoBehaviour
{

    [Header("Photo Taker")]
    [SerializeField]private Image photoDisplay;
    [SerializeField]private GameObject PhotoFrame;

    [Header("Flash Effect")]

    [SerializeField] private GameObject cameraFlash;
    [SerializeField] private float flashTime;

    [Header("Photo Fader Effect")]
    [SerializeField] private Animator fadingAnimation;

    [Header("Player Disable")]
    [SerializeField] private GameObject player;



    private Texture2D screenCapture;
    private bool viewingPhoto;
    private bool isPlayerActive = true;


    private void Start()
    {

        screenCapture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);

    }

    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {


            if (!viewingPhoto)
            {

                StartCoroutine(capturePhoto());


            }else
            {

                RemovePhoto();
            }
        

        }

        if (Input.GetMouseButtonDown(1)) {

           TogglePlayer();


        }


    }

    void TogglePlayer() {


        isPlayerActive = !isPlayerActive;
        player.SetActive(isPlayerActive);

    }

    IEnumerator capturePhoto()
    {

        viewingPhoto = true;
    
        yield return new WaitForEndOfFrame();

        Rect regionToRead = new Rect(0, 0, Screen.width, Screen.height);

        StartCoroutine(CameraFlashEffect());
       
        screenCapture.ReadPixels(regionToRead, 0, 0, false);
        screenCapture.Apply();
        ShowPhoto();
    
    
    }

    IEnumerator CameraFlashEffect() {
    
        cameraFlash.SetActive(true);
        yield return new WaitForSeconds(flashTime);
        cameraFlash.SetActive(false);
    
    
    }

    void ShowPhoto() {

        Sprite photoSprite = Sprite.Create(screenCapture, new Rect(0.0f, 0.0f, screenCapture.width, screenCapture.height), new Vector2(.5f, .5f), 100.0f);

        photoDisplay.sprite = photoSprite;
    
        PhotoFrame.SetActive(true);
        fadingAnimation.Play("PhotoFade");
    }

    void RemovePhoto() {
    
        viewingPhoto = false;
        PhotoFrame.SetActive(false);

    
    
    }
}
