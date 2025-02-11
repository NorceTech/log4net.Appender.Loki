# Log4Net Grafana Loki Appender

This appender will allow *log4net* to be configured to send log messages to Loki directly, some features this library supports:

 - JSON format
 - Buffering
 - Basic Authentication
 - GZip Compression
 - Using the latest Loki HTTP API [POST /loki/api/v1/push](https://grafana.com/docs/loki/latest/api/#push-log-entries-to-loki).

## Installation


## Log4net configuration

Sample Log4net config:

```xml
<log4net>
  <appender name="loki" type="Log4Net.Appender.Loki.LokiAppender, Log4Net.Appender.Grafana.Loki">
    <Environment value="Development" /> <!-- Global label to be added to the log stream -->
    <Application value="WebApp" /> <!-- Global label to be added to the log stream -->
    <BufferSize  value="10" /> <!-- To configure the buffer size, default: 512 -->
    <ServiceUrl value="http://localhost:3100" /> <!-- Loki URL -->
    <BasicAuthUserName value="username" /> <!-- To be added if basic authent enabled  -->
    <BasicAuthPassword value="password" /> <!-- To be added if basic authent enabled  -->
    <GZipCompression value="true" /> <!-- To compress the post request using GZip compression -->
  </appender>
</log4net>
```
