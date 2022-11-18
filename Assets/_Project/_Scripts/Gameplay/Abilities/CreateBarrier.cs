using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Barrier", menuName = "Ability/Barrier")]
public class CreateBarrier : SkillSystem
{
    public GameObject shieldPrefab;
    public GameObject shieldHolder;
    //public Barrier barrier;
    public override void Activate(GameObject parent)
    {
        GameObject newShield = Instantiate(shieldPrefab, parent.transform.position, Quaternion.identity);
        Debug.Log("Barrier Initialised");
        //shieldHolder.SetActive(true);
    }

    public override void BeginCooldown(GameObject parent)
    {
        base.BeginCooldown(parent);
    }
}