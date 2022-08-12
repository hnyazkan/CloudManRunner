using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Collectables : MonoBehaviour
{

    void Start()
    {
        //Kac loop yapacagini soylemek : -1 demek infinite

        transform.DOMoveY(2.0f, 0.5f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InCubic);
        //transform.DOMoveX(2.0f, 0.5f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InCubic);
    }

    // Update is called once per frame
    void Update()
    {   

        if (RunnerController.thunderFlag)
        {
            thunderMethod();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            
            Destroy(this.gameObject);

        }
        
        
    }

    private void thunderMethod()
    {
        transform.DOMoveX(0f, 1.0f).SetLoops(4, LoopType.Yoyo).SetEase(Ease.InCubic);

    }


}
