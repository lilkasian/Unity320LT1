using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sketch : MonoBehaviour {

    public GameObject myPreFab;

    public List<GameObject> myCubeList;
    public float nextActionTime = 0.0f;
    public float period = 1.0f;
    public GameObject s;
    public ArrayList myNodes;

    // Use this for initialization
    void Start () {

        int totalSpheres = 15;
        int totalCubes = 15;
        float totalDistance = 2.9f;

        //Makes a list for the cubes
        myCubeList = new List<GameObject>();



        for (int i = 0; i < totalCubes; i++)
        {
            float perc = i / (float)totalCubes;

            float sin = Mathf.Sin(perc * Mathf.PI/2);

            float x = 1.8f + sin * totalDistance;
            float y = 7.0f;
            float z = 0.0f;

            var newCube = (GameObject)Instantiate(myPreFab, new Vector3(x, y, z), Quaternion.identity);
            newCube.GetComponent<CubeScript>().SetSize(0.45f * (1.0f - perc));
            newCube.GetComponent<CubeScript>().rotateSpeed = 0.2f + perc*4.0f;

            //Adds newCube to the list
            myCubeList.Add(newCube);


        }
        myNodes = new ArrayList();

        for (int i = 0; i < totalSpheres; i++)
        {
            float perc = i / (float)totalCubes;

            float sin = Mathf.Sin(perc * Mathf.PI / 2);

            float x = 1.8f + sin * totalDistance;
            float y = 2.0f;
            float z = 0.0f;

            s = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            s.transform.position = new Vector3(x,y,z);
            s.GetComponent<CubeScript>().SetSize(0.45f * (1.0f - perc));
            s.GetComponent<CubeScript>().rotateSpeed = 0.2f + perc * 4.0f;

            myNodes.Add(s);
        }
    }

    


    // Update is called once per frame
    void Update()
    {

        //if the time is > then the next action time
        if (Time.time > nextActionTime)
        {
            nextActionTime += period;
            foreach (var cube in myCubeList) {
                //Picks random colour for each cube in myCube
                //Color newColor = new Color
                cube.GetComponent<Renderer>().material.color = new Color(Random.value, Random.value, Random.value, 1.0f);
            }

        }
        

       
    }


}
