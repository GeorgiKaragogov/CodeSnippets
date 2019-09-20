## Manual Installation Procedure for Let's Encrypt [on Windows] 

Execute:
```
docker run -it --rm --name certbot --volume "/tmp/etc-letsencrypt:/etc/letsencrypt" --volume "/tmp/var-lib-letsencrypt:/var/lib/letsencrypt" certbot/certbot certonly --manual --manual-public-ip-logging-ok --email {{ownerEmail}} --agree-tos --domain {{domainName}} --rsa-key-size 4096
```
and complete the challenge

Then:
```
docker exec -it {containerId} /bin/sh -c "[ -e /bin/bash ] && /bin/bash || /bin/sh"
mkdir {{domainName}}
cp /etc/letsencrypt/live/{{domainName}}/* {{domainName}}
openssl pkcs12 -export -out "certificate.pfx" -inkey "privkey.pem" -in "cert.pem" -certfile "chain.pem"
```
use simple password for 'certificate.pfx' packaging


In new terminal window:
```
docker cp {{containerId}}:{{certificatePath}} {{savePath}}
```


***

##### .well-known\acme-challenge\web.config
```
ï»¿<?xml version="1.0" encoding="UTF-8"?>
 <configuration>
     <system.webServer>
         <staticContent>
             <mimeMap fileExtension="." mimeType="text/json" />
         </staticContent>
         <handlers>
             <clear />
             <add name="StaticFile" path="*" verb="*" type=""
                     modules="StaticFileModule,DefaultDocumentModule,DirectoryListingModule"
                     scriptProcessor="" resourceType="Either" requireAccess="Read"
                     allowPathInfo="false" preCondition="" responseBufferLimit="4194304" />
         </handlers>
     </system.webServer>
 </configuration>
```