using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float hp;
    public float atk;
    public float def;
    public float atkSpeed;
    public float moveSpeed;
    protected Rigidbody rb;
    protected Animator anim;
    protected AudioSource audioSource;

    private void Awake()
    {
        rb = this.GetComponent<Rigidbody>();
        anim = this.GetComponent<Animator>();
        audioSource = this.GetComponent<AudioSource>();
    }
    public virtual void Attack(Skill skill) { }
    public virtual void Block() { }
    public virtual void Move() { }
    public virtual void Die() { }
    public void PlaySound(string soundName)
    {
        AudioClip clip = Resources.Load<AudioClip>($"Audio/{soundName}");
        audioSource.clip = clip;
        audioSource.Play();
    }
}
