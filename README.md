# SimulatorSendDataToEventHub
You can use this simulator app to send simulated data to eventhub

Before using, ensure that you have provided eventhub connection information in the .config file. Following are the configs that need change:

'''
<add key="SBNameSpace" value="put your service bus namespace here" />
    <add key="EHName" value="put your event hub name here" />
    <add key="AccessPolicyName" value="put your event hub access policy name. Note- it should have manage permission" />
    <add key="AccessPolicyKey" value="put your event hub access policy key. Note- it should have manage permission" />
'''
