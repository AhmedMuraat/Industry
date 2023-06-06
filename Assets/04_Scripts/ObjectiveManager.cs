using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectiveManager : MonoBehaviour
{
    [SerializeField]private Queue<string> _sentences;
    [SerializeField] private TextMeshProUGUI _dialogueText;
    [SerializeField] private Objectives _objectives;

    // Start is called before the first frame update
    void Start()
    {
        _sentences = new();
        Add(_objectives);
        NextObjective();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextObjective()
    {
        if (_sentences.Count > 0)
        {
            _dialogueText.text = _sentences.Dequeue();
        }
    }

    public void ResetObjectives()
    {
        _sentences.Clear();
        Add(_objectives);
        NextObjective();
    }

    public void Add(Objectives objective)
    {
        foreach (string sentence in objective.GetLines())
        {
            _sentences.Enqueue(sentence);
        }
    }
}
