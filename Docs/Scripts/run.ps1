Param(
    [switch]$ResetData,
	[switch]$Suppress
)


#set things up
$stopwatch =  [system.diagnostics.stopwatch]::StartNew()
$containerName = "dunkme-sql"
$imageName = "microsoft/mssql-server-linux:2017-CU5"
$environmentVariables = "-e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=Password123' -e 'MSSQL_PID=Express'"
$port = "-p 1433:1433"
Clear-Host


#inform the user of the parameters
If (-not($Suppress)) {
	$debug = "Accepted parameters are: "
	$debug += "-ResetData " + $ResetData
	$debug += " -Suppress " + $Suppress
	
Write-Host $debug `n -f green
}


#pull image
If (-not($Suppress)) {
    Write-Host "* Pull image (" $imageName ")" -f magenta
}
docker pull $imageName


#kill and delete
If ($ResetData) {
	Write-Host "SEED DATABASE"
} Else {
	If (-not($Suppress)) {
		Write-Host "* Kill and delete container (" $containerName ")" -f magenta
	}
    docker container kill $containerName
	docker rm $containerName
}


#spin up image & start it
If (-not($Suppress)) {
    Write-Host "* Run and start container (" $containerName ")" -f magenta
}
docker run --name=$containerName $environmentVariables $port -d $imageName
docker start $containerName


#list all running containers
If (-not($Suppress)) {
    Write-Host "* List all containers" -f magenta
}
docker ps --all


#and we done!
Write-Host `n
Write-Host "Done! (Took $($stopwatch.Elapsed.TotalSeconds) seconds)" -f magenta