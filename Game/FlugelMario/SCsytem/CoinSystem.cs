using SuperMario.Sound;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMario.SCsystem
{
    class CoinSystem
    {
        private static CoinSystem instance = new CoinSystem();
        public static CoinSystem Instance { get { return instance; } }
        private int coins = 0;
        public int Coins { get { return coins; } }
        public void AddCoin()
        {
            if (coins < 99)
            {
                coins++;
            }
            else if (coins == 99)
            {
                coins = 0;
                MarioInfo.MarioLife[0]++;
                SoundManager.Instance.Play1UpSound();
            }
            SoundManager.Instance.PlayCoinSound();
        }

        public void ResetCoin()
        {
            coins = 0;
        }
    }
}
