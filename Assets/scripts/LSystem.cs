using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LSystem : MonoBehaviour
{
    [Range(1,4)]
    public int steps;
    
    const string axiom = "F";
    string sentence = axiom;

    Rule[] rules = new Rule[1];
 
    private Stack<Vector3> positions = new Stack<Vector3>();
    private Stack<Quaternion> rotations = new Stack<Quaternion>();
    Vector3 nextPosition = new Vector3();
    Quaternion rotation = Quaternion.identity;

    public GameObject branch;

    int j = 1;

    private void Start()
    {
        rules[0] = new Rule('F', "FF+[+F+[F+F]--F]-[-F+F+F]");
        Generator();
    }

    void Generator()
    {
        nextPosition = transform.position;
        positions.Push(transform.position);
        rotations.Push(transform.rotation);
        Turtle();
        for (int i = 0; i < steps; i++)
        {
            Generate();
        }
    }

    void Generate()
    {
        string nextSentence="";

        foreach (char current in sentence)
        {
            bool found = false;
            for (int j = 0; j < rules.Length && !found; j++)
            {
                if (current == rules[j].a)
                {
                    found = true;
                    nextSentence += rules[j].b;
                }
            }
            if (!found)
            {
                nextSentence += current;
            }
        }
        sentence = nextSentence;
        Turtle();
    }

    void Turtle()
    {
        foreach (char i in sentence)
        {
            if (i == 'F')
            {
                DrawBranch();
            }
            else if (i == '+')
            {
                Rotate(-25f);
            }
            else if (i == '-')
            {
                Rotate(25f);
            }
            else if (i == '[')
            {
                positions.Push(nextPosition);
                rotations.Push(rotation);
            }
            else if (i == ']')
            {
                nextPosition = positions.Pop();
                rotation = rotations.Pop();
            }
            //DebugTransformList();
        }
    }

    void DrawBranch()
    {
        //Instantiate the new branch at current transform
        GameObject copy = Instantiate(branch, nextPosition, rotation);
        copy.name = "branch " + j;
        copy.transform.parent = transform;
        nextPosition += copy.transform.up;
        j++;
    }

    void Rotate(float angle)
    {
        rotation *= Quaternion.Euler(0f, 0f, angle);
    }
}

public class Rule
{
    public char a;
    public string b;

    public Rule(char a, string b)
    {
        this.a = a;
        this.b = b;
    }
}
