using System;

namespace rm.LoggingTestConsole
{
	class Program
	{
		static void Main(string[] args)
		{
			// log with different types
			new Foo().Start();
			new Bar().Start();
			new Baz().Start();
			new Qux().Start();
			new Xyzzy().Start();
		}
	}
}
