using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scroll : MonoBehaviour
{
    public GameObject scrollbar, canvas, player;
    float[] pos;
    public static int itemWidth, curretPos =0;
    HorizontalLayoutGroup layoutGroup;
    public CharacterSelect characterSelect;

    void Start()
    {
        itemWidth = (int)transform.GetChild(0).gameObject.GetComponent<RectTransform>().sizeDelta.y;
        layoutGroup = gameObject.GetComponent<HorizontalLayoutGroup>();

        pos = new float[transform.childCount];
        float distance = 1f / (pos.Length - 1f);
        for(int i = 0; i< pos.Length;i++)
        {
            pos[i] = distance * i;
            transform.GetChild(i).GetComponent<Image>().color= characterSelect.characterOptions[i+1].color;
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.RightArrow) && curretPos<(pos.Length-1f) ){curretPos+=1;}
        if(Input.GetKeyDown(KeyCode.LeftArrow) && curretPos>0 ){curretPos-=1;}
        scrollbar.GetComponent<Scrollbar>().value = Mathf.Lerp(scrollbar.GetComponent<Scrollbar>().value, pos[curretPos], 0.1f);

        layoutGroup.padding.left = layoutGroup.padding.right = (int)canvas.GetComponent<RectTransform>().sizeDelta.x/2 -50 - itemWidth/2;
        layoutGroup.spacing = layoutGroup.padding.left;

        if(Input.GetKeyDown(KeyCode.Space)){
            player.SetActive(true);
            CharacterSelect.pauseState=false;
        }
    }
}
