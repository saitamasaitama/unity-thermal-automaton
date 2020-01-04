using System;

public class Thermal{
    public static float Watt2cal(float w,float delta)=>w*delta*4.184f;
}

public struct ThermalMaterialSetting{
    //熱伝導率
    public readonly double thermalConductivity;
    //比熱
    public readonly double Capacity;
    //比重
    public readonly double specificWeight;

    //質量
    public ThermalMaterialSetting(
        double specificWeight,
        double Capacity,
        double thermalConductivity        
        ){
        this.thermalConductivity=thermalConductivity;
        this.Capacity=Capacity;
        this.specificWeight=specificWeight;
    }



    public static ThermalMaterialSetting ZINC=>new ThermalMaterialSetting(
        7.13,
        383,
        113
    );
    public static ThermalMaterialSetting GOLD=>new ThermalMaterialSetting(
        7.13,
        383,
        113
    );
    public static ThermalMaterialSetting Juralmin=>new ThermalMaterialSetting(
        7.13,
        383,
        113
    );


}

public struct ThermalMaterial{
    public ThermalMaterialSetting setting;
    public float mass;
    //
    public float calorie;

    public static ThermalMaterial From(ThermalMaterialSetting setting,float mass,float cal)
    =>new ThermalMaterial(){
        setting=setting,
        mass=mass,
        calorie=cal
    };
}