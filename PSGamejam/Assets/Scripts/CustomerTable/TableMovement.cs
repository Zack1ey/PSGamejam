using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;

public class TableMovement : MonoBehaviour
{
    [SerializeField] private List<GameObject> Tables = new List<GameObject>();
    [SerializeField] GameObject pointerRef;
    int tableNum = 0;
    private GameObject pointer;
    private String miniGame;

    // Start is called before the first frame update
    void Start()
    {
        pointer = Instantiate(pointerRef, Tables[tableNum].transform.position + new Vector3(0f, 3f, 0f), quaternion.identity);

    }

    // Update is called once per frame
    void Update()
    {
        moveThroughTable();
        if (CheckTableForCustomer() && Input.GetKeyDown(KeyCode.Space))
        {
            if (getTable() != null)
            {
                getTable().GetComponent<CustomerTableScript>().GetCustomer().GetComponent<CustomerClass>().LoadMiniGame(GetRandomGame());
                getTable().GetComponent<CustomerTableScript>().RemoveCustomer();
            }
        }
    }

    private bool CheckTableForCustomer()
    {
        return !getTable().GetComponent<CustomerTableScript>().GetAvalible();
    }

    public GameObject getTable()
    {
        return Tables[tableNum];
    }

    private String GetRandomGame()
    {
        int minigameNum = UnityEngine.Random.Range(0, 0);
        switch (minigameNum)
        {
            case 0:
                return "CleanThePlate";
        }
        return "MainMenu";
    }

    public void moveThroughTable()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            tableNum++;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            tableNum--;
        }

        tableNum = Mathf.Clamp(tableNum, 0, Tables.Count - 1);

        // Move the pointer to the new table position
        if (pointer != null)
        {
            pointer.transform.position =
                Tables[tableNum].transform.position + new Vector3(0f, 5f, 0f);
        }

    }
}
