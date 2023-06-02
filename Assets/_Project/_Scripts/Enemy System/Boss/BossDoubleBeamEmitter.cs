using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;

public class BossDoubleBeamEmitter : MonoBehaviour
{
    [Header("Weapons")] 
    [SerializeField] private BossBeamEmitter rightWeapon;
    [SerializeField] private BossBeamEmitter leftWeapon;
    
    [Header("Settings")]
    [SerializeField] private int spinAttackTurns = 3;
    [SerializeField] private float spinRate = 1f;
    [SerializeField] private float damage = 5f;

    float currentAngle = 0;

    public void StartSpinAttack()
    {
        currentAngle = 0;
        gameObject.SetActive(true);
    }
    
    public bool SpinAttack(bool isClockwise = true)
    {
        float totalAngle = spinAttackTurns * 360f;
        
        if (currentAngle < totalAngle)
        {
            transform.Rotate(0, isClockwise ? spinRate : -spinRate, 0);

            leftWeapon.Attack(damage);
            rightWeapon.Attack(damage);

            currentAngle += spinRate;
            return false;
        }
        
        return true;
    }

    public void EndSpinAttack()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
        
        leftWeapon.StopAttack();
        rightWeapon.StopAttack();
        
        gameObject.SetActive(false);
    }
}