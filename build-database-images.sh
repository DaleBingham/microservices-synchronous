cd clientapi/database
docker build -t clientapidb .
cd ../../inventoryapi/database
docker build -t inventoryapidb .
cd ../../peopleapi/database
docker build -t peopleapidb .
cd ../../salesapi/database
docker build -t salesapidb .
cd ../../
