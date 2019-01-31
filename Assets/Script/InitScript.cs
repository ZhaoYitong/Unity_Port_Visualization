using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitScript : MonoBehaviour {
    public GameObject container1Prefab;     //集装箱1
    public GameObject container2Prefab;     //集装箱2
    public GameObject container3Prefab;     //集装箱3
    public GameObject holderPrefab;         //支架
    public GameObject agvPrefab;            //AGV
    public GameObject hslPrefab;         //高速车道道路
    public GameObject clPrefab;         //缓冲车道道路
    public GameObject llPrefab;         //装卸车道道路

    [System.NonSerialized]
    
    public static List<GameObject> consInHolders = new List<GameObject>();    //支架作业序列
    public static List<GameObject> consInAgvs = new List<GameObject>();       //AGV作业序列

    //找箱函数
    public static GameObject FindCon(ConScript.ContainerSite consite, Vector3Int conCoord, int yardNum = 0)
    {
        
        if (consite == ConScript.ContainerSite.Holder)
        {
            foreach (GameObject container in consInHolders)
            {
                ConScript conscript = container.GetComponent<ConScript>();
                if (conscript.holderId == conCoord.x && conscript.yardNum == yardNum)
                {
                    return container;
                }
            }
        }
        else if (consite == ConScript.ContainerSite.AGV)
        {
            throw new System.Exception("空缺");
        }
        else if (consite == ConScript.ContainerSite.Ship)
        {
            throw new System.Exception("空缺");
        }
        return null;
    }
    // 移除箱子函数，代表任务做完
    public static GameObject RemoveCon(ConScript.ContainerSite consite, Vector3Int conCoord, int yardNum = 0)
    {
        GameObject container = FindCon(consite, conCoord, yardNum);
        if (consite == ConScript.ContainerSite.Holder)
        {
            consInHolders.Remove(container);
        }
        else if (consite == ConScript.ContainerSite.AGV)
        {
            throw new System.Exception("空缺");
        }
        else if (consite == ConScript.ContainerSite.Ship)
        {
            throw new System.Exception("空缺");
        }
        return container;
    }
    //加入箱子任务
    public static void AddCon(GameObject container)
    {
        ConScript conscript = container.GetComponent<ConScript>();
        ConScript.ContainerSite consite = conscript.consite;
        if (consite == ConScript.ContainerSite.Holder)
        {
            consInHolders.Add(container);
            return;
        }
        else if (consite == ConScript.ContainerSite.AGV)
        {
            throw new System.Exception("空缺");
        }
        else if (consite == ConScript.ContainerSite.Ship)
        {
            throw new System.Exception("空缺");
        }
    }
    void Start () {

        
        HolderGenerate();
        HSLaneGenerate();
        CLaneGenerate();
        LLaneGenerate();
        AGVGenerate();
        ContainerGenerate(0);
    }

    // Update is called once per frame
    void Update () {
		
	}
    void HolderGenerate()
    {
        float xpos = -6;
        float ypos = 0;
        float zpos = 2;
        for (int i = 0; i<=4; i++)
        {
            GameObject holder_yard1 = Instantiate(holderPrefab, new Vector3(xpos, ypos, zpos + 4 * i), Quaternion.identity) as GameObject;
            GameObject holder_yard2 = Instantiate(holderPrefab, new Vector3(xpos, ypos, zpos + 40 + 4 * i), Quaternion.identity) as GameObject;
            GameObject holder_yard3 = Instantiate(holderPrefab, new Vector3(xpos, ypos, zpos + 80 + 4 * i), Quaternion.identity) as GameObject;
            GameObject holder_yard4 = Instantiate(holderPrefab, new Vector3(xpos, ypos, zpos + 120 + 4 * i), Quaternion.identity) as GameObject;
        }
    }
    void HSLaneGenerate()
    {
        float xpos = ParameterScript.HSLX;
        float ypos = 0;
        float zpos = ParameterScript.HSLZ;
        for (int i = 0; i <= 5; i++)
        { 
            GameObject lanehighspeed = Instantiate(hslPrefab, new Vector3(xpos - 4 * i, ypos, zpos), Quaternion.identity) as GameObject;
            LaneScript laneScript = lanehighspeed.GetComponent<LaneScript>();

            laneScript.InitSize(ParameterScript.HSLLength, ParameterScript.onelanewidth, ParameterScript.Direction.Vertical);
        }
    }
    void CLaneGenerate() {
        float xpos = ParameterScript.CLX;
        float ypos = 0;
        float zpos = ParameterScript.CLZ;
        for (int i = 0; i <= 40; i++) {
            GameObject lanecache = Instantiate(clPrefab, new Vector3(xpos, ypos, zpos + 4 * i), Quaternion.identity) as GameObject;
            LaneScript laneScript = lanecache.GetComponent<LaneScript>();

            laneScript.InitSize(ParameterScript.CLLength, ParameterScript.onelanewidth, ParameterScript.Direction.Horizontal);
        }
    }
    void LLaneGenerate() {
        float xpos = ParameterScript.LLX;
        float ypos = 0;
        float zpos = ParameterScript.LLZ;
        for (int i = 0; i<=5; i++) {
        GameObject laneloading = Instantiate(llPrefab, new Vector3(xpos - 4 * i, ypos, zpos), Quaternion.identity) as GameObject;
        LaneScript laneScript = laneloading.GetComponent<LaneScript>();

        laneScript.InitSize(ParameterScript.HSLLength, ParameterScript.onelanewidth, ParameterScript.Direction.Vertical);
        }
    }
    void AGVGenerate()
    {
        float xpos = 0, zpos = 0;
        for (int i = 0; i < 10; i++)
        {
            xpos = ParameterScript.CLX;
            zpos = ParameterScript.CLZ + ParameterScript.CLWidth / 2 + ParameterScript.CLWidth * i;
            GameObject agv = Instantiate(agvPrefab, new Vector3(xpos, 0, zpos), Quaternion.identity) as GameObject;
            agv.name = "AGV" + i.ToString();
        }
    }
    void ContainerGenerate(int yardNum)
    {
        //float xpos = ParameterScript.holderX;
        yardNum = 0;
        Vector3Int conCoord = new Vector3Int(-6, 0, 2);
        ConScript.ContainerSite consite = ConScript.ContainerSite.Holder;//设置位置为Holder
        GameObject container = Instantiate(container1Prefab, new Vector3(ParameterScript.holderX, ParameterScript.holderHeight + ParameterScript.containerHeight / 2, ParameterScript.holderZ),Quaternion.identity) as GameObject;
        consInHolders.Add(container);
        ConScript conscript = container.GetComponent<ConScript>();
        conscript.UpdateInfo(consite, conCoord, yardNum);
    }
}
