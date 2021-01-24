using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NodeHandler : MonoBehaviour
{
    [SerializeField] public Node nodePrefab;
    [SerializeField] public GameObject nodeList;
    [SerializeField] public InputField nodeInputField;
    Vector2 mouseWorldPos;

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //RaycastHit2D hit = Physics2D.Raycast(mouseWorldPos, Vector2.zero);
            if (nodeInputField.IsActive() == false)
            {
                initEntry();
            }
            else //when clicking outside of inputfield, will submit inputContent as new node. 
            {
                submitEntry();
            }


        }
    }

    private void submitEntry()
    {
        nodeInputField.gameObject.SetActive(false);
        InstantiateNewNode(mouseWorldPos, nodeInputField.text);
        nodeInputField.text = null;
    }

    private void initEntry()
    {
        //get mouse location on bg img
        mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition); 
        //call out input field
        nodeInputField.transform.position = Input.mousePosition;
        nodeInputField.gameObject.SetActive(true);
        nodeInputField.ActivateInputField();
    }

    private void InstantiateNewNode(Vector2 mouseWorldPosition, string inputText)
    {
        var newNode = Instantiate(nodePrefab, mouseWorldPosition, Quaternion.identity);
        newNode.GetComponentInChildren<TextMeshPro>().text = inputText;
        newNode.transform.parent = nodeList.transform; //add to nodelist
    }

    void Start()
    {
        nodeInputField.gameObject.SetActive(false);
        nodeInputField.DeactivateInputField();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
