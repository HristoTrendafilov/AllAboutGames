
 
cd ./all-about-games-web

$env:NODE_OPTIONS = '--max-old-space-size=8192';
Start-Process -FilePath "npm" -ArgumentList "start"
cd ..