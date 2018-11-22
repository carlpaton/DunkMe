Param(
    [switch]$Reset,
	[switch]$Pull
)


#set things up
$stopwatch =  [system.diagnostics.stopwatch]::StartNew()
$containerName = "dunkme-db"
$imageTag = "2017-CU5"
$imageName = "microsoft/mssql-server-linux:" + $imageTag
$environmentVariables = "-e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=Password123' -e 'MSSQL_PID=Express'"
$port = "-p 1433:1433"
$globalWait = 5

function ComposeUpDunkMe {
	#start database container(s) and run detatched
	Write-Host "* Run container detatched (" $imageName ")" -f magenta
	docker-compose up -d $containerName
	Write-Host " ... wait for" $globalWait "seconds for" $containerName "to start"
	Start-Sleep $globalWait
}


#inform the user of the parameters
$debug = "Accepted parameters are: "
$debug += "-Reset " + $Reset
$debug += " -Pull " + $Pull
Clear-Host
Write-Host $debug `n -f green


#pull image docker hub
If ($Pull) {
	Write-Host "* Pull image (" $imageName ")" -f magenta
	docker pull $imageName
}


#kill and delete
If ($Reset) {
	Write-Host "* Kill and delete container (" $containerName ")" -f magenta
	docker container kill $containerName
	docker-compose rm -f

	ComposeUpDunkMe
	
	#build images (this is for services with the 'build' attribute)
	#included: git-clone ~ this is for the flyway scripts
	Write-Host "* docker-compose build" -f magenta
	docker-compose build --no-cache

	#CREATE DATABASE HERE
	Write-Host "* Create database" -f magenta	
	Invoke-Sqlcmd -Query "CREATE DATABASE dunkme" -ServerInstance "localhost" -Username "sa" -Password "Password123"
	#Invoke-Sqlcmd -Query "SELECT GETDATE() AS TimeOfQuery;" -ServerInstance "localhost" -Username "sa" -Password "Password123"
	#exit

	docker-compose up -d dunkme-baseline
	Write-Host " ... wait for" $globalWait "seconds for flyway baseline"
	Start-Sleep $globalWait
	docker-compose up -d dunkme-migrate
	Write-Host " ... wait for" $globalWait "seconds for flyway migrate"
	Start-Sleep $globalWait
} 
Else 
{
	ComposeUpDunkMe
}


#list all running containers
Write-Host "* List all containers" -f magenta
docker ps --all


#sweet as
Write-Host `n
Write-Host "Done! (Took $($stopwatch.Elapsed.TotalSeconds) seconds)" -f magenta