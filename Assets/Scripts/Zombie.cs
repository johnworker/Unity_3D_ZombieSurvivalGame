using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    [Header("SFX")]
    [SerializeField] AudioClip zombieRunSound;
    [SerializeField] AudioClip zombieAttackSound;
    [SerializeField] AudioClip zombieScreamSound;
    [SerializeField] AudioClip[] zombieGrowlSound;

    private Animator _animator;
    private AudioSource _audioSource1, _audioSource2;
    private int randSound = 0;
    private bool isBorn = false;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        AudioSource[] audioSources = GetComponents<AudioSource>();
        foreach (AudioSource audioSource in audioSources)
        {
            if (audioSource.priority == 128)
            {
                _audioSource1 = audioSource;
            }
            if (audioSource.priority == 100)
            {
                _audioSource2 = audioSource;
            }
        }
        Run();
        randSound = Random.Range(0, zombieGrowlSound.Length);
        _audioSource2.clip = zombieScreamSound;
        _audioSource2.Play();
        Invoke("CheckIsBorn", zombieScreamSound.length);
    }

    private void CheckIsBorn()
    {
        isBorn = true;
        Debug.Log("Check is born");
        if (isBorn)
        {
            Growl(randSound);
        }
    }

    private void Growl(int rand)
    {
        _audioSource2.clip = zombieGrowlSound[rand];
        _audioSource2.volume = 1f;
        _audioSource2.Play();
        _audioSource2.loop = true;
    }

    private void Run()
    {
        _animator.SetBool("IsRunning", true);
        _audioSource1.clip = zombieRunSound;
        _audioSource1.Play();
        _audioSource1.loop = true;
    }

    private void Attack()
    {
        _animator.SetTrigger("Attack");
        _audioSource2.clip = zombieAttackSound;
        _audioSource2.volume = 0.35f;
        if (!_audioSource2.isPlaying)
        {
            _audioSource2.Play();
            _audioSource2.loop = true;
        }
    }

    //private void OnCollisionEnter(Collision collider)
    //{
    //    if (collider.gameObject.GetComponent<Player>())
    //    {
    //        Attack();
    //    }
    //}

    private void OnCollisionStay(Collision collider)
    {
        if (collider.gameObject.GetComponent<Player>())
        {
            Attack();
        }
    }

    private void OnCollisionExit(Collision collider)
    {
        if (collider.gameObject.GetComponent<Player>())
        {
            Run();
            Growl(randSound);
        }
    }
}
