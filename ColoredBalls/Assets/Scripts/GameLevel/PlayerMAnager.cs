using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMAnager : MonoBehaviour
{
    [SerializeField]
    private Transform gun;

    float angle;
    float donrotationSpeed= 5f;


    [SerializeField]
    private GameObject[] ballPrefab;

    [SerializeField]
    private Transform ballPosition;

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip ballClick;


    public bool changeRoute;

    float standbyTime = 300f; // iki mermi arasý bekleme süresi
    float nextShot; // sonraki atýþ
    private void Start()
    {
        changeRoute = false;
    }
    void Update()
    {

        if (changeRoute)
        {
            RotateChange();
        }
    }

    void RotateChange()
    {

        Vector2 diretiton = Camera.main.ScreenToWorldPoint(Input.mousePosition) - gun.transform.position;

        angle = Mathf.Atan2(diretiton.y, diretiton.x) * Mathf.Rad2Deg - 90;
        //atan =direk içeriye verdiðin deðeri açýya çevirir atan2= 2 deðer alýr burdan çýkan ölçü radyandýr. Rad2Deg radyaný dereceye dönüþtürür.

        if (angle<45 && angle>-40)
        {
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            gun.transform.rotation = Quaternion.Slerp(gun.transform.rotation, rotation, donrotationSpeed * Time.deltaTime);

            //sert dönmesini istemioyruz o yüzden Slerp kullandýk.
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (Time.time>nextShot)
            {
                nextShot = Time.time + standbyTime / 1000;
                BallThrow();
            }

        }
    }

    void BallThrow()
    {
        if (PlayerPrefs.GetInt("soundStatus") == 1)
        {
            audioSource.PlayOneShot(ballClick);
        }

        GameObject ball = Instantiate(ballPrefab[Random.Range(0,ballPrefab.Length)],ballPosition.position,ballPosition.rotation) as GameObject;
        
    } 
}