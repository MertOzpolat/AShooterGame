using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorController : MonoBehaviour
{
    [SerializeField] Slider redSlide,greenSlide,blueSlide;
    [SerializeField] Image resultImage;

    private float redValue=255;
    private float greenValue=255;
    private float blueValue=255;
    void Start()
    {
        redSlide.onValueChanged.AddListener(r => ChangeColor(r,greenValue,blueValue));
        greenSlide.onValueChanged.AddListener(g => ChangeColor(redValue,g,blueValue));
        blueSlide.onValueChanged.AddListener(b => ChangeColor(redValue,greenValue,b));
    }

    void ChangeColor(float r,float g,float b){
        redValue=r;
        greenValue=g;
        blueValue=b;
        Color clr = new Color(r/255,g/255,b/255,1);
        resultImage.color=clr;
        Settings.Instance.BulletColor=clr;
    }
}
