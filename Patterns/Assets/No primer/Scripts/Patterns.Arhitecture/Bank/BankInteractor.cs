
namespace Patterns.Arhitecture
{
    public class BankInteractor : Interactor
    {
        private BankRepository _bankRepository;

        public int coins => this._bankRepository.coins;

        public override void OnCreate()
        {
            base.OnCreate();
            this._bankRepository = Game.GetRepository<BankRepository>();
        }

        public bool isEnoughtCoins(int value) => coins >= value;

        public override void Initzialize() 
            => Bank.Initzialize(this);

        public void AddCoins(object sender, int value)
        {
            this._bankRepository.coins += value;
            this._bankRepository.Save();
        }

        public void Spend(object sender, int value)
        {
            this._bankRepository.coins -= value;
            this._bankRepository.Save();
        }
    }

}
