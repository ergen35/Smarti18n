
namespace Smarti18n
{
    [System.AttributeUsage(System.AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class TransalatableAttribute : System.Attribute
    {
        private readonly bool _canTransalte;
        public bool CanTranslate => _canTransalte;

        //ctor
        public TransalatableAttribute(bool canTranslate = true) 
        {
            _canTransalte = canTranslate; 
        }
    }
}
