using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    //public Animator anim;
    //public Button btn_setting;

    //void Start()
    //{
    //    anim = GetComponent<Animator>();
    //}

    ////void Update()
    ////{
    ////    TaskOnClick();
    ////}

    //public void TaskOnClick()
    //{
    //    anim.Play("slide_setting");
    //}
    public void ButtonSetting()
    {
        GetComponent<Animator>().SetBool("slide_setting", true);
    }
}
