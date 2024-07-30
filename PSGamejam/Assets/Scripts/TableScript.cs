using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableScript : MonoBehaviour
{
    private bool IsOpen;
    // Start is called before the first frame update
    void Start()
    {
        IsOpen = true;
    }

    // Update is called once per frame
    public bool GetIsOpen(){
        return IsOpen;
    }

    public void SetIsOpen(bool isOpen){
        this.IsOpen = isOpen;
    }
}
