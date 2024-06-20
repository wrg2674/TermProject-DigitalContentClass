using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Equipment : MonoBehaviour
{
    [SerializeField]private List<GameObject> list;

    private GameObject item;
    private int idx = -1;

    public bool isEnd = false;
    public Slime slime;

    public void LevelUp(float value)
    {
        if(list.Count <= 0)
        {
            isEnd = true;
            return;
        }
        if(item != null)
        {
            Destroy(item);
        }
        idx++;
        Debug.Log("Idx : " + idx);
        item = Instantiate(list[idx]);
        item.transform.parent = this.transform;
        item.transform.localPosition = new Vector3(0, 0, 0);
        item.transform.localScale = item.transform.localScale * value;
        if(idx == list.Count-1)
        {
            isEnd = true;
        }
    }
    public void updateScale(float value)
    {
        if(item == null)
        {
            return;
        }
        item.transform.localScale = item.transform.localScale * value;
    }
    
}
