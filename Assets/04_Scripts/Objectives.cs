using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objectives : MonoBehaviour
{
    [SerializeField] private TextAsset file;
    [SerializeField] private string[] lines;

    private void OnValidate()
    {
        GenerateLines();
    }
    public void GenerateLines()
    {
        lines = file ? file.text.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries) : null;
    }
    public string[] GetLines() { return lines; }
}
