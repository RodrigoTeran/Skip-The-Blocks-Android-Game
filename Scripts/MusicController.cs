using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicController : MonoBehaviour
{ 
    public Image music;
    bool YesNoMusic = false;
    public Canvas canvas;

    public void ChangeMusic()
    {
        if (YesNoMusic == false)
        {
            music.sprite = Resources.Load<Sprite>("MusicSprites/m2");
            RectTransform rt = music.GetComponent<RectTransform>();
            rt.sizeDelta = new Vector2(30, 30);
            YesNoMusic = true;
            canvas.SendMessage("NoMusic");
        }
        else
        {
            music.sprite = Resources.Load<Sprite>("MusicSprites/m1");
            RectTransform rt = music.GetComponent<RectTransform>();
            rt.sizeDelta = new Vector2(25, 25);
            YesNoMusic = false;
            canvas.SendMessage("YesMusic");
        }
    }
}
