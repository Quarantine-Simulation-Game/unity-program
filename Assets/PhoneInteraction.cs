using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneInteraction : MonoBehaviour
{
    [SerializeField] GameObject phone;
    bool isActive = false;
    public void PhoneBtnToggle()
    {
        phone.SetActive(!isActive);
        isActive = !isActive;
    }
}
