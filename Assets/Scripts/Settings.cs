using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    #region Singleton
    private static Settings _instance;
    public static Settings Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<Settings>();

                if (_instance == null)
                {
                    GameObject container = new GameObject("Settings");
                    _instance = container.AddComponent<Settings>();
                }
            }
            return _instance;
        }
    }
    #endregion

    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    public int BulletPerTap { get; set; } = 1;
    public float SpreadAmount { get; set; } = 0;
    public float BulletSize { get; set; } = 1;
    public bool Explosive { get; set; }
    public Color BulletColor { get; set; } = Color.white;
}
