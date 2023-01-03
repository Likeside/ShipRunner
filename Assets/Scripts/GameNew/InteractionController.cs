using Game;
using UnityEngine;

namespace GameNew {
    public class InteractionController: IInteractionController {


        public void CollectCoin(Coin coin) {
            Debug.Log("Controller collected coin");
        }
    }
}