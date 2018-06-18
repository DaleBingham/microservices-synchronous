cd clientapi
docker build -t clientapi .
cd ../inventoryapi
docker build -t inventoryapi .
cd ../peopleapi
docker build -t peopleapi .
cd ../salesapi
docker build -t salesapi .
cd ../reportsapi
docker build -t reportsapi .
cd ../
