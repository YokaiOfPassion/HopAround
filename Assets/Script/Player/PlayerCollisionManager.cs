using System;
using System.Collections;
using UnityEngine;

public class PlayerCollisionManager : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Transform lastCheckpointPos;
    private Vector3 spawnPoint;
    
    [SerializeField] private AudioClip frogDeath;
    [SerializeField] private AudioClip frogContact;
    [SerializeField] private AudioClip checkpoint;
    

    private void Start()
    {
        spawnPoint = player.transform.position;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
       
        if (other.gameObject.CompareTag("FallZone"))
        {
            SoundManager.instance.PlaySound(frogDeath);
            PlayerAnimatorManager.instance.AnimatorStateChange(4);
            player.enabled = false;
            StartCoroutine(WaitForDeath());

        }
        else if (other.gameObject.layer == 6)
        {
            SoundManager.instance.PlaySound(frogContact);
            player.isJumping = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("CheckPoint"))
        {
            SoundManager.instance.PlaySound(checkpoint);
            lastCheckpointPos = other.gameObject.transform;
            other.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            other.gameObject.GetComponentInChildren<Animator>().SetBool("Go",true);
        }
    }

    public IEnumerator PlayerRestart()
    {
        yield return new WaitForSeconds(1.4f);
        player.enabled = true;
        PlayerAnimatorManager.instance.AnimatorStateChange(0);
        if (lastCheckpointPos != null)
        {
            player.transform.position = lastCheckpointPos.position;
        }
        else
        {
            player.transform.position = spawnPoint;
        }

    }

    private IEnumerator WaitForDeath()
    {
        yield return new WaitForSeconds(1.4f);
        player.enabled = true;
        if (lastCheckpointPos)
        {
            player.transform.position = lastCheckpointPos.position;
        }
        else
        {
            player.transform.position = spawnPoint;
        }
    }
}
