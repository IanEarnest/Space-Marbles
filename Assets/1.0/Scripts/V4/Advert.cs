using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// version 1.4
namespace SpaceMarbles.V4 {
	public class Advert : MonoBehaviour {
		public Text myText;

		// Use this for initialization
		void Start () {

		}

		// Update is called once per frame
		void Update () {

		}

		private void OnMouseDown()
		{
			myText.text = "Hello World!";
		}
	}
}