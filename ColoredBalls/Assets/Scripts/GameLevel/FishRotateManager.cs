using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FishRotateManager : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="ball")
        {
            gameObject.transform.DORotate(transform.eulerAngles + Quaternion.AngleAxis(45, Vector3.forward).eulerAngles, 0.5f);

        }
    }
}
