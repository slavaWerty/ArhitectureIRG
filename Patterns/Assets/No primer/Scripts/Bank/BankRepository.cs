using UnityEngine;

namespace Patterns.Arhitecture
{
    public class BankRepository : Repository
    {
        private const string Key = "Bank_Key";

        public int coins { get; set; }

        public override void Initzialize() => this.coins = PlayerPrefs.GetInt(Key, 0);

        public override void Save() => PlayerPrefs.SetInt(Key, this.coins);
    }
}
