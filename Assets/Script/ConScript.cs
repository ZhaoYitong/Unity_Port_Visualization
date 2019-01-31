using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConScript : MonoBehaviour {

    public enum ContainerSite          //集装箱位置
    {
        Yard,
        Holder,
        AGV,
        Ship
    }
    public ContainerSite consite;
    public int holderId;
    public int yardNum;
    // Use this for initialization
    void Start () {
        
        InitSize();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void InitSize()
    {
        float x1 = this.GetComponent<Renderer>().bounds.size.x;
        float x2 = this.GetComponent<Collider>().bounds.size.x;
        float xScale = x2 / x1;
        float y1 = this.GetComponent<Renderer>().bounds.size.y;
        float y2 = this.GetComponent<Collider>().bounds.size.y;
        float yScale = y2 / y1;
        float z1 = this.GetComponent<Renderer>().bounds.size.z;
        float z2 = this.GetComponent<Collider>().bounds.size.z;
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
    //更新位置信息
    public void UpdateInfo(ContainerSite site, Vector3Int coord, int yardnum)
    {
        if (site == ContainerSite.Holder)
        {
            UpdateInfoInHolder(yardnum, coord.x);
        }
        else if (site == ContainerSite.AGV)
        {
            UpdateInfoInAGV();
        }
    }
    
    public void UpdateInfoInAGV()
    {
        consite = ContainerSite.AGV;
    }
    public void UpdateInfoInHolder(int yardnum, int holderid)
    {
        consite = ContainerSite.Holder;
        this.yardNum = yardnum;
        this.holderId = holderid;
    }
    
    public Vector3Int Coord()
    {
       if (consite == ContainerSite.Holder)
        {
            return new Vector3Int(-6, 0, holderId);
        }
        else
        {
            throw new System.Exception("空缺");
        }
    }
}
