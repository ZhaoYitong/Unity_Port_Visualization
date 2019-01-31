using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParameterScript : MonoBehaviour {
    //场地设置参数
    public const float Length = 160;
    public const float Width = 84;
    //支架参数
    public const float holderLength = 12;  //支架长度
    public const float holderWidth = 4;   //支架宽度
    public const float holderRealWidth = 2.3f;   //支架实际宽度
    public const float holderHeight = 4.4f;  //支架高度      
    public const float holderZ = 2;
    public const float holderX = -6;
    //对位区参数
    public const float bufferWidth = 4; //对位区宽度
    public const float bufferLength = 16; //对位区长度
    //高速车道参数(highspeed lane)
    public const float HSLLength = 160;
    public const float HSLWidth = 4;
    public const float HSLCount = 5;
    public const float HSLX = -28;
    public const float HSLZ = 80;
    //缓冲车道参数(Cache lane)
    public const float CLLength = 16;
    public const float CLWidth = 4;
    public const float CLCount = 40;
    public const float CLX = -56;
    public const float CLZ = 0;
    //装卸车道(loading lane)
    public const float LLength = 160;
    public const float LLWidth = 4;
    public const float LLCount = 5;
    public const float LLX = -64;
    public const float LLZ = 80;
    //AGV小车参数
    public const float agvLength = 13;
    public const float agvWidth = 2.35f;
    public const float agvHeight = 2.4f;
    public const float agvSpeed = 15;
    //一根车道显示的宽度
    public const float onelanewidth = 0.5f;
    //40英尺标准集装箱尺寸
    public const float containerLength = 12;
    public const float containerWidth = 2.35f;
    public const float containerHeight = 2.4f;
    //AGV行驶类型
    public enum Direction
    {
        Horizontal,
        Vertical
    }
    //AGv工作类型
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
