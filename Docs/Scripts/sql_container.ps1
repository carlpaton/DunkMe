#WINDOWS
#docker pull microsoft/mssql-server-windows-express:2017-GA
#docker container kill dunkme-sql
#docker rm dunkme-sql
#docker run -d -p 1433:1433 --name dunkme-sql -e sa_password=Password123 -e ACCEPT_EULA=Y microsoft/mssql-server-windows-express:2017-GA
#docker start dunkme-sql
#docker ps --all

#LINUX sql_container.sh
docker pull microsoft/mssql-server-linux:2017-CU5
docker container kill dunkme-sql
docker rm dunkme-sql
docker run --name=dunkme-sql -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=Password123' -e 'MSSQL_PID=Express' -p 1433:1433 -d microsoft/mssql-server-linux:2017-CU5
docker start dunkme-sql
docker ps --all