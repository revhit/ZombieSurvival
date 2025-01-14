﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RewardText : MonoBehaviour {
	public Text rewardText;

	int accumulatedExp = 0;
	int accumulatedFund = 0;

	IEnumerator updateRewardTextCo = null;

	void Start() {
		rewardText = GameObject.Find("UI/InGameUI/Info/RewardText").GetComponent<Text>();
	}

	public void Show(int exp, int fund) {
		if(updateRewardTextCo != null) StopCoroutine(updateRewardTextCo);

		accumulatedExp += exp;
		accumulatedFund += fund;

		// rewardText.text = "+" + accumulatedExp + " Keys" + "\n+" + accumulatedFund + " $";
		rewardText.text = "+" + accumulatedFund + " $";


		updateRewardTextCo = Hide();
		StartCoroutine(updateRewardTextCo);
	}

	IEnumerator Hide() {
		yield return new WaitForSeconds(5f);
		rewardText.text = "";
		accumulatedExp = 0;
		accumulatedFund = 0;

		yield break;
	}
}
