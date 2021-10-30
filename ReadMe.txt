As a base please use a solution from the attachment it is VS2019 C#  self-hosted web API server (dotnet core, Kestrel) listening on port 9091

There is gwpByCountry.csv file with data in the Data folder.

 

Create a "CountryGwp" controller
Create endpoint listening for POST requests(application/json) at route http://localhost:9091/api/gwp/avg.
The request should allow providing  a country (string) and one or more lines of business (LOB) (array of strings).
The API should return an average gross written premium (GWP) over 2008-2015 period for the selected lines of business.

 

The output should look similar to this:
{

   "transport" : 446001906.1,

   "liability" : 634545022.9

}

 