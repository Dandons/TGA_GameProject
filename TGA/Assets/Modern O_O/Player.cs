using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    public float maxSta;
    public float sta;
    public float staRegenRate;
    private void Start()
    {
        sta = maxSta;
    }
    public void move()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.velocity += Vector3.forward * moveSpeed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.velocity += Vector3.back * moveSpeed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity += Vector3.right * moveSpeed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity += Vector3.left * moveSpeed;
        }
    }
    public void UseStamina(float stamina)
    {
        if (sta > 0)
        {
            sta -= stamina;
            Debug.Log(sta);
        }
        if (sta <= 0)
        {
            Debug.Log("run out of stamina!");
        }
    }
    public void RegenarateSataminaISuppose()
    {
        sta += maxSta * staRegenRate;
        Debug.Log(sta);
        if (sta > maxSta)
        {
            sta = maxSta;
        }
    }
    public void RegenarateSatamina()
    {
        while (sta != maxSta)
        {
            Invoke("RegenarateSataminaISuppose", 5f);
        }
    }
    private void Update()
    {
        move();
        if (Input.GetKeyDown(KeyCode.P))
        {
            UseStamina(10);
        }
        RegenarateSatamina();
    }
}
