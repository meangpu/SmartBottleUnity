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


    [ContextMenu("Play drink")]
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

    [ContextMenu("Play levelUp")]
    public void PlayLevelupEffectPar()
    {
        FindObjectOfType<AudioManager>().playNotoverLap("levelUp");
        levelUpPar.Play();  
        
    }

    
    public void PlayDrinkEffectPar()
    {
        FindObjectOfType<AudioManager>().playNotoverLap("grow");
        drinkPar.Play();  
        // sound
    }


    
}
