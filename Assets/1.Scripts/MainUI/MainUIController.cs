using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainUIController : MonoBehaviour
{
    public static MainUIController instance;
    [SerializeField] private Button btn;
    [SerializeField] private GameObject[] prefabs;
    [SerializeField] private Transform parent;
    [SerializeField] private Transform[] unParents;
    // Start is called before the first frame update
    void Awake() {instance = this;}

    void Start()
    {
        Instantiate(prefabs[0], parent);
        foreach(var unParent in unParents)
        {
            Instantiate(prefabs[1], unParent);
        }
        btn.onClick.AddListener(OnButtonSCene);
    }

    void OnButtonSCene()
    {
        SceneManager.LoadScene(1);
    }
}
