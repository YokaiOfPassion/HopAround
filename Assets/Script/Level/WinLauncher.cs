using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLauncher : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerAnimatorManager.instance.gameObject.SetActive(false);
            LVLManager.instance.Win();
        }
    }
}
