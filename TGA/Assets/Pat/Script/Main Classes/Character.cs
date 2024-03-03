using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float hp;
    private float HP;
    public float atk;
    public float def;
    public float atkSpeed;
    public float moveSpeed;
    public Rigidbody rb;
    public Animator anim;
    public AudioSource audioSource;

    private void Awake()
    {
        rb = this.GetComponent<Rigidbody>();
        anim = this.GetComponent<Animator>();
        audioSource = this.GetComponent<AudioSource>();
    }
    public virtual void TakeDamge() { }
    public virtual void Attack() { }
    public virtual void Attack(Skill skill){}
    public virtual void Block() { }
    public virtual void Move() { }
    public virtual void Die() { }


    public void PlaySound(string soundName)
    {
        AudioClip clip = Resources.Load<AudioClip>($"Audio/{soundName}");
        audioSource.clip = clip;
        audioSource.Play();
    }
    public void SetAnim(string name)
    {
        anim.SetTrigger(name);
    }
    public void SetAnim(string name, bool value)
    {
        anim.SetBool(name, value);
    }
    public void ResetAnim(string name)
    {
        anim.ResetTrigger(name);
    }
}
