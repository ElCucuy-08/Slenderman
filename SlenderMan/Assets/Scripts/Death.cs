using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    public GameObject cam1;
    public HpBar hp;

    private void Start()
    {
       
    }
    private void Update()
    {
        if(hp.Health<=0)
        {
            cam1.SetActive(false);
        }
    }
}
