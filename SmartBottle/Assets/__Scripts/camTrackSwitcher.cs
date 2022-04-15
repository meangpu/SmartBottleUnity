using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TrackAndPref
{
    public Cinemachine.CinemachineSmoothPath path;
    public Transform targetPrefab;
}


public class camTrackSwitcher : MonoBehaviour
{
    [SerializeField] Cinemachine.CinemachineDollyCart cart;
    [SerializeField] Cinemachine.CinemachineVirtualCamera virCam;
    public Cinemachine.CinemachineSmoothPath startPath;
    public TrackAndPref[] alterPath;

    int _previousNum;

    void Start()
    {
        DoReset();
    }

    void DoReset()
    {
        StopAllCoroutines();
        cart.m_Path = startPath;
        StartCoroutine(ChangeTrack());
    }

    IEnumerator ChangeTrack()
    {
        yield return new WaitForSeconds(Random.Range(7, 9));
        cart.m_Position = Random.Range(0, 0.4f);
        cart.m_Speed = Random.Range(.05f, .11f);


        var path = alterPath[getNotOldNum()];

        cart.m_Path = path.path;
        virCam.LookAt = path.targetPrefab;
        StartCoroutine(ChangeTrack());

    }

    int getNotOldNum()
    {
        
        int newIndex = Random.Range(0, alterPath.Length);

        while (newIndex == _previousNum)
        {
            newIndex = Random.Range(0, alterPath.Length);
        }

        _previousNum = newIndex;

        return newIndex;


    }


}
