using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public UI_Control control;
    public Animator[] anima;
    public GameObject[] panels;
    public void lose()
    {
        control.gameStart = false;
        anima[0].SetBool("Move", false);
        anima[1].SetBool("Move", false);
        panels[0].SetActive(true);
    }
    public void Win()
    {
        control.gameStart = false;
        anima[0].SetBool("Move", false);
        anima[1].SetBool("Move", false);
        panels[1].SetActive(true);
    }
    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
