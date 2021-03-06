using NUnit.Framework;
using Active.Core;
using Active.Core.Details;
using static Active.Status;

public class TestGig : TestBase{

    C x;

    [SetUp] public void Setup() => x = new C();

    [Test] public void Log() => o( x.LogProperty(), null );

    [Test] public void Do() => o( (status)x.Do( null ), status._done );

    [Test] public void Step() => o( x.Step().failing );

    //[Test] public void Do() => o( x.DoAction(1).now.complete );

    [Test] public void ToStatusFunc(){
        System.Func<status> f = x;
        o(f == x.Step);
    }

    [Test] public void ToStatus(){
        status s = x;
        o( s.failing );
    }

    class C : Gig{
        public LogString LogProperty() => log;
        public action DoAction(object x) => Do(x);
    }

}
