using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_2_Manager : MonoBehaviour
{
    [SerializeField] float vehiclesDestroyed;

    

    public void VehiclesDestroyedTrack()
    {
        vehiclesDestroyed++;
    }

    


    private void Update()
    {
    }
}
