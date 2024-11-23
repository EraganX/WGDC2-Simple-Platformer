using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_01 : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            GameManager.Instance.GoToLevel2();
        }
    }
}
