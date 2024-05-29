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

        // Rotate the instantiated character to face the opposite direction
        clone.transform.rotation *= Quaternion.Euler(0, 180, 0);

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
