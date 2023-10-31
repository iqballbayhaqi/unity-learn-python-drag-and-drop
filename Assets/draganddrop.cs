using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class draganddrop : MonoBehaviour
{
    public GameObject item;
    private gamemanager gm;
    public string typeString;
    public bool isPlaced = false;

    public int jarak;

    public Vector2 itemPos;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("gamemanager").GetComponent<gamemanager>();
        itemPos = item.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ItemDrag()
    {
        if (!isPlaced)
        {
            item.transform.position = Input.mousePosition;
        }
    }

    public void ItemEndDrag()
    {
        bool isThere = false;

        switch (gm.level)
        {
            case 1:
                forEachItemDrop(isThere, gm.itemDropsLvl1, gm.fieldAnswerLvl1);
                break;
            case 2:
                forEachItemDrop(isThere, gm.itemDropsLvl2, gm.fieldAnswerLvl2);
                break;
            case 3:
                forEachItemDrop(isThere, gm.itemDropsLvl3, gm.fieldAnswerLvl3);
                break;
            default:
                break;
        }
    }

    public void forEachItemDrop(bool isThere, List<GameObject> itemDrops, string[] fieldAnswer)
    {
        for (int i = 0; i < itemDrops.Count; i++)
        {
            if (fieldAnswer[i] == "" && !isPlaced)
            {
                var itemDrop = itemDrops[i];
                float distance = Vector3.Distance(item.transform.localPosition, itemDrop.transform.localPosition);

                if (distance < jarak)
                {
                    item.transform.localPosition = itemDrop.transform.localPosition;
                    isThere = true;
                    fieldAnswer[i] = typeString;
                    isPlaced = true;
                    break; // If an itemDrop is found within the range, break out of the loop.
                }
            }
        }

        if (!isThere && !isPlaced)
        {
            // If no suitable itemDrop is found, reset the item's position.
            item.transform.localPosition = itemPos;
        }
    }
}
