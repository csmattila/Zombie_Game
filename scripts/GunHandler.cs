using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GunHandler : MonoBehaviour
{
    private TMP_Dropdown dropdown;
    private string selectedGun;
    // Start is called before the first frame update
    void Start()
    {
        dropdown = GetComponent<TMP_Dropdown>();
        selectedGun = dropdown.captionText.text;
        Debug.Log("The selected gun is " + selectedGun);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public string getSelectedGun()
    {
        return dropdown.captionText.text;
    }


}
