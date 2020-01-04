using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ThermalBlock : MonoBehaviour
{
  private List<ThermalBlock> contacts=new List<ThermalBlock>();


  //比熱係数 
  public float C=3f;
  //現在与えられているカロリー
  public double calorie=0;
  //質量(g)
  public float mass=10*10*10;
  
  //熱伝導率(1mあたり W)
  public float thermalConductivity = 500;

//1w＝1/（4.184×時間［s］）cal
//1cal＝（4.184×時間［s］）w
  
  

  public float Kelvin{
    set{
      calorie= value*C*mass;
    }
    get=>(float)calorie/(mass*C);
  }
  private Material mat;

    void Start()
    {
      this.mat= this.GetComponent<Renderer>().material;
    }

    public void Update(){
      mat.color=Color.HSVToRGB(
        0,
        1f,
        (Kelvin/1000f)
      );
    }



    public void FixedUpdate(){
      float delta= Time.fixedDeltaTime;
      foreach(ThermalBlock b in contacts){
        UpdateThermal(delta,this,b);
      }
    }

    //接触している面積：時間：熱伝導率により相手に熱を与える
    private static void UpdateThermal(float delta,ThermalBlock A,ThermalBlock B){
      //隣の熱と自分の熱を交換
      
      //熱伝導率を 1K = 1Secとする
      if(A.Kelvin < B.Kelvin){
        float cal= Thermal.Watt2cal(A.thermalConductivity,delta);  
        //Aに対して熱が送られる
        A.calorie += cal;
        B.calorie -= cal;        
      }

      else if(B.Kelvin < A.Kelvin){
        float cal= Thermal.Watt2cal(B.thermalConductivity,delta);  
        //Bに対して熱が送られる
        B.calorie += cal;
        A.calorie -= cal;        
      }
    }

    void OnCollisionEnter(Collision other){
      var o= other.gameObject.GetComponent<ThermalBlock>();

      if(o!=null){
        contacts.Add(o);
      }
    }

    void OnCollisionExit(Collision other){

      var o= other.gameObject.GetComponent<ThermalBlock>();

      if(o!=null){
        contacts.Remove(o);
      }
    }

    public static ThermalBlock operator + (ThermalBlock A,ThermalBlock B){
      

      return A;
    }

}
