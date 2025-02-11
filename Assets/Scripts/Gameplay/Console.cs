using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;  // Import TextMeshPro


public class Console : MonoBehaviour
{
    public TextMeshProUGUI consoleText;  // Use TextMeshPro instead of UI.Text
    public List<string> lines;

    void Start()
    {
        lines = new List<string>();
    }

    void flush()
    {
        lines.Clear();
    }

    public void AddLine(string line)
    {
        lines.Add(line);
    }
    // Update is called once per frame
    void Update()
    {
        string content = "";
        
        for (int i = lines.Count - 1; i >= 0; i--)
        {
            content = lines[i] + "\n";
        }

        consoleText.text = content;
    }
}
