using BNG;
using UnityEngine;

public class SwitchModels : MonoBehaviour
{
    private GameObject[] models;
    private int currentModel = 0;

    void Start()
    {
        models = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            models[i] = transform.GetChild(i).gameObject;
            models[i].SetActive(false);
        }

        if (models.Length > 0)
        {
            models[0].SetActive(true);
        }
    }

    void Update()
    {
        if (InputBridge.Instance.AButtonDown) 
        {
            PreviousModel();
            Debug.Log("Model Switch Backward");
        }

        if (InputBridge.Instance.BButtonDown) 
        {
            NextModel();
            Debug.Log("Model Switch Forward");
        }
    }

    public void NextModel()
    {
        models[currentModel].SetActive(false);
        currentModel++;
        if (currentModel >= models.Length)
        {
            currentModel = 0;
        }
        models[currentModel].SetActive(true);
    }

    public void PreviousModel()
    {
        models[currentModel].SetActive(false);
        currentModel--;
        if (currentModel < 0)
        {
            currentModel = models.Length - 1;
        }
        models[currentModel].SetActive(true);
    }

}
