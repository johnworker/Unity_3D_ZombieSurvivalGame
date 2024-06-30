using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearArea : MonoBehaviour
{
    [SerializeField] private float timeTrigger = 0f;
    private Player _player;
    private bool areaFound = true;

    // Start is called before the first frame update
    void Start()
    {
        _player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        timeTrigger += Time.deltaTime;
        
    }

    private void OnTriggerStay(Collider other)
    {
        //SendMessageUpwards("OnFindClearArea"); // sends message or check for function upwards in parent objects in hierarchy
        if (timeTrigger > 3f && other.GetComponent<Player>())
        {
            if (areaFound)
            {
                areaFound = false;
                other.GetComponent<Player>().PlayGoodAreaSound();
            }
            _player.OnFindClearArea();
        }
        if (other.GetComponent<Zombie>())
        {
            Debug.Log("There are zombies in area");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            timeTrigger = 0f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            timeTrigger = 0f;
        }
    }
}
