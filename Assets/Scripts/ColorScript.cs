using UnityEngine;
using System.Collections;

namespace Assets.Scripts
{
    public class ColorScript : MonoBehaviour
    {

        public bool randomColor;
        public Color color;

        // Use this for initialization
        private void Start()
        {
            if (randomColor == true)
            {
                //color = new Color(Random.Range(0, 255), Random.Range(0, 255), Random.Range(0, 255));
            }
            renderer.material.color = color;
        }

        // Update is called once per frame
        private void Update()
        {

        }
    }
}