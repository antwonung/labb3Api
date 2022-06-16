# labb3Api
# Alla api anropen
# 
#
#
# GET-Requests
# Hämta alla personer i systemet:
https://localhost:44333/api/user/getusers
# Hämta alla intressen:
https://localhost:44333/api/interest/getinterests
# Hämta alla intressen som är kopplade till en specifik person:
https://localhost:44333/api/interest/getusersinterest/112
# Hämta alla länkar som är kopplade till en specifik person:
https://localhost:44333/api/link/getuserslinks/123
# Post-Requests
# Koppla en person till ett nytt intresse:
https://localhost:44333/api/interest/setnewuserinterest
# Lägga in nya länkar för en specifik person och ett specifik intresse
https://localhost:44333/api/link/newlinktointerest
