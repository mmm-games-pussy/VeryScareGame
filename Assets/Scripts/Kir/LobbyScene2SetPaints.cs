using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbyScene2SetPaints : MonoBehaviour
{
    [SerializeField] private List<Image> _imageList;

    private void Start()
    {
        if (StaticInfo.CapturedImages.Count != 0)
        {
            foreach (Image image in _imageList)
            {
                int randomNum = Random.Range(0, StaticInfo.CapturedImages.Count);

                Texture2D texture2D = StaticInfo.CapturedImages[randomNum];
                StaticInfo.CapturedImages.Remove(texture2D);

                image.sprite = Sprite.Create(texture2D, new Rect(0.0f, 0.0f, texture2D.width, texture2D.height), new Vector2(0.5f, 0.5f), 100.0f);
            }
        }
    }
}