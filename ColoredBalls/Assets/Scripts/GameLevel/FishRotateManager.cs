using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class FishRotateManager : MonoBehaviour
{
    string whichResult;

    GameManager gameManager;
    private void Awake()
    {
        gameManager=Object.FindObjectOfType<GameManager>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="ball")
        {
            gameObject.transform.DORotate(transform.eulerAngles + Quaternion.AngleAxis(45, Vector3.forward).eulerAngles, 0.5f);

            if (collision.gameObject!=null)
            {
                Destroy(collision.gameObject);
            }

            if (gameObject.name== "fish_purple")
            {
                whichResult = GameObject.Find("fish_purple_Text").GetComponent<Text>().text;
            }
            else if (gameObject.name == "fish_blue")
            {
                whichResult = GameObject.Find("fish_blue_Text").GetComponent<Text>().text;
            }
            else if (gameObject.name == "fish_green")
            {
                whichResult = GameObject.Find("fish_green_Text").GetComponent<Text>().text;
            }


            gameManager.CheckResult(int.Parse(whichResult)); //parse string deðeri int çevirdik.
        }
    }
}
