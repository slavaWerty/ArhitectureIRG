namespace Patterns.Arhitecture
{
    public abstract class Repository
    {
        public abstract void Initzialize();
        public virtual void OnCreate() { }
        public virtual void OnStart() { }

        public abstract void Save();
    }

}
