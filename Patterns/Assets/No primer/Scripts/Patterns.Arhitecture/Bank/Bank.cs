using System;

namespace Patterns.Arhitecture
{
    public static class Bank
    {
        public static event Action OnBankInitzialized;

        private static BankInteractor _bankInteractor;
        public static bool IsInitzialize { get; private set; }

        public static int coins
        {
            get
            {
                CheckClass();
                return _bankInteractor.coins;
            }
        }

        public static void Initzialize(BankInteractor bankInteractor)
        {
            _bankInteractor = bankInteractor;
            IsInitzialize = true;
            OnBankInitzialized?.Invoke();
        }

        public static bool isEnoughtCoins(int value) 
            => _bankInteractor.isEnoughtCoins(value);

        public static void AddCoins(object sender, int value)
        {
            CheckClass();
            _bankInteractor.AddCoins(sender, value);
        }

        public static void Spend(object sender, int value)
        {
            CheckClass();
            _bankInteractor.Spend(sender, value);
        }

        private static void CheckClass()
        {
            if (!IsInitzialize)
                throw new Exception("Bank is not Initzialize");
        }
    }
}
