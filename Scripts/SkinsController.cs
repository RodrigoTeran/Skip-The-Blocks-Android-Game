using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinsController : MonoBehaviour
{
    public GameObject Dark;
    public GameObject Menu;
    public GameObject player;

    public void ShowSkins()
    {
        Menu.SetActive(true);
        Dark.SetActive(true);

    }

    public void NoShowSkins()
    {
        Menu.SetActive(false);
        Dark.SetActive(false);

    }

    public void ChangeSkin(int color = 1)
    {
        if(color == 1)
        {
            player.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("PlayerSprites/player");
        }
        if (color == 2)
        {
            player.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("PlayerSprites/player2");
        }
        if (color == 3)
        {
            player.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("PlayerSprites/player3");
        }
        if (color == 4)
        {
            player.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("PlayerSprites/player4");
        }

    }
}

