using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LiveParticle : MonoBehaviour
{
    [Header("GameObjects")]
    [SerializeField] private GameObject livePanel;
    [SerializeField] private GameObject heart;
    [SerializeField] private GameObject like;
    [SerializeField] private GameObject smile;

    [Header("Images")]
    [SerializeField] private Image heartImage;
    [SerializeField] private Image likeImage;
    [SerializeField] private Image smileImage;

    [Header("SpritesOn")]
    [SerializeField] private Sprite heartSpriteOn;
    [SerializeField] private Sprite likeSpriteOn;
    [SerializeField] private Sprite smileSpriteOn;

    [Header("SpritesOff")]
    [SerializeField] private Sprite heartSpriteOff;
    [SerializeField] private Sprite likeSpriteOff;
    [SerializeField] private Sprite smileSpriteOff;



    private void Update()
    {
        if (livePanel.activeInHierarchy == false)
        {
            heart.SetActive(false);
            like.SetActive(false);
            smile.SetActive(false);
        }
    }

    public void HeartParticle()
    {
        if (heart.activeInHierarchy == false)
        {
            heartImage.sprite = heartSpriteOn;
            heart.SetActive(true);
        }
        else
        {
            heartImage.sprite = heartSpriteOff;
            heart.SetActive(false);
        }
    }

    public void LikeParticle()
    {
        if (like.activeInHierarchy == false)
        {
            likeImage.sprite = likeSpriteOn;
            like.SetActive(true);
        }
        else
        {
            likeImage.sprite = likeSpriteOff;
            like.SetActive(false);
        }
    }

    public void SmileParticle()
    {
        if (smile.activeInHierarchy == false)
        {
            smileImage.sprite = smileSpriteOn;
            smile.SetActive(true);
        }
        else
        {
            smileImage.sprite = smileSpriteOff;
            smile.SetActive(false);
        }
    }
}
