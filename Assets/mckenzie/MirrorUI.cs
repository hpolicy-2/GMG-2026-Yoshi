using System.Collections;using System.Collections.Generic;using UnityEngine;public class MirrorUI : MonoBehaviour
{    public GameObject uiObject;    private void OnTriggerEnter(Collider collision)
    {        if (collision.CompareTag("Player"))
        {            uiObject.SetActive(true);        }    }    private void OnTriggerExit(Collider collision)
    {        if (collision.CompareTag("Player"))
        {            uiObject.SetActive(false);        }    }}