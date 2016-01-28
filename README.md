Logging
=======

Logger using log4net or custom logger.

#### log4net logger:

```c#
// Logger helper class.
class Sample {
    ILogger log = Log.OfType<Sample>();
    // or 
    ILogger log = Log.Default; // calls Log.OfType<Log4NetLogger>() or configured logger
}

// Log4NetLogger class configures log4net. It also watches the log4net config file for changes at runtime.
XmlConfigurator.ConfigureAndWatch(configFile);
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
    // logger: rm.LoggingTestConsole.Baz
    private static readonly ILog log = 
        Log.OfType(MethodBase.GetCurrentMethod().DeclaringType);
}
class Qux {
    // logger: rm.Logging.Log4NetLogger
    private static readonly ILog log = Log.Default; // calls Log.OfType<Log4NetLogger>() or configured logger
}
```

```c#
// Log helper class initializes the logger with the Log type and wraps log4net methods. 
class Xyzzy {
    private void Debug() {
        // logger: rm.Logging.Log4NetLogger
        Log.Debug("some message"); // calls Log.OfType<Log4NetLogger>() or configured logger
    }
}
```

#### Custom logger:

```c#
// Configure different logger if needed.
class MyLogger : ILogger
{
    // todo: implement ILogger methods
}
```

```c#
// Add key in web/app config for logger's type name.
<add key="logger" value="dev.Logging.MyLogger"/>
```

#### Tips:

###### Configuration:

Console project:
- Look at `rm.LoggingTestConsole` project for configuration. Add the `AppConfig\log4net.config` file to your project and below in `app.config`.
```c#
<configuration>
  <configSections>
    <section name="log4net" type="log4net.Config.Log4NetConfigurationSectionHandler, log4net" />
  </configSections>
  <log4net configSource="AppConfig\log4net.config" />
</configuration>
```

Web, MVC project:
- Look at `rm.LoggingTestWeb` or `rm.LoggingTestMvc` project for configuration. Add the `AppConfig\log4net.config` file to your project and below in `web.config`.
```c#
<configuration>
  <configSections>
    <section name="log4net" type="log4net.Config.Log4NetConfigurationSectionHandler, log4net" />
  </configSections>
  <log4net configSource="AppConfig\log4net.config" />
</configuration>
```
