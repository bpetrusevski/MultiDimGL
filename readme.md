#The solution

1. Run: docker compose up 
to setup containers

2. Use http://localhost:15672/#/queues to check RabbitMQ queues status 


TODO
1. load all records from DB server and publish it in Kafka
2. The db table is pubmk sever, table kontoprom
3. Create MS General Ledger database.
4. Create a kafka subscriber project that reads from Kafka queues and populate the MD GL with live data.

