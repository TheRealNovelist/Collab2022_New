using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossGunner : MonoBehaviour
{
    public IEnumerator Initialize()
    {
        yield return new WaitForSeconds(5f);
    }
    
    public void OnDeath()
    {
        
        gameObject.SetActive(false);
    }
}