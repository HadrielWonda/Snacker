### Login Response

## User

POST /auth/

<h4><b>REQUEST</h4></b>
''' json
{

"id" : "0000000-0000-0000-0000-0000000000000",
"firstName" : "Drew",
"lastName" : "Phoenix",
"email" : "hadrielwondar@gmail.com",
"password" : "rectica478"

}
'''

Note: Passwords shouldn't be laying around like this.... will fix

<h4><b>RESULT</h4></b>

json
{
"id" : "ghtsd3wef-cbyrfd-48uhfh-unhb45wujyhr7",
"firstName" : "Drew",
"lastName" : "Phoenix",
"email" : "hadrielwondar@gmail.com"
"token" : "tb34rt..iunthb"
}
