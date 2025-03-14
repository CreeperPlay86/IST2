using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject linePrefab;
    
    public GameObject inventory;
    public List<GameObject> lines;
    public List<GameObject> slots;

    private int counter = 5;
    int linesCount = 0;
    public int emptyCounter;
    
    // Start is called before the first frame update
    void Start()
    {
        AddSlots();
    }

    // Update is called once per frame
    void Update()
    {
        if (emptyCounter <= 2)
        {
            AddSlots();
        }
    }

    void AddSlots()
    {
                
        lines.Add(Instantiate(linePrefab));
        lines[linesCount].transform.SetParent(inventory.transform);
        lines[linesCount].transform.localScale = new Vector2(1, 1);
        
        slots.Add(lines[linesCount].transform.GetChild(0).gameObject);
        slots.Add(lines[linesCount].transform.GetChild(1).gameObject);
        slots.Add(lines[linesCount].transform.GetChild(2).gameObject);
        slots.Add(lines[linesCount].transform.GetChild(3).gameObject);
        slots.Add(lines[linesCount].transform.GetChild(4).gameObject);
        
        emptyCounter += 5;
        linesCount++;
        
    }

    public void AddItem()
    {
        for (int i = 0; i < slots.Count; i++)
        {
            if (slots[i].GetComponent<SlotParameter>().isEmpty)
            {
                slots[i].GetComponent<SlotParameter>().isEmpty = false;
                emptyCounter--;
                break;
            }
        }
    }
}
