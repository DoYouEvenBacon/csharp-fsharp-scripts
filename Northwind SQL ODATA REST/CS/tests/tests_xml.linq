<Query Kind="Program" />

void Main() {
    var PREFIX = "odata_xml_";
    var SERVICE = "A4CS";
    
    var urls = new [] {
        (0, $"http://localhost:8181/{SERVICE}.svc/?$format=json"),
        (1, $"http://localhost:8181/{SERVICE}.svc/Orders()?$format=json&$top=0&$inlinecount=allpages"),        
        (2, $"http://localhost:8181/{SERVICE}.svc/Customers()?$format=json&$orderby=CustomerID&$top=3&$select=CustomerID,ContactName,CompanyName"),        
        (3, $"http://localhost:8181/{SERVICE}.svc/Orders()?$format=json&$orderby=OrderID desc&$top=3&$select=OrderID,CustomerID,ShipName,ShipCity,ShipCountry"),
        (4, $"http://localhost:8181/{SERVICE}.svc/Orders()?$format=json&$orderby=OrderID&$filter=OrderDate eq null&$expand=Customer&$select=OrderID,CustomerID,OrderDate,ShippedDate,Freight"),
        (5, $"http://localhost:8181/{SERVICE}.svc/Orders()?$format=json&$orderby=OrderID&$filter=ShippedDate eq null&$expand=Customer&$select=OrderID,CustomerID,OrderDate,ShippedDate,Freight"),
        (6, $"http://localhost:8181/{SERVICE}.svc/Orders()?$format=json&$orderby=OrderID&$filter=Freight eq null&$expand=Customer&$select=OrderID,CustomerID,OrderDate,ShippedDate,Freight"),
        (7, $"http://localhost:8181/{SERVICE}.svc/Customers('ALFKI')?$format=json&$expand=Orders&$select=CustomerID,ContactName,CompanyName,Orders/OrderID,Orders/ShipName,Orders/ShipCity,Orders/ShipCountry"),
        (8, $"http://localhost:8181/{SERVICE}.svc/Orders()?$format=json&$orderby=OrderID&$top=3&$expand=Customer&$select=OrderID,CustomerID,Customer/ContactName,Customer/CompanyName"),
        (9, $"http://localhost:8181/{SERVICE}.svc/Orders()?$format=json&$orderby=OrderID&$top=3&$expand=Customer&$select=OrderID,CustomerID,Customer/ContactName,Customer/CompanyName"),
    };
    
    foreach (var (i, url) in urls) {
        var res = GetRes(url);
        (url+"\r\n"+res).Dump(PREFIX+i);
        System.IO.File.WriteAllText(PREFIX+i+".txt", res);
    }
}

string GetRes(string url) {
    var uri = new System.Uri(url);
    var webClient = new System.Net.WebClient();
    var res = webClient.DownloadString(uri);
    return res;
}