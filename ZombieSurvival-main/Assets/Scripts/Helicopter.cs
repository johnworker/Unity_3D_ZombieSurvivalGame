using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helicopter : MonoBehaviour
{
    [SerializeField] private AudioClip callSound;
    [SerializeField] float flySpeed = 50f;
    private bool heliCalled = false;
    private bool heloStoped = false;
    public bool heloLanded = false;
    private AudioSource _audioSource;
    private Rigidbody _rigidbody;
    private ClearArea _clearArea;

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _rigidbody = GetComponent<Rigidbody>();
        _clearArea = FindObjectOfType<ClearArea>();
    }

    private void FixedUpdate()
    {
        if (transform.position.z >= _clearArea.transform.position.z && !heloStoped)
        {
            _rigidbody.velocity = Vector3.zero;
            heloStoped = true;
        }
        else if (transform.position.y >= _clearArea.transform.position.y && heloStoped && !heloLanded)
        {
            _rigidbody.velocity = new Vector3(0, -25f, 0);
            heloLanded = true;
        }
        else if (transform.position.y <= _clearArea.transform.position.y && heloLanded)
        {
            _rigidbody.velocity = Vector3.zero;
            transform.position = _clearArea.transform.position;
        }
    }

    public void Call()
    {
        if (!heliCalled)
        {
            heliCalled = true;
            _audioSource.clip = callSound;
            _audioSource.Play();
            _rigidbody.velocity = new Vector3(0, 0, flySpeed);
        }
    }
}
