using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AGVScript : MonoBehaviour
{
    public enum AGVWorkType
    {
        ToHolder,          //AGV按路径去支架
        GetCon,           //取箱
        ToQC,              //AGV按路径去岸桥
        PutCon,           //放箱
        TurnCache,         //回到缓冲车道
        Wait              //等待
    }
    
    [System.NonSerialized]
    public int yardNum = 0;
    public int id = 0;
    Hashtable args = new Hashtable();
    void Start()
    {
        float holderid = 2;
        AGVToHolder(holderid);
        InitSize();
        
        
       // StartCoroutine(Move());
    }
    void Update()
    {

    }
    //AGV运行至指定支架位置
    public void AGVToHolder(float holderid, float s = ParameterScript.agvSpeed) {
        if (this.gameObject.name == "AGV0")
        {
            Debug.Log("testing");
            args.Add("easeType", iTween.EaseType.easeInOutExpo);
            args.Add("speed", s);
            Vector3 dest = new Vector3(-6, 0, 2);
            args.Add("position", dest);
            args.Add("onstart", "AnimationStart");
            args.Add("onstartparams", 5.0f);
            args.Add("onstarttarget", gameObject);
            iTween.MoveTo(gameObject, args);
        }
        else if (this.gameObject.name == "AGV1")
        {
            Debug.Log("testing");
            args.Add("easeType", iTween.EaseType.easeInOutExpo);
            args.Add("speed", s);
            Vector3 dest = new Vector3(-6, 0, 6);
            args.Add("position", dest);
            args.Add("onstart", "AnimationStart");
            args.Add("onstartparams", 5.0f);
            args.Add("onstarttarget", gameObject);
            iTween.MoveTo(gameObject, args);
        }

    }
   
    
    //初始化函数
    void InitSize()
    {
        float x1 = this.GetComponent<Renderer>().bounds.size.x;
        float x2 = ParameterScript.agvLength;
        float xScale = x2 / x1;

        float y1 = this.GetComponent<Renderer>().bounds.size.y;
        float y2 = ParameterScript.agvHeight;
        float yScale = y2 / y1;

        float z1 = this.GetComponent<Renderer>().bounds.size.z;
        float z2 = ParameterScript.agvWidth;
        float zScale = z2 / z1;

        MeshFilter meshf = this.GetComponent<MeshFilter>();
        Mesh mesh = meshf.mesh;
        Vector3[] newVecs = new Vector3[mesh.vertices.Length];
        Vector3[] oldVecs = mesh.vertices;
        for (int i = 0; i < oldVecs.Length; i++)
        {
            newVecs[i].Set(oldVecs[i].x * xScale, oldVecs[i].y * yScale, oldVecs[i].z * zScale);
        }
        mesh.vertices = newVecs;
        mesh.RecalculateBounds();
    }
    //任务函数
    
    
}
