using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Capture : MonoBehaviour
{
    [Header("Photo Taker")]
    [SerializeField] private Image photoDisplay;
    [SerializeField] private GameObject PhotoFrame;
    [SerializeField] private GameObject photoPrefab; // Prefab for the photo game object
    [SerializeField] private Transform photoContainer; // Container to store photo game objects

    [Header("Flash Effect")]
    [SerializeField] private GameObject cameraFlash;
    [SerializeField] private float flashTime;

    [Header("Photo Fader Effect")]
    [SerializeField] private Animator fadingAnimation;

    [Header("Player Disable")]
    [SerializeField] private GameObject player;

    private bool viewingPhoto;
    private bool isPlayerActive = true;

    private void Start()
    {
        // Initialization if needed
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!viewingPhoto)
            {
                StartCoroutine(CapturePhoto());
            }
            else
            {
                RemovePhoto();
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            TogglePlayer();
        }
    }

    void TogglePlayer()
    {
        isPlayerActive = !isPlayerActive;
        player.SetActive(isPlayerActive);
    }

    IEnumerator CapturePhoto()
    {
        viewingPhoto = true;
        yield return new WaitForEndOfFrame();

        Texture2D screenCapture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);

        StartCoroutine(CameraFlashEffect());

        Rect regionToRead = new Rect(0, 0, Screen.width, Screen.height);
        screenCapture.ReadPixels(regionToRead, 0, 0, false);
        screenCapture.Apply();
        ShowPhoto(screenCapture);
    }

    IEnumerator CameraFlashEffect()
    {
        cameraFlash.SetActive(true);
        yield return new WaitForSeconds(flashTime);
        cameraFlash.SetActive(false);
    }

    void ShowPhoto(Texture2D screenCapture)
    {
        Sprite photoSprite = Sprite.Create(screenCapture, new Rect(0.0f, 0.0f, screenCapture.width, screenCapture.height), new Vector2(.5f, .5f), 100.0f);

        photoDisplay.sprite = photoSprite;

        PhotoFrame.SetActive(true);
        fadingAnimation.Play("PhotoFade");

        SavePhotoAsGameObject(photoSprite);
    }

    void SavePhotoAsGameObject(Sprite photoSprite)
    {
        GameObject newPhoto = Instantiate(photoPrefab, photoContainer); // Instantiate new photo in the photo container
        newPhoto.GetComponent<Image>().sprite = photoSprite;
        // Optionally set position and other properties of the new photo game object here
    }

    void RemovePhoto()
    {
        viewingPhoto = false;
        PhotoFrame.SetActive(false);
    }
}
