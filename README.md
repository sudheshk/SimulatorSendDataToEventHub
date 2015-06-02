# SimulatorSendDataToEventHub
You can use this simulator app to send simulated data to eventhub

Before using, ensure that you have provided eventhub connection information in the "Simulate Sensor Events.exe.config" file. Following are the configs that need change:

```
      <add key="inputeventhub" value="put your event hub name here" />
      <add key="inputservicebus" value="put your service bus namespace here" />
      <add key="servicebusconnectionstring" value="put servicebus connection string here" />
    
```
Connectionstring of the service bus looks something like following:
Endpoint=sb://myservicebusnamespace.servicebus.windows.net/;SharedAccessKeyName=mypolicyname;SharedAccessKey=myaccesspolicykey
Note- this access policy should have manage permission.

That's it. Start the app by double clicking "Simulate Sensor Events.exe" and click on "Send Simulated Data". If you want to simulate a spike in the temperature, click on "Simulate Spike in temp and humidity".
