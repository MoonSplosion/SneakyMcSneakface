using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject TitleBackgroundImage;
    public GameObject TitleText;
    public GameObject GameStartButton;
    public GameObject Player;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);}

        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        TitleBackgroundImage.SetActive(false);
        TitleText.SetActive(false);
        GameStartButton.SetActive(false);
    }
}
