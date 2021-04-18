using UnityEngine;

namespace YsoCorp {

    [DefaultExecutionOrder(-1)]
    public class DataManager : ADataManager {

        private static string PSEUDO = "PSEUDO";
        private static string LEVEL = "LEVEL";
        private static string NUMCHARACTER = "NUMCHARACTER";
        private static string COINS = "COINS";
        private static string SKINS = "SKINS";
        private static bool []Skin = new bool[3];

        private static int Coin = 0;
        private static int currentCoin = 0;


        private static int DEFAULT_COIN = 0;
        private static int DEFAULT_LEVEL = 1;

        /***** CUSTOM  *****/

        public void Start() {
            getCoin();
        }

        // LEVEL
        public int GetLevel() {
            return this.GetInt(LEVEL, DEFAULT_LEVEL);
        }
        public int NextLevel() {
            int level = this.GetLevel() + 1;
            this.SetInt(LEVEL, this.GetLevel() + 1);
            return level;
        }
        public int PrevLevel() {
            int level = Mathf.Max(this.GetLevel() - 1, DEFAULT_LEVEL);
            this.SetInt(LEVEL, level);
            return level;
        }

        //PLAYER NAME
        public string GetPseudo() {
            return this.GetString(PSEUDO, "Player");
        }
        public void SetPseudo(string pseudo) {
            this.SetString(PSEUDO, pseudo);
        }

        // NUM CHARACTER
        public int GetNumCharacter() {
            return this.GetInt(NUMCHARACTER, -1);
        }
        public void SetNumCharacter(int num) {
            this.SetInt(NUMCHARACTER, num);
        }
        public void UnlockNumCharacter(int num) {
            this.SetInt(NUMCHARACTER + num, 1);
        }
        public bool IsUnlockNumCharacter(int num) {
            this.UnlockNumCharacter(0);
            return this.GetInt(NUMCHARACTER + num, 0) == 1;
        }

        // Coin

        public void setCoin(int _coin)
        {
            Debug.Log("Rajoute de :" + _coin);
            Coin += _coin;
            Debug.Log("Final coin: " + Coin);
            this.SetInt(COINS, Coin);
        }
        public int getCoin()
        {
            Coin = this.GetInt(COINS, DEFAULT_COIN);
            Debug.Log("Jai " + Coin + " coins");
            return Coin;
        }

        //skin
        public bool getSkint(int i)
        {
            int tmp = this.GetInt(SKINS + i, Skin[i] ? 1 : 0);
            return (tmp == 1 ? true : false);
        }

        public void setSkin(bool check, int i)
        {
            this.SetInt(SKINS + i, (check) ? 1 : 0);
            Skin[i] = check;
        }

        public void addCoin()
        {
            currentCoin++;
        }

        public void endlvl()
        {
            setCoin(currentCoin);
            currentCoin = 0;
        }

    }
}