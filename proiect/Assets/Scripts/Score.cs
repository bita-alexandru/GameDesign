using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    Text text;
    bool over = false;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();

        text.text = "HP: " + FindObjectOfType<Player>().GetComponent<Player>().hp.ToString()
                    + "\n" + "Score: " + FindObjectOfType<Player>().GetComponent<Player>().score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Restart();
        Quit();
    }

    public void UpdateText(int hp, int score)
    {
        text.text = "HP: " + hp.ToString() + "\n" + "Score: " + score.ToString();
    }

    public void GameOver(int score)
    {
        over = true;
        text.text = "Game over!\nPress R to restart...\n" + "Score: " + score.ToString();
    }

    void Restart()
    {
        if(over)
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("SampleScene");
            }
        }
    }

    void Quit()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
