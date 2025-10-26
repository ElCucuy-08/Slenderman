using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    public float HP = 100;
    public float MaxHP = 100;
    public  Image Bar;

    private void Start()
    {
        Bar= GetComponent<Image>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            HP -= 10;
            Bar.fillAmount = HP / 100f;
        }
    }
}
