using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Collections;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Collect : MonoBehaviour
{
    public GameManager gameManager;
    public PlayerControl playerControl;
    private void Awake()
    {
        transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material.color= Color.red;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Collect")
        {
            if (!playerControl.collect)
            {
                //playerControl.stacklist.Add(other.gameObject);
                //playerControl.score++;
                Destroy(other.gameObject);
                Debug.Log(playerControl.score);
            }
            else
            {
                return;
            }
        }
        else if (other.tag == "Obstacle")
        {
            gameManager.lose();
        }
        else if (other.tag == "Finish")
        {
            gameManager.Win();
        }
    }
}
