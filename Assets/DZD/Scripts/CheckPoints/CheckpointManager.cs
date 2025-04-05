using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


    internal class CheckpointManager: MonoBehaviour
    {
    public static CheckpointManager Instance { get; private set; }
    private CheckPoints currentCheckpoint;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void SetCheckpoint(CheckPoints checkpoint)
    {
        currentCheckpoint = checkpoint;
        Debug.Log($"Checkpoint set at position: {checkpoint.transform.position}");
    }

    public Vector3 GetCheckpointPosition()
    {
        return currentCheckpoint != null ? currentCheckpoint.transform.position : Vector3.zero;
    }
}
    

