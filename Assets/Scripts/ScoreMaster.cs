using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class ScoreMaster{

	public static List<int> ScoreCumulative (List<int> rolls){
		List<int> cumulativeScores = new List<int> ();
		int runningTotal = 0;

		foreach(int frameScore in ScoreFrames(rolls)){
			runningTotal += frameScore;
			cumulativeScores.Add (runningTotal);
		}

		return cumulativeScores;
	}

	public static List<int> ScoreFrames (List<int> rolls){
		List<int> frames = new List<int> ();

		for (int i = 1; i < rolls.Count; i += 2) {
			if (frames.Count == 10) {
				break;
			}

			if(rolls[i-1] + rolls[i] < 10){
				frames.Add (rolls [i - 1] + rolls [i]);
			}

			if (rolls.Count - i <= 1) { //ensure less or equal 1
				break; //breaks out of the loop instead of going to the next condition
			}

			if (rolls [i - 1] == 10) {
				i--; //strike frame has just one bowl
				frames.Add (10 + rolls [i + 1] + rolls [i + 2]);
			}

			if (rolls [i - 1] + rolls [i] == 10) { //calculating the spare bonus
				frames.Add (10 + rolls [i + 1]);
			}
		}

		return frames;
	}
}
