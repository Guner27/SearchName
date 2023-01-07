# SearchName
# Not
Dockerfile dosyasını kullandığım redis docker image kısmından Redis'in kendi GitHub adresinden aldım.
Docker Redisi PowerShell'den komutlar ile oluşturdum. Kullandığım komutlar:
  docker pull redis
  $ docker run --name redis-names -p 6379:6379 -d redis
  
# Proje Konusu 
İnsanların merak ettiği isimlerin dünyada kaç adet olduğu ve bu isme ait kişilerin yaş 
ortalamasının hayatın hangi evresinde olduklarının gösterilmesi. Kendi yaşadıklarını göz 
önünde bulundurarak yalnız olup olmadıklarını ve dünyada kendi ismini taşıyan akranlarının 
olduğunu bilerek yalnız olmadığının farkındalığının yaşanması.

# Kullanılan Yapılar
Backend için .Net Core
Onion Architecture
Redis Docker

