namespace Patterns.Arhitecture
{
    public abstract class Interactor
    {
        public virtual void Initzialize() {} // ����� OnCreate
        public virtual void OnCreate() {} // ����� ��� ����������� � ����������� �������
        public virtual void OnStart() {} // ����� Initzialize
    }

}

