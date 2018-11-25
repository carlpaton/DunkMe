Param(
    [switch]$Reset,
	[switch]$Pull
)

#SET THINGS UP
$stopwatch =  [system.diagnostics.stopwatch]::StartNew()
$containerName = "dunkme-db"
$imageTag = "2017-CU5"
$imageName = "microsoft/mssql-server-linux:" + $imageTag
$port = "-p 1433:1433"
$globalWait = 5
$sqlUser = "sa"
$sqlPass = "Password123"
$sqlDatabase = "dunkme"

function ComposeUp {

	#START DATABASE CONTAINER(S) AND RUN DETACHED
	Write-Host "* Run container detatched (" $imageName ")" -f magenta
	docker-compose up -d $containerName
	Write-Host " ... wait for" $globalWait "seconds for" $containerName "to start"
	Start-Sleep $globalWait
}

#INFORM THE USER OF THE PARAMETERS
$debug = "Accepted parameters are: "
$debug += "-Reset " + $Reset
$debug += " -Pull " + $Pull
Clear-Host
Write-Host $debug `n -f green

#PULL IMAGE FROM DOCKER HUB IF THE LOCAL LAYER IS NOT AVAILABLE 
If ($Pull) {
	Write-Host "* Pull image (" $imageName ")" -f magenta
	docker pull $imageName
}

If ($Reset) {

	#KILL AND DELETE
	Write-Host "* Kill and delete container (" $containerName ")" -f magenta
	docker container kill $containerName
	docker-compose rm -f
	
	#SPIN UP
	ComposeUp
	
	#BUILD
	Write-Host "* Docker compose build" -f magenta
	docker-compose build --no-cache

	#CREATE DATABASE
	Write-Host "* Create database" -f magenta	
	Invoke-Sqlcmd -Query "CREATE DATABASE dunkme" -ServerInstance "localhost" -Username $sqlUser -Password $sqlPass
	
	#DEBUG CONNECTION ISSUES
	#Invoke-Sqlcmd -Query "SELECT GETDATE() AS TimeOfQuery;" -ServerInstance "localhost"
	#exit
	
	#FLYWAY
	docker-compose up -d dunkme-baseline
	Write-Host " ... wait for" $globalWait "seconds for flyway baseline"
	Start-Sleep $globalWait
	docker-compose up -d dunkme-migrate
	Write-Host " ... wait for" $globalWait "seconds for flyway migrate"
	Start-Sleep $globalWait
} 
Else {
	ComposeUp
}

#LIST
Write-Host "* List all containers" -f magenta
docker ps --all

#SWEET AS
Write-Host `n
Write-Host "Sweet As, we are done! (Took $($stopwatch.Elapsed.TotalSeconds) seconds)" -f magenta