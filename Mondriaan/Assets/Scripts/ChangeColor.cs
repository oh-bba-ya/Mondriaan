using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    public float changeTime;            // 변하는시간. 
    private float durationTime = 1.0f;            // 유지시간.


    SpriteRenderer render;
    float fTime =0;
    float[] col = { 0,0, 255 };
    int[] ind = { 0, 0, 0 };

    // Start is called before the first frame update
    void Start()
    {
        
        render = this.GetComponent<SpriteRenderer>();
        for(int i = 0; i < ind.Length; i++)
        {
            ind[i] = Random.Range(0, 3);
        }


    }

    // Update is called once per frame
    void Update()
    {
        fTime += Time.deltaTime;
        if(fTime >= changeTime)
        {
            render.color = new Color(col[ind[0]], col[ind[1]], col[ind[2]]);
            if(fTime >= changeTime + durationTime)
            {
                render.color = Color.white;
                changeTime += 3.0f;
            }
        }
    }

}
