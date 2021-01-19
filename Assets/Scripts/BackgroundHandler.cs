using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundHandler : MonoBehaviour
{
    [SerializeField] public Node nodePrefab;
    [SerializeField] public GameObject nodeList;


    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mouseWorldPos, Vector2.zero);
            InstantiateNewNode(mouseWorldPos);

          
        }
    }

    private void InstantiateNewNode(Vector2 mouseWorldPosition)
    {
        var newNode = Instantiate(nodePrefab, mouseWorldPosition, Quaternion.identity);
        newNode.transform.parent = nodeList.transform;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
