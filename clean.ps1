# Ustawienie katalogu bazowego na folder, w kt�rym znajduje si� repozytorium
$repoPath = Get-Location 

# Znalezienie wszystkich folder�w 'bin' i 'obj' w repozytorium
$folders = Get-ChildItem -Path $repoPath -Include bin, obj -Directory -Recurse

# Usuni�cie znalezionych folder�w
foreach ($folder in $folders) {
    Remove-Item -Path $folder.FullName -Recurse -Force -ErrorAction SilentlyContinue
    Write-Host "Usuni�to: $($folder.FullName)"
}

Write-Host "Czyszczenie zako�czone!"
