
# Get connection string
az servicebus namespace authorization-rule keys list \
    --resource-group learn-2d55abc9-46a1-4577-bf0c-60c42340ddb3 \
    --name RootManageSharedAccessKey \
    --query primaryConnectionString \
    --output tsv \
    --namespace-name salesteamappalvaroruano

# Show messages pending on the queue
az servicebus queue show \
    --resource-group learn-2d55abc9-46a1-4577-bf0c-60c42340ddb3 \
    --name salesmessages \
    --query messageCount \
    --namespace-name salesteamappalvaroruano

# Show messages pending on the topic for Americas subscription
az servicebus topic subscription show \
    --resource-group learn-2d55abc9-46a1-4577-bf0c-60c42340ddb3 \
    --namespace-name salesteamappalvaroruano \
    --topic-name salesperformancemessages \
    --name Americas \
    --query messageCount

# Show messages pending on the topic for Americas subscription
az servicebus topic subscription show \
    --resource-group learn-2d55abc9-46a1-4577-bf0c-60c42340ddb3 \
    --namespace-name salesteamappalvaroruano \
    --topic-name salesperformancemessages \
    --name EuropeAndAfrica \
    --query messageCount