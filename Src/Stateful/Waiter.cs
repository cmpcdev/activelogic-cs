// Doc/Reference/Decorator.md
#if !(UNITY_EDITOR || DEBUG)
#define AL_OPTIMIZE
#endif

using Active.Core.Details;

namespace Active.Core{
public abstract partial class Waiter : AbstractDecorator{

    public abstract void OnStatus(status s);

    protected Gate done(ValidString reason=null){
        return new Gate(this, new LogData(this, ".", reason));
    }

    protected Gate? cont(ValidString reason=null){
        StatusRef.hold = status.cont();
        #if !AL_OPTIMIZE
        SetLogData(target, reason);
        #endif
        return null;
    }

    public interface OptionalArguments{ Waiter.Gate? pass{ get; } }

}}
