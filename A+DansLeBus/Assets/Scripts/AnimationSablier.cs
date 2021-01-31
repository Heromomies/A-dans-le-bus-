using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class AnimationSablier : MonoBehaviour
{
    private bool _playOnce = true;

    // Update is called once per frame
    void Update()
    {
        if (GameManager.gm.timerEndLevelMinute==0 && GameManager.gm.timerEndLevelSecond <=30&& _playOnce)
        {
            gameObject.transform.DOScale(new Vector3(1.5f, 1.5f, 0), 1).SetLoops(30, LoopType.Yoyo);
            _playOnce = false;
        }
    }
}
