using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MapHandler : MonoBehaviour
{
    private TMP_Dropdown dropdown;
    private string selectedMap;
    // Start is called before the first frame update
    void Start()
    {
        dropdown = GetComponent<TMP_Dropdown>();
        selectedMap = dropdown.captionText.text;
        Debug.Log("The selected map is " + selectedMap);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string getSelectedMap()
    {
        return dropdown.captionText.text;
    }


}
