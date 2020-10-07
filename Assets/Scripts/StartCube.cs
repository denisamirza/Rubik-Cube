using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEditor;
using UnityEngine;
using Debug = UnityEngine.Debug;
using Random = System.Random;

public class StartCube : MonoBehaviour
{
    public List<GameObject> g;
    public GameObject prefab, tempParent;
    
    // Start is called before the first frame update
    void Start()
    {
        instantiate();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
            //transform.Rotate(900*Time.deltaTime, 0, 0);
            StartCoroutine(Rot(5, 0, 0));
        if (Input.GetKeyDown(KeyCode.DownArrow))
            StartCoroutine(Rot(-5, 0, 0));
        // transform.Rotate(-90, 0, 0);
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            StartCoroutine(Rot(0, 5, 0));
        //transform.Rotate(0, -90, 0);
        if (Input.GetKeyDown(KeyCode.RightArrow))
            StartCoroutine(Rot(0, -5, 0));
        //transform.Rotate(0, 90, 0);
    }


    IEnumerator Rot(int x, int y, int z)
    {
        for (int i = 0; i < 18; i++)
        {
            transform.Rotate(x, y, z);
            
            yield return new WaitForSeconds(0.001f);
        }
    }
    
    IEnumerator Sides(int x, int y, int z)
    {
        for (int i = 0; i < 18; i++)
        {
            tempParent.transform.Rotate(x, y, z);
            Debug.Log(i + "   nananan");
            yield return new WaitForSeconds(0.01f);
        }
    }

    public void destroyCube()
    {
        foreach (GameObject p in g)
        {
            DestroyImmediate(p,true);
        }
        instantiate();
    }
    void instantiate()
    {
        Vector3 position;
        int l = 0;
        g = new List<GameObject>();
        for(float i = 0; i < 3; i++)
            for(int j = 0; j < 3; j++)
                 for (int k = 0; k < 3; k++)
                  {
                        position = new Vector3(i-1, j-1, k-1);
                        //position = new Vector3(i, j, k);
                        g.Add(Instantiate(prefab, position, transform.rotation));
                        g[l].transform.parent = transform;
                        l++;
                  }
       
    }
    public void removeChildren()
    {
        while (tempParent.transform.childCount > 0)
        {
            Transform child = tempParent.transform.GetChild(0);
            child.parent = this.gameObject.transform;
        }
    }

    public void L()
    {
        AddTempParent('x', -1, -1);
    }
    
    public void Li()
    {
        AddTempParent('x', -1, 1);
    }
    
    public void R()
    {
        AddTempParent('x', 1, 1);
    }
    
    public void Ri()
    {
        AddTempParent('x', 1, -1);
    }
    
    public void D()
    {
        AddTempParent('y', -1, -1);
    }
    
    public void Di()
    {
        AddTempParent('y', -1, 1);
    }
    
    public void U()
    {
        AddTempParent('y', 1, 1);
    }
    
    public void Ui()
    {
        AddTempParent('y', 1, -1);
    }
    
    public void B()
    {
        AddTempParent('z', 1, 1);
    }
    
    public void Bi()
    {
        AddTempParent('z', 1, -1);
    }
    
    public void F()
    {
        AddTempParent('z', -1, -1);
    }
    
    public void Fi()
    {
        AddTempParent('z', -1, 1);
    }
    void  AddTempParent(char ch, int n, int o)
    {
        Destroy((tempParent));
        tempParent = new GameObject();
        switch (ch)
        {
            case 'x':
                foreach (GameObject c in g)
                    if (c.transform.position.x <= (n+0.5) && c.transform.position.x >= (n-0.5))
                    {
                        Debug.Log(c.transform.position.x);
                        c.transform.parent = tempParent.transform;
                    }
                //Stopwatch s = new Stopwatch();
               // s.Start();
                //StartCoroutine(Sides( o*5, 0,0));
               // s.Stop();
               // Debug.Log("Time"+ s.Elapsed);
                //Quaternion r = Quaternion.Euler(o*90,0,0);
                //tempParent.transform.rotation= Quaternion.Slerp(tempParent.transform.rotation,r,0.2f);
                tempParent.transform.Rotate(o*90, 0, 0);
                break;
            case 'z':
                foreach (GameObject c in g)
                    if (c.transform.position.z <= (n+0.5) && c.transform.position.z >= (n-0.5))
                    {
                        Debug.Log(c.transform.position.z);
                        c.transform.parent = tempParent.transform;
                    }
                //StartCoroutine(Sides( 0, 0,o*5));
                //Quaternion r1 = Quaternion.Euler(0,0,o*90);
                //tempParent.transform.rotation= Quaternion.Slerp(tempParent.transform.rotation,r1,0.2f);
                tempParent.transform.Rotate(0, 0, o*90);
                break;
            case 'y':
                Debug.Log("here");
                foreach (GameObject c in g)
                    if (c.transform.position.y <= (n+0.5) && c.transform.position.y >= (n-0.5))
                    {
                        Debug.Log(c.transform.position.y);
                        c.transform.parent = tempParent.transform;
                    }

                //StartCoroutine(Sides( 0, o*5,0));
                //Quaternion r2 = Quaternion.Euler(0,o*90,0);
                //tempParent.transform.rotation= Quaternion.Slerp(tempParent.transform.rotation,r2,0.2f);
                tempParent.transform.Rotate(0, o*90, 0);
                break;
        }
        removeChildren();
    }
    

    public IEnumerator shuffle()
    {
        Random r = new Random();
        int i = 0;
        while (i < 10)
        {
            int num = r.Next(-1111,1881);
            num = num % 12;
            switch (num)
            {
                case 0: R();
                    break;
                case 1: Ri();
                    break;
                case 2: L();
                    break;
                case 3: Li();
                    break;
                case 4: B();
                    break;
                case 5: Bi();
                    break;
                case 6: D();
                    break;
                case 7: Di();
                    break;
                case 8: F();
                    break;
                case 9: Fi();
                    break;
                case 10: U();
                    break;
                case 11: Ui();
                    break;
            }
            yield return new WaitForSeconds(1);
            Debug.Log("NUM="+num);
            i++;
        }
    }

    public void startShuffle()
    {
        StartCoroutine(shuffle());
    }

}
