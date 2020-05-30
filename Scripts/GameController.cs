using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour{
    public GameObject uiIdle;
    public Button startButtonUI;
    public Button musciButton;
    public Button skinsButton;

    public GameObject player;
    public GameObject _player;
    public GameObject enemy;

    public Text scoreDown;                                          // score
    public GameObject ScoreCont;
    public Text Score;                                                    // score

    public GameObject DieScreen;
    public GameObject PlayScreen;

    public Text title;
    public Text info;                                               // score
    public Text touch;

    public AudioSource musicPlayer;
    public AudioSource musicDie;
    public AudioSource coin;

    public Image _music;

    public float velocidadFade = 1.5f;
    private float alpha = 1.0f;

    bool music = true;

    void Start(){
        info.text = "High score: " + GetMaxScore().ToString();
        int skin = GetSkin();
        if (skin == 1)
        {
            _player.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("PlayerSprites/player");
        }
        if (skin==2)
        {
            _player.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("PlayerSprites/player2");
        }
        if (skin==3)
        {
            _player.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("PlayerSprites/player3");
        }
        if (skin==4)
        {
            _player.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("PlayerSprites/player4");
        }
        int mus = GetMusicState();
        if (mus == 1)
        {
            music = true;
            musicPlayer.Play();
            _music.sprite = Resources.Load<Sprite>("MusicSprites/m1");
        }
        else
        {
            music = false;
            _music.sprite = Resources.Load<Sprite>("MusicSprites/m2");
        }
    }

    bool Fade = true;
    bool YesFade = false;

    public void StartButton()
    {
        YesFade = true;
    }

    public void ACoin()
    {
        if (music)
        {
            coin.Play();
        }
    }
    int scores = 0;
    public void EndGame()
    {
        player.SendMessage("EndGame");
        scores = player.GetComponent<PlayerController>().scores;
        SaveScore();
        SaveSkin();
        SaveMusicState();
        Score.text = scoreDown.text;
        ScoreCont.SetActive(false);
        musicPlayer.Stop();
        PlayScreen.SetActive(false);
        DieScreen.SetActive(true);
        if (music)
        {
            musicDie.Play();
        }
    }

    void Update(){
        if (YesFade)
        {
            StartFade();
        }
    }

    public void NoMusic(){
        musicPlayer.Stop();
        music = false;
    }

    public void YesMusic()
    {
        musicPlayer.Play();
        music = true;

    }

    public void StartFade()
    {
        if (Fade)
        {
            player.SendMessage("ReallyStart");
            ScoreCont.SetActive(true);

            title.color = new Color(0, 0, 0, alpha);
            info.color = new Color(0, 0, 0, alpha);
            touch.color = new Color(0, 0, 0, alpha);
            alpha -= velocidadFade * Time.deltaTime;
            skinsButton.gameObject.SetActive(false);
            musciButton.gameObject.SetActive(false);
            if (alpha <= 0)
            {
                uiIdle.SetActive(false);
                startButtonUI.gameObject.SetActive(false);
                Fade = false;
                enemy.SendMessage("StartMoving");
            }
        }
    }

    public int GetMaxScore()
    {
        return PlayerPrefs.GetInt("Max Points", 0);
    }

    public void SaveScore()
    {
        if(GetMaxScore() < scores)
        {
            PlayerPrefs.SetInt("Max Points", scores);
        }
    }

    public int GetMusicState()
    {
        return PlayerPrefs.GetInt("Music", 1);
    }

    public void SaveMusicState()
    {
        if (music)
        {
            PlayerPrefs.SetInt("Music", 1);
        }
        else
        {
            PlayerPrefs.SetInt("Music", 0);
        }
    }

    public int GetSkin()
    {
        return PlayerPrefs.GetInt("Skins", 1);
    }

    public void SaveSkin()
    {
        if(_player.GetComponent<SpriteRenderer>().sprite == Resources.Load<Sprite>("PlayerSprites/player"))
        {
            PlayerPrefs.SetInt("Skins", 1);
        }
        if (_player.GetComponent<SpriteRenderer>().sprite == Resources.Load<Sprite>("PlayerSprites/player2"))
        {
            PlayerPrefs.SetInt("Skins", 2);
        }
        if (_player.GetComponent<SpriteRenderer>().sprite == Resources.Load<Sprite>("PlayerSprites/player3"))
        {
            PlayerPrefs.SetInt("Skins", 3);
        }
        if (_player.GetComponent<SpriteRenderer>().sprite == Resources.Load<Sprite>("PlayerSprites/player4"))
        {
            PlayerPrefs.SetInt("Skins", 4);
        }
    }
}
 