using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class TableScript : MonoBehaviour
{
    public GameObject Panel;
    public Button Button;
    public TextMeshProUGUI dialogueText;
    private bool IsOpen;
    [SerializeField]private GameObject customer;


    // Start is called before the first frame update
    void Start()
    {
        IsOpen = true;
    }

    void Update(){
        if(IsOpen){
            Instantiate(customer, transform.position, quaternion.identity, gameObject.transform);
            IsOpen = false;
        }
    }

    // Update is called once per frame
    public bool GetIsOpen(){
        return IsOpen;
    }

    public void SetIsOpen(bool isOpen){
        this.IsOpen = isOpen;
    }
}
