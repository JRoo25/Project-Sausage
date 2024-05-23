using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadCharacter : MonoBehaviour {
    public GameObject[] characterPrefabs;
    public Transform spawnPoint;

    void Start () {
        int selectedCharacter = PlayerPrefs.GetInt("selectedCharacter");
        GameObject prefab = characterPrefabs[selectedCharacter];
        GameObject clone = Instantiate(prefab, spawnPoint.position, Quaternion.identity);

        // Find the camera in the instantiated prefab
        Camera[] cameras = clone.GetComponentsInChildren<Camera>();
        foreach (Camera cam in cameras) {
            if (cam.CompareTag("MainCamera")) {
                cam.gameObject.SetActive(true);
                break;
            }
        }
    }
}
