namespace Patterns.Arhitecture
{
    public abstract class Interactor
    {
        public virtual void Initzialize() {} // После OnCreate
        public virtual void OnCreate() {} // когда все интеракторы и репозитории соданны
        public virtual void OnStart() {} // после Initzialize
    }

}

