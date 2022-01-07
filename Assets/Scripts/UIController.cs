using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] Toggle explosiveToggle;
    [SerializeField] Slider bulletAmount, bulletSize, spreadingAmount;
    [SerializeField] public GameObject panel;
    Settings settings;

    void Start()
    {
        settings = Settings.Instance;
        explosiveToggle.isOn = settings.Explosive;
        bulletAmount.value = settings.BulletPerTap;
        bulletSize.value = settings.BulletSize;
        spreadingAmount.value = settings.SpreadAmount;

        explosiveToggle.onValueChanged.AddListener(x => settings.Explosive = x);
        bulletAmount.onValueChanged.AddListener(x =>
        {
            settings.BulletPerTap = (int)x;
            spreadingAmount.minValue = x == 1 ? 0 : 0.5f;
        });
        bulletSize.onValueChanged.AddListener(x => settings.BulletSize = x);
        spreadingAmount.onValueChanged.AddListener(x => settings.SpreadAmount = x);
    }

    public void UIToggle()
    {
        panel.SetActive(!panel.activeSelf);
        Cursor.lockState = panel.activeSelf ? CursorLockMode.Confined : CursorLockMode.Locked;
    }
}
