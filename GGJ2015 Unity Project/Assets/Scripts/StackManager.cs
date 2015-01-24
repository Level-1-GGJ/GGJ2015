using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StackManager : MonoBehaviour {

    public List<GameObject> stacks;
    public List<string> instructions;
	// Use this for initialization
    void Start()
    {
        if (stacks.Count != instructions.Count)
        {
            Debug.LogError(this.name + " has different number of stacks from instructions.");
        }
        for (int i = 0; i < stacks.Count; i++)
        {
            stacks[i].GetComponent<PaperStack>().Initialize(instructions[i]);
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
