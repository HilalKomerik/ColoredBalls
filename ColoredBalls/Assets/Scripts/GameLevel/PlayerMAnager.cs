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
    void Update()
    {
        RotateChange();
    }

    void RotateChange()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 diretiton = Camera.main.ScreenToWorldPoint(Input.mousePosition) - gun.transform.position;

            angle = Mathf.Atan2(diretiton.y, diretiton.x) * Mathf.Rad2Deg - 90;
            //atan =direk i�eriye verdi�in de�eri a��ya �evirir atan2= 2 de�er al�r burdan ��kan �l�� radyand�r. Rad2Deg radyan� dereceye d�n��t�r�r.

            BallThrow();
        }
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        gun.transform.rotation = Quaternion.Slerp(gun.transform.rotation, rotation, donrotationSpeed * Time.deltaTime);

        //sert d�nmesini istemioyruz o y�zden Slerp kulland�k.
    }

    void BallThrow()
    {
        GameObject ball = Instantiate(ballPrefab[Random.Range(0,ballPrefab.Length)],ballPosition.position,ballPosition.rotation) as GameObject;
    } 
}