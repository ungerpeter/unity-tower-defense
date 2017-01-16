﻿using UnityEngine;
using System.Collections;

public class MetallKeferController : MonoBehaviour {

	private GameController gameController;
	private GameObject[] baseBuildable;
	private GameObject nextWaypiont;
	private int currentWaypointIndex = 0;
	private int movementSpeed = 2;

	void Start () {
		this.gameController = GameObject.FindObjectOfType<GameController>();
		this.nextWaypiont = this.gameController.getWaypoints () [this.currentWaypointIndex];
		this.setInitialWaypoint ();
	}
	
	void Update() {
		this.moveToNextWaypoint ();
	}

	void SetNextWaypoint() {
		if (this.currentWaypointIndex < this.gameController.getWaypoints ().Length - 1) {
			this.currentWaypointIndex += 1;
			this.nextWaypiont = this.gameController.getWaypoints () [this.currentWaypointIndex];
			this.nextWaypiont.GetComponent<Renderer> ().material.color = this.getRandomColor();
		}
	}

	private Color getRandomColor() {
		Color newColor = new Color( Random.value, Random.value, Random.value, 1.0f );
		return newColor;
	}

	private void setInitialWaypoint() {
		this.transform.position = this.nextWaypiont.transform.position;
	}

	private void moveToNextWaypoint() {
		float step = movementSpeed * Time.deltaTime;
		this.transform.LookAt (this.nextWaypiont.transform);
		this.transform.position = Vector3.MoveTowards(transform.position, this.nextWaypiont.transform.position, step);
		this.SetNextWaypoint ();
	}

}