using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


[System.Serializable]
public class MeangpuTree
{
    
    public GameObject treePref;
    public string treeWord;
    // public int waterLevel;

}


public class TreeManager : MonoBehaviour
{
    [SerializeField] MeangpuTree[] MeangpuTrees;
    [SerializeField] Slider valSlider;
    [SerializeField] TMP_Text treeWordText;
    [SerializeField] TreeAnimEffect animScpt;
    bool firsttime = true;


    public void SetTreePref(int waterLevel)
    {

        if(waterLevel < 2)  // water 0 is water full 
        {
            turnOnOnePref(MeangpuTrees[0]);
        }
        else if(waterLevel < 5)
        {
            turnOnOnePref(MeangpuTrees[1]);
        }
        else if(waterLevel < 10)
        {
            turnOnOnePref(MeangpuTrees[2]);
        }
        else if(waterLevel < 18)
        {
            turnOnOnePref(MeangpuTrees[3]);
        }
        else if(waterLevel <= 20)  // water empty distance max 20
        {
            turnOnOnePref(MeangpuTrees[4]);
            if(!firsttime)
            {
                return;
            }

            animScpt.PlayLevelupEffectPar();
            firsttime = false;
        }

    }

    void turnOnOnePref(MeangpuTree _onPref)
    {
        foreach (MeangpuTree tree in MeangpuTrees)
        {
            tree.treePref.SetActive(false);
        }
        _onPref.treePref.SetActive(true);
        treeWordText.SetText(_onPref.treeWord);
    }

}
