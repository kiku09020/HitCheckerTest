using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player {
	public class DamageHitChecker : PlayerHitCheckerBase {

		//--------------------------------------------------

		protected override void HitEnterAction(Collision2D collision)
		{
			player.Rend.color = Color.black;
		}

		protected override void HitExitAction(Collision2D collision)
		{
			player.Rend.color = Color.gray;
		}
	}
}