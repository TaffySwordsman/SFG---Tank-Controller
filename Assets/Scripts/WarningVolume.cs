using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningVolume : MonoBehaviour
{
    Material warningMat;
    [SerializeField] float delayTime, fadeInTime, activeTime, fadeOutTime;
    private Color trans = new Color(1, 1, 1, 0), main;

    void Start()
    {
        warningMat = GetComponent<MeshRenderer>().material;
        main = warningMat.color;
        warningMat.color = trans;
    }

    public void ActivateWarning(){
        StartCoroutine(WarnPlayer());
    }

    IEnumerator WarnPlayer()
    {
        float time = 0;
        yield return new WaitForSeconds(delayTime);
        while (time < fadeInTime)
        {
            warningMat.color = Color.Lerp(trans, main, time / fadeInTime);
            time += Time.deltaTime;
            yield return null;
        }
        yield return new WaitForSeconds(activeTime);
        time = 0;
        while (time < fadeOutTime)
        {
            warningMat.color = Color.Lerp(main, trans, time / fadeOutTime);
            time += Time.deltaTime;
            yield return null;
        }
    }
}
