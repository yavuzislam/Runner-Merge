using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public TextMeshProUGUI text;
    public Animator[] anim;
    public GameObject player;
    public bool set, collect,finish;
    public int score = 0;
    public List<GameObject> stacklist;
    Vector3 scale;
    public UI_Control control;
    public float moveSpeed;
    public GameManager gameManager;
    private void Update()
    {
        if (control.gameStart)
        {
            transform.position += Vector3.forward * moveSpeed * Time.deltaTime;
            player.transform.position += Vector3.forward * moveSpeed * Time.deltaTime;
            anim[0].SetBool("Move", true);
            anim[1].SetBool("Move", true);
            if (!set)
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(-3f, transform.position.y, transform.position.z), 1.5f * Time.deltaTime);
                player.transform.position = Vector3.Lerp(player.transform.position, new Vector3(3f, player.transform.position.y, player.transform.position.z), 1.5f * Time.deltaTime);
            }
        }
        if (finish)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(0f, transform.position.y, transform.position.z), 1.5f * Time.deltaTime);
            player.transform.position = Vector3.Lerp(player.transform.position, new Vector3(0f, player.transform.position.y, player.transform.position.z), 1.5f * Time.deltaTime);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "brother")
        {
            other.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().enabled = false;
            transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material.color = Color.black;
            collect = true;
            scale = transform.localScale;
            transform.position = new Vector3(0, transform.position.y, transform.position.z);
            other.transform.position = new Vector3(0, other.transform.position.y, other.transform.position.z);
            set = true;
            if (stacklist.Count != 0)
            {
                transform.localScale = transform.localScale + new Vector3(0.1f, 0.1f, 0.1f) * stacklist.Count;
            }
            else
            {
                return;
            }
            
        }
        else if (other.tag == "Collect")
        {
            if (!collect)
            {
                stacklist.Add(other.gameObject);
                text.text = stacklist.Count.ToString();
                score++;
                Destroy(other.gameObject);
                Debug.Log(score);
            }
            else
            {
                return;
            }
        }
        else if (other.tag=="Obstacle")
        {
            gameManager.lose();
        }
        else if (other.tag == "Finish")
        {
            gameManager.Win();
            finish= true;
            anim[0].SetBool("dance", true);
            anim[1].SetBool("dance", true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "brother")
        {
            collect = false;
            other.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().enabled = true;
            transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material.color = Color.green;
            transform.localScale = scale;
            set = false;
        }
    }
}
