Logging
=======

Logger using log4net.

#### Highlights:

```c#
// Logger helper class.
class Sample {
    ILog log = Log.OfType<Sample>();
    // or 
    ILog log = Log.Default; // calls OfType<Log>()
}

// Log class configures log4net.
XmlConfigurator.Configure();
```

```c#
// Separate log4net.config file.
<log4net configSource="AppConfig\log4net.config" />
```

```c#
// log4net file appenders:
"default-rolling": 10 files, 2MB each
"per-execution-rolling": file per program execution, 10 files max
"smtp": email immediately when fatal event occurs (no events buffered)
```

```c#
// The log declaration is still cumbersome as type has to specified.
class Foo {
    // logger: rm.LoggingTestConsole.Foo
    private static readonly ILog log = Log.OfType<Foo>();
}
class Bar {
    // logger: rm.LoggingTestConsole.Bar
    private static readonly ILog log = Log.OfType<Bar>();
}
class Baz {
    // logger: Baz
    private static readonly ILog log = 
        Log.OfType(MethodBase.GetCurrentMethod().DeclaringType.Name);
}
class Qux {
    // logger: rm.Logging.Log
    private static readonly ILog log = Log.Default; // calls OfType<Log>()
}
```

```c#
// Log helper class initializes the logger with the Log type and wraps log4net methods. 
class Xyzzy {
    private void Debug() {
        // logger: rm.Logging.Log
        Log.Debug("some message"); // calls OfType<Log>()
    }
}
```
