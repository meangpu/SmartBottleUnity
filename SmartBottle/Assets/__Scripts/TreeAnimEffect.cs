using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class TreeAnimEffect : MonoBehaviour
{
    [SerializeField] Transform parentTreeTran;
    [SerializeField] Ease easeType;
    [SerializeField] ParticleSystem drinkPar;
    [SerializeField] ParticleSystem levelUpPar;


    public void DoDrinkAnim()
    {
        var sequence = DOTween.Sequence();
        sequence.Append(parentTreeTran.DOScale(new Vector3(1.2f, 1.2f, 1.2f), 0.75f).SetEase(easeType));
        sequence.Append(parentTreeTran.DOScale(new Vector3(1f, 1f, 1f), 0.35f).SetEase(easeType));
        
        sequence.OnComplete(() => 
        {
            PlayDrinkEffectPar();
        });

    }

    public void PlayLevelupEffectPar()
    {
        levelUpPar.Play();  
    }

    public void PlayDrinkEffectPar()
    {
        drinkPar.Play();  
        // sound
    }


    
}
