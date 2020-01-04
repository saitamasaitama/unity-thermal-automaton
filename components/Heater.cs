using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Heater : MonoBehaviour
{
    private List<ThermalBlock> contacts=new List<ThermalBlock>();
    void Start()
    {
    }
    //放出熱量
    public float emitCarolie = 100;

    
    public void FixedUpdate(){
      float delta= Time.fixedDeltaTime;
      foreach(ThermalBlock b in contacts){
        UpdateThermal(delta,emitCarolie,b);
      }
    }

    private static void UpdateThermal(float delta,float emit,ThermalBlock B){
      
        //放出熱量と熱伝導率を
       float cal= Thermal.Watt2cal(emit,delta);  
        //Aに対して熱が送られる
       B.calorie += cal;


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


}
