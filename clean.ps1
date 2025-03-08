# Ustawienie katalogu bazowego na folder, w którym znajduje siê repozytorium
$repoPath = Get-Location 

# Znalezienie wszystkich folderów 'bin' i 'obj' w repozytorium
$folders = Get-ChildItem -Path $repoPath -Include bin, obj -Directory -Recurse

# Usuniêcie znalezionych folderów
foreach ($folder in $folders) {
    Remove-Item -Path $folder.FullName -Recurse -Force -ErrorAction SilentlyContinue
    Write-Host "Usuniêto: $($folder.FullName)"
}

Write-Host "Czyszczenie zakoñczone!"
